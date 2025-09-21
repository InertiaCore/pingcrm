using System;
using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace PingCRM.Models
{
    [ExportTsClass]
    public class Organization
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public required string Name { get; set; }
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
        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}