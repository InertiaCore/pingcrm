using System;
using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace PingCRM.Models
{
    [ExportTsClass]
    public class Account
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Organization>? Organizations { get; set; }
        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}