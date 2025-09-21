using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TypeGen.Core.TypeAnnotations;

namespace PingCRM.ViewModels
{
    [ExportTsClass]
    public class UserViewModel
    {
        [Required]
        [StringLength(25)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public required string Email { get; set; }

        public required string Password { get; set; }

        [Required]
        public bool Owner { get; set; }

        // Note: File uploads handled separately on frontend via FormData/File API
        [TsIgnore]
        public IFormFile? Photo { get; set; }
    }
}