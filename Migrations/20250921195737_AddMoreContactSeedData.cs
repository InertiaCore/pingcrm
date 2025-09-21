using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PingCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreContactSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "AccountId", "Address", "City", "Country", "CreatedAt", "DeletedAt", "Email", "FirstName", "LastName", "OrganizationId", "Phone", "PostalCode", "Region", "UpdatedAt" },
                values: new object[,]
                {
                    { 9, 1, "456 Marketing Avenue", "New York", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "patricia.garcia@globalmarketing.com", "Patricia", "Garcia", 2, "+1 555-0901", "10001", "NY", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 10, 1, "789 Creative Lane", "Los Angeles", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "chris.martinez@designstudio.com", "Christopher", "Martinez", 3, "+1 555-1001", "90210", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 11, 1, "123 Tech Street", "San Francisco", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "amanda.davis@techsolutions.com", "Amanda", "Davis", 1, "+1 555-1101", "94105", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 12, 1, "321 Business Plaza", "Chicago", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "daniel.lopez@consulting.com", "Daniel", "Lopez", 4, "+1 555-1201", "60601", "IL", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 13, 1, "654 Innovation Drive", "Austin", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "michelle.thomas@innovationlabs.com", "Michelle", "Thomas", 5, "+1 555-1301", "73301", "TX", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 14, 1, "258 Remote Street", "Portland", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "kevin.jackson@freelancer.com", "Kevin", "Jackson", null, "+1 555-1401", "97201", "OR", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 15, 1, "456 Marketing Avenue", "New York", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "laura.white@globalmarketing.com", "Laura", "White", 2, "+1 555-1501", "10001", "NY", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 16, 1, "123 Tech Street", "San Francisco", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "brian.harris@techsolutions.com", "Brian", "Harris", 1, "+1 555-1601", "94105", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 17, 1, "789 Creative Lane", "Los Angeles", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "samantha.clark@designstudio.com", "Samantha", "Clark", 3, "+1 555-1701", "90210", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 18, 1, "321 Business Plaza", "Chicago", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "ryan.lewis@consulting.com", "Ryan", "Lewis", 4, "+1 555-1801", "60601", "IL", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 19, 1, "654 Innovation Drive", "Austin", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "rachel.robinson@innovationlabs.com", "Rachel", "Robinson", 5, "+1 555-1901", "73301", "TX", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 20, 1, "369 Freelance Lane", "Miami", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "steven.walker@independent.com", "Steven", "Walker", null, "+1 555-2001", "33101", "FL", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 21, 1, "123 Tech Street", "San Francisco", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "nicole.hall@techsolutions.com", "Nicole", "Hall", 1, "+1 555-2101", "94105", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 22, 1, "456 Marketing Avenue", "New York", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "andrew.young@globalmarketing.com", "Andrew", "Young", 2, "+1 555-2201", "10001", "NY", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 23, 1, "789 Creative Lane", "Los Angeles", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "jessica.king@designstudio.com", "Jessica", "King", 3, "+1 555-2301", "90210", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 24, 1, "321 Business Plaza", "Chicago", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "joshua.wright@consulting.com", "Joshua", "Wright", 4, "+1 555-2401", "60601", "IL", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 25, 1, "654 Innovation Drive", "Austin", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "stephanie.hill@innovationlabs.com", "Stephanie", "Hill", 5, "+1 555-2501", "73301", "TX", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 26, 1, "789 Independent Blvd", "Boston", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "matthew.scott@contractor.com", "Matthew", "Scott", null, "+1 555-2601", "02101", "MA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 27, 1, "123 Tech Street", "San Francisco", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "ashley.green@techsolutions.com", "Ashley", "Green", 1, "+1 555-2701", "94105", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 28, 1, "456 Marketing Avenue", "New York", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "justin.adams@globalmarketing.com", "Justin", "Adams", 2, "+1 555-2801", "10001", "NY", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 29, 1, "789 Creative Lane", "Los Angeles", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "megan.baker@designstudio.com", "Megan", "Baker", 3, "+1 555-2901", "90210", "CA", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) },
                    { 30, 1, "321 Business Plaza", "Chicago", "US", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), null, "brandon.nelson@consulting.com", "Brandon", "Nelson", 4, "+1 555-3001", "60601", "IL", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) }
                });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "62dc4f32-2762-4229-b529-e4e1e93d8ccd", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010), "AQAAAAIAAYagAAAAEE5RzHZ+3dQAI1H7sUo0TtR+HJb+yc336uLFL5PcW63/BbGqdE9cNBf1pbjgj5bKow==", "70e9a4fe-5125-413d-bb98-13a1bdd72fe3", new DateTime(2025, 9, 21, 19, 57, 36, 803, DateTimeKind.Utc).AddTicks(1010) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "42895ece-88b6-4d3d-9988-09268e2643be", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920), "AQAAAAIAAYagAAAAEHX8mn9KpQW0LYwv4eoXBlhnigj96588XQmJk7Q9NynzPh5kYUPbKWl0iRrPvgYT6Q==", "4e017e40-531e-4bfd-9746-f2ec5ab998c6", new DateTime(2025, 9, 21, 3, 14, 49, 780, DateTimeKind.Utc).AddTicks(9920) });
        }
    }
}
