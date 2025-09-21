using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PingCRM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organizations_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Owner = table.Column<bool>(type: "INTEGER", nullable: false),
                    PhotoPath = table.Column<string>(type: "TEXT", nullable: true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contacts_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), "Acme Corporation", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "AccountId", "Address", "City", "Country", "CreatedAt", "DeletedAt", "Email", "FirstName", "LastName", "OrganizationId", "Phone", "PostalCode", "Region", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, 1, "987 Independent Way", "Seattle", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "jennifer.brown@freelancer.com", "Jennifer", "Brown", null, "+1 555-0777", "98101", "WA", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 8, 1, "147 Solo Street", "Denver", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "james.miller@consultant.com", "James", "Miller", null, "+1 555-0888", "80201", "CO", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) }
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "AccountId", "Address", "City", "Country", "CreatedAt", "DeletedAt", "Email", "Name", "Phone", "PostalCode", "Region", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "123 Tech Street", "San Francisco", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "info@techsolutions.com", "Tech Solutions Inc", "+1 555-0123", "94105", "CA", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 2, 1, "456 Marketing Avenue", "New York", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "contact@globalmarketing.com", "Global Marketing Group", "+1 555-0456", "10001", "NY", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 3, 1, "789 Creative Lane", "Los Angeles", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "hello@designstudio.com", "Design Studio Pro", "+1 555-0789", "90210", "CA", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 4, 1, "321 Business Plaza", "Chicago", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "info@consulting.com", "Consulting Partners Ltd", "+1 555-0321", "60601", "IL", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 5, 1, "654 Innovation Drive", "Austin", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "contact@innovationlabs.com", "Innovation Labs", "+1 555-0654", "73301", "TX", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "AccountId", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Owner", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { 1, 0, 1, "42895ece-88b6-4d3d-9988-09268e2643be", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "johndoe@example.com", true, "John", "Doe", false, null, "JOHNDOE@EXAMPLE.COM", "JOHNDOE@EXAMPLE.COM", true, "AQAAAAIAAYagAAAAEHX8mn9KpQW0LYwv4eoXBlhnigj96588XQmJk7Q9NynzPh5kYUPbKWl0iRrPvgYT6Q==", null, false, null, "4e017e40-531e-4bfd-9746-f2ec5ab998c6", false, new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), "johndoe@example.com" });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "AccountId", "Address", "City", "Country", "CreatedAt", "DeletedAt", "Email", "FirstName", "LastName", "OrganizationId", "Phone", "PostalCode", "Region", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "123 Tech Street", "San Francisco", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "sarah.johnson@techsolutions.com", "Sarah", "Johnson", 1, "+1 555-0111", "94105", "CA", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 2, 1, "123 Tech Street", "San Francisco", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "michael.chen@techsolutions.com", "Michael", "Chen", 1, "+1 555-0222", "94105", "CA", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 3, 1, "456 Marketing Avenue", "New York", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "emily.rodriguez@globalmarketing.com", "Emily", "Rodriguez", 2, "+1 555-0333", "10001", "NY", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 4, 1, "789 Creative Lane", "Los Angeles", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "david.wilson@designstudio.com", "David", "Wilson", 3, "+1 555-0444", "90210", "CA", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 5, 1, "321 Business Plaza", "Chicago", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "lisa.anderson@consulting.com", "Lisa", "Anderson", 4, "+1 555-0555", "60601", "IL", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) },
                    { 6, 1, "654 Innovation Drive", "Austin", "US", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), null, "robert.taylor@innovationlabs.com", "Robert", "Taylor", 5, "+1 555-0666", "73301", "TX", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_AccountId",
                table: "contacts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_DeletedAt",
                table: "contacts",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_organizations_AccountId",
                table: "organizations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_organizations_DeletedAt",
                table: "organizations",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_users_AccountId",
                table: "users",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_users_DeletedAt",
                table: "users",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
