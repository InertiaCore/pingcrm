using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingCRM.Migrations
{
    /// <inheritdoc />
    public partial class FixStaticPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c30612e-c353-44c1-a4c3-400e348f573b", "AQAAAAIAAYagAAAAEE5RzHZ+3dQAI1H7sUo0TtR+HJb+yc336uLFL5PcW63/BbGqdE9cNBf1pbjgj5bKow==", "70e9a4fe-5125-413d-bb98-13a1bdd72fe3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b39e5818-2933-4f58-81e6-43454c8ace18", "AQAAAAIAAYagAAAAEE+mu9jINv0N6nD2FpcBHSgO5qHRTqk2cGmXczwk/o60s0eNOaReww+mkt7Hn1E8Og==", "e720693a-a522-46e5-b9ed-4260d75432cb" });
        }
    }
}
