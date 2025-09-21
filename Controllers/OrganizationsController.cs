using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InertiaCore;
using PingCRM.Data;
using PingCRM.Models;
using PingCRM.ViewModels;
using PingCRM.Helpers;

namespace PingCRM.Controllers
{
    [Authorize]
    public class OrganizationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrganizationsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("organizations")]
        public async Task<IActionResult> Index(string? search, string? trashed, int page = 1)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser?.AccountId == null)
            {
                return Unauthorized();
            }
            const int pageSize = 10;

            var query = _context.Organizations
                .Where(o => o.AccountId == currentUser.AccountId);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(o => o.Name.Contains(search));
            }

            if (!string.IsNullOrEmpty(trashed))
            {
                if (trashed == "only")
                {
                    query = query.Where(o => o.DeletedAt != null);
                }
            }
            else
            {
                query = query.Where(o => o.DeletedAt == null);
            }

            var total = await query.CountAsync();
            var organizations = await query
                .OrderBy(o => o.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(o => new
                {
                    o.Id,
                    o.Name,
                    o.Phone,
                    o.City,
                    DeletedAt = o.DeletedAt
                })
                .ToListAsync();

            return Inertia.Render("Organizations/Index", new
            {
                Filters = new { search, trashed },
                Organizations = new PaginatedList<object>(organizations, total, page, pageSize)
            });
        }

        [HttpGet]
        [Route("organizations/create")]
        public IActionResult Create()
        {
            return Inertia.Render("Organizations/Create");
        }

        [HttpPost]
        [Route("organizations")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(OrganizationViewModel model)
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

            var organization = new Organization
            {
                AccountId = currentUser.AccountId.Value,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                Country = model.Country,
                PostalCode = model.PostalCode,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            TempData["success"] = "Organization created.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("organizations/{id}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var organization = await _context.Organizations
                .Include(o => o.Contacts)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (organization == null)
            {
                return NotFound();
            }

            return Inertia.Render("Organizations/Edit", new
            {
                Organization = new
                {
                    organization.Id,
                    organization.Name,
                    organization.Email,
                    organization.Phone,
                    organization.Address,
                    organization.City,
                    organization.Region,
                    organization.Country,
                    PostalCode = organization.PostalCode,
                    DeletedAt = organization.DeletedAt,
                    Contacts = organization.Contacts?
                        .OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName)
                        .Select(c => new
                        {
                            c.Id,
                            Name = c.Name,
                            c.City,
                            c.Phone
                        })
                }
            });
        }

        [HttpPut]
        [Route("organizations/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, OrganizationViewModel model)
        {
            var organization = await _context.Organizations.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Inertia.Back();
            }

            organization.Name = model.Name;
            organization.Email = model.Email;
            organization.Phone = model.Phone;
            organization.Address = model.Address;
            organization.City = model.City;
            organization.Region = model.Region;
            organization.Country = model.Country;
            organization.PostalCode = model.PostalCode;
            organization.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            TempData["success"] = "Organization updated.";
            return Inertia.Back();
        }

        [HttpDelete]
        [Route("organizations/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Destroy(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            organization.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            TempData["success"] = "Organization deleted.";
            return Inertia.Back();
        }

        [HttpPut]
        [Route("organizations/{id}/restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Restore(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            organization.DeletedAt = null;
            await _context.SaveChangesAsync();

            TempData["success"] = "Organization restored.";
            return Inertia.Back();
        }
    }
}
