using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PingCRM.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public bool Owner { get; set; }

        public IFormFile Photo { get; set; }
    }
}