using System;

namespace PingCRM.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? OrganizationId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Organization? Organization { get; set; }

        public string Name => $"{FirstName} {LastName}";
    }
}