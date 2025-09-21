using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PingCRM.Models;

namespace PingCRM.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(25);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(25);
                entity.Property(e => e.PhotoPath).IsRequired(false);
                entity.HasIndex(e => e.DeletedAt);

                entity.HasOne(e => e.Account)
                    .WithMany(a => a.Users)
                    .HasForeignKey(e => e.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organizations");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(150);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Region).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(2);
                entity.Property(e => e.PostalCode).HasMaxLength(25);
                entity.HasIndex(e => e.DeletedAt);

                entity.HasOne(e => e.Account)
                    .WithMany(a => a.Organizations)
                    .HasForeignKey(e => e.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(25);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(25);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(150);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Region).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(2);
                entity.Property(e => e.PostalCode).HasMaxLength(25);
                entity.HasIndex(e => e.DeletedAt);

                entity.HasOne(e => e.Account)
                    .WithMany(a => a.Contacts)
                    .HasForeignKey(e => e.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Organization)
                    .WithMany(o => o.Contacts)
                    .HasForeignKey(e => e.OrganizationId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            var now = DateTime.UtcNow;

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Name = "Acme Corporation", CreatedAt = now, UpdatedAt = now }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    AccountId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com",
                    UserName = "johndoe@example.com",
                    NormalizedUserName = "JOHNDOE@EXAMPLE.COM",
                    NormalizedEmail = "JOHNDOE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new User { FirstName = "", LastName = "" }, "secret"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Owner = true,
                    CreatedAt = now,
                    UpdatedAt = now
                }
            );

            // Seed Organizations
            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    AccountId = 1,
                    Name = "Tech Solutions Inc",
                    Email = "info@techsolutions.com",
                    Phone = "+1 555-0123",
                    Address = "123 Tech Street",
                    City = "San Francisco",
                    Region = "CA",
                    Country = "US",
                    PostalCode = "94105",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Organization
                {
                    Id = 2,
                    AccountId = 1,
                    Name = "Global Marketing Group",
                    Email = "contact@globalmarketing.com",
                    Phone = "+1 555-0456",
                    Address = "456 Marketing Avenue",
                    City = "New York",
                    Region = "NY",
                    Country = "US",
                    PostalCode = "10001",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Organization
                {
                    Id = 3,
                    AccountId = 1,
                    Name = "Design Studio Pro",
                    Email = "hello@designstudio.com",
                    Phone = "+1 555-0789",
                    Address = "789 Creative Lane",
                    City = "Los Angeles",
                    Region = "CA",
                    Country = "US",
                    PostalCode = "90210",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Organization
                {
                    Id = 4,
                    AccountId = 1,
                    Name = "Consulting Partners Ltd",
                    Email = "info@consulting.com",
                    Phone = "+1 555-0321",
                    Address = "321 Business Plaza",
                    City = "Chicago",
                    Region = "IL",
                    Country = "US",
                    PostalCode = "60601",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Organization
                {
                    Id = 5,
                    AccountId = 1,
                    Name = "Innovation Labs",
                    Email = "contact@innovationlabs.com",
                    Phone = "+1 555-0654",
                    Address = "654 Innovation Drive",
                    City = "Austin",
                    Region = "TX",
                    Country = "US",
                    PostalCode = "73301",
                    CreatedAt = now,
                    UpdatedAt = now
                }
            );

            // Seed Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    AccountId = 1,
                    OrganizationId = 1,
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    Email = "sarah.johnson@techsolutions.com",
                    Phone = "+1 555-0111",
                    Address = "123 Tech Street",
                    City = "San Francisco",
                    Region = "CA",
                    Country = "US",
                    PostalCode = "94105",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Contact
                {
                    Id = 2,
                    AccountId = 1,
                    OrganizationId = 1,
                    FirstName = "Michael",
                    LastName = "Chen",
                    Email = "michael.chen@techsolutions.com",
                    Phone = "+1 555-0222",
                    Address = "123 Tech Street",
                    City = "San Francisco",
                    Region = "CA",
                    Country = "US",
                    PostalCode = "94105",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Contact
                {
                    Id = 3,
                    AccountId = 1,
                    OrganizationId = 2,
                    FirstName = "Emily",
                    LastName = "Rodriguez",
                    Email = "emily.rodriguez@globalmarketing.com",
                    Phone = "+1 555-0333",
                    Address = "456 Marketing Avenue",
                    City = "New York",
                    Region = "NY",
                    Country = "US",
                    PostalCode = "10001",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Contact
                {
                    Id = 4,
                    AccountId = 1,
                    OrganizationId = 3,
                    FirstName = "David",
                    LastName = "Wilson",
                    Email = "david.wilson@designstudio.com",
                    Phone = "+1 555-0444",
                    Address = "789 Creative Lane",
                    City = "Los Angeles",
                    Region = "CA",
                    Country = "US",
                    PostalCode = "90210",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Contact
                {
                    Id = 5,
                    AccountId = 1,
                    OrganizationId = 4,
                    FirstName = "Lisa",
                    LastName = "Anderson",
                    Email = "lisa.anderson@consulting.com",
                    Phone = "+1 555-0555",
                    Address = "321 Business Plaza",
                    City = "Chicago",
                    Region = "IL",
                    Country = "US",
                    PostalCode = "60601",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Contact
                {
                    Id = 6,
                    AccountId = 1,
                    OrganizationId = 5,
                    FirstName = "Robert",
                    LastName = "Taylor",
                    Email = "robert.taylor@innovationlabs.com",
                    Phone = "+1 555-0666",
                    Address = "654 Innovation Drive",
                    City = "Austin",
                    Region = "TX",
                    Country = "US",
                    PostalCode = "73301",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Contact
                {
                    Id = 7,
                    AccountId = 1,
                    OrganizationId = null,
                    FirstName = "Jennifer",
                    LastName = "Brown",
                    Email = "jennifer.brown@freelancer.com",
                    Phone = "+1 555-0777",
                    Address = "987 Independent Way",
                    City = "Seattle",
                    Region = "WA",
                    Country = "US",
                    PostalCode = "98101",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Contact
                {
                    Id = 8,
                    AccountId = 1,
                    OrganizationId = null,
                    FirstName = "James",
                    LastName = "Miller",
                    Email = "james.miller@consultant.com",
                    Phone = "+1 555-0888",
                    Address = "147 Solo Street",
                    City = "Denver",
                    Region = "CO",
                    Country = "US",
                    PostalCode = "80201",
                    CreatedAt = now,
                    UpdatedAt = now
                }
            );
        }
    }
}