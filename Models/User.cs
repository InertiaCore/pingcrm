using System;
using Microsoft.AspNetCore.Identity;
using TypeGen.Core.TypeAnnotations;

namespace PingCRM.Models
{
    [ExportTsClass]
    public class User : IdentityUser<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool Owner { get; set; }
        public string? PhotoPath { get; set; }
        public int? AccountId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Account? Account { get; set; }

        public string Name => $"{FirstName} {LastName}";

        public bool IsDemoUser()
        {
            return Email == "johndoe@example.com";
        }
    }
}