using System.ComponentModel.DataAnnotations;

namespace PingCRM.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        public int? OrganizationId { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Region { get; set; }

        [StringLength(2)]
        public string Country { get; set; }

        [StringLength(25)]
        public string PostalCode { get; set; }
    }
}