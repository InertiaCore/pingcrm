using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace PingCRM.ViewModels
{
    [ExportTsClass]
    public class OrganizationViewModel
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

        [StringLength(150)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? Region { get; set; }

        [StringLength(2)]
        public string? Country { get; set; }

        [StringLength(25)]
        public string? PostalCode { get; set; }
    }
}