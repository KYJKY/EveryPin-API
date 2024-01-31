using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMapAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2179ba12-d152-45d3-9d76-d2f5eaca01cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8160263c-668a-4495-89dc-35b9296d3a0f");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "Posts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "Posts",
                type: "float",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "923a3112-78df-4baf-8127-5aa87babcea7", null, "Administrator", "ADMINISTRATOR" },
                    { "fafbb86f-5268-49e8-a8a0-c35be787f05a", null, "NormalUser", "NORMALUSER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "923a3112-78df-4baf-8127-5aa87babcea7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fafbb86f-5268-49e8-a8a0-c35be787f05a");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2179ba12-d152-45d3-9d76-d2f5eaca01cf", null, "NormalUser", "NORMALUSER" },
                    { "8160263c-668a-4495-89dc-35b9296d3a0f", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
