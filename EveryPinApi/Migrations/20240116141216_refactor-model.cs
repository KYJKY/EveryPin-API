using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class refactormodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e40618a-157e-49c0-baa4-a21365dad9c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2e99813-2533-4073-bbfe-d327d0b74546");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7936c632-4ef6-4ff9-9417-555941ceadd4", null, "NormalUser", "NORMALUSER" },
                    { "c5127bc6-4ae3-40e2-b9c9-8c297f6810b1", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7936c632-4ef6-4ff9-9417-555941ceadd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5127bc6-4ae3-40e2-b9c9-8c297f6810b1");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e40618a-157e-49c0-baa4-a21365dad9c2", null, "NormalUser", "NORMALUSER" },
                    { "c2e99813-2533-4073-bbfe-d327d0b74546", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
