using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class addtoprofileTagId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aebf893-ab00-4ad9-888a-5105f184e270");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0e4284d-687e-4ed5-af8f-891aba60fe12");

            migrationBuilder.AddColumn<string>(
                name: "TagId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e0dae88-bc42-49e2-bed4-b232e7595f50", null, "NormalUser", "NORMALUSER" },
                    { "68f7ea00-7dd6-4f08-b631-56eb6b94eea8", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e0dae88-bc42-49e2-bed4-b232e7595f50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68f7ea00-7dd6-4f08-b631-56eb6b94eea8");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Profiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1aebf893-ab00-4ad9-888a-5105f184e270", null, "Administrator", "ADMINISTRATOR" },
                    { "d0e4284d-687e-4ed5-af8f-891aba60fe12", null, "NormalUser", "NORMALUSER" }
                });
        }
    }
}
