using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InertiaCore;
using PingCRM.Data;
using PingCRM.Models;
using PingCRM.ViewModels;

namespace PingCRM.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _environment;

        public UsersController(
            ApplicationDbContext context,
            UserManager<User> userManager,
            IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Index(string? search, string? role, string? trashed)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser?.AccountId == null)
            {
                return Unauthorized();
            }

            var query = _context.Users
                .Where(u => u.AccountId == currentUser.AccountId);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u =>
                    (u.FirstName ?? "").Contains(search) ||
                    (u.LastName ?? "").Contains(search) ||
                    (u.Email ?? "").Contains(search));
            }

            if (!string.IsNullOrEmpty(role))
            {
                query = role switch
                {
                    "user" => query.Where(u => !u.Owner),
                    "owner" => query.Where(u => u.Owner),
                    _ => query
                };
            }

            if (!string.IsNullOrEmpty(trashed))
            {
                if (trashed == "only")
                {
                    query = query.Where(u => u.DeletedAt != null);
                }
            }
            else
            {
                query = query.Where(u => u.DeletedAt == null);
            }

            var users = await query
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.Id,
                    Name = u.Name,
                    u.Email,
                    u.Owner,
                    Photo = u.PhotoPath != null ? $"/img/{u.PhotoPath}?w=40&h=40&fit=crop" : null,
                    DeletedAt = u.DeletedAt
                })
                .ToListAsync();

            return Inertia.Render("Users/Index", new
            {
                Filters = new { search, role, trashed },
                Users = users
            });
        }

        [HttpGet]
        [Route("users/create")]
        public IActionResult Create()
        {
            return Inertia.Render("Users/Create");
        }

        [HttpPost]
        [Route("users")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Inertia.Back();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser?.AccountId == null)
            {
                return Unauthorized();
            }

            var user = new User
            {
                AccountId = currentUser.AccountId.Value,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                Owner = model.Owner,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (model.Photo != null)
            {
                user.PhotoPath = await SavePhotoAsync(model.Photo);
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Inertia.Back();
            }

            TempData["success"] = "User created.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("users/{id}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Inertia.Render("Users/Edit", new
            {
                User = new
                {
                    user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    user.Email,
                    user.Owner,
                    Photo = user.PhotoPath != null ? $"/img/{user.PhotoPath}?w=60&h=60&fit=crop" : null,
                    DeletedAt = user.DeletedAt
                }
            });
        }

        [HttpPut]
        [Route("users/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UserViewModel model)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (_environment.EnvironmentName == "Demo" && user.IsDemoUser())
            {
                TempData["error"] = "Updating the demo user is not allowed.";
                return Inertia.Back();
            }

            if (!ModelState.IsValid)
            {
                return Inertia.Back();
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Owner = model.Owner;
            user.UpdatedAt = DateTime.UtcNow;

            if (model.Photo != null)
            {
                user.PhotoPath = await SavePhotoAsync(model.Photo);
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, model.Password);
            }

            await _context.SaveChangesAsync();

            TempData["success"] = "User updated.";
            return Inertia.Back();
        }

        [HttpDelete]
        [Route("users/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Destroy(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (_environment.EnvironmentName == "Demo" && user.IsDemoUser())
            {
                TempData["error"] = "Deleting the demo user is not allowed.";
                return Inertia.Back();
            }

            user.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            TempData["success"] = "User deleted.";
            return Inertia.Back();
        }

        [HttpPut]
        [Route("users/{id}/restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Restore(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.DeletedAt = null;
            await _context.SaveChangesAsync();

            TempData["success"] = "User restored.";
            return Inertia.Back();
        }

        private async Task<string> SavePhotoAsync(IFormFile photo)
        {
            var fileName = $"{Guid.NewGuid()}{System.IO.Path.GetExtension(photo.FileName)}";
            var filePath = System.IO.Path.Combine(_environment.WebRootPath, "uploads", "users", fileName);

            var directoryPath = System.IO.Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }

            using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            return $"users/{fileName}";
        }
    }
}
