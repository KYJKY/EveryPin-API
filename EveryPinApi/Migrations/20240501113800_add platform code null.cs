using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class addplatformcodenull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1602644b-5c89-47a7-92a1-e1fa1fe30408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd111682-f052-4f10-88af-74ade56a7b7e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "370f2e0a-7844-4c8b-9cd2-35cb5568dd57", null, "Administrator", "ADMINISTRATOR" },
                    { "47932b56-9f54-4094-85dc-e40ecf95f011", null, "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.UpdateData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 1,
                column: "PlatformName",
                value: "none");

            migrationBuilder.UpdateData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 2,
                column: "PlatformName",
                value: "kakao");

            migrationBuilder.InsertData(
                table: "CodeOAuthPlatform",
                columns: new[] { "PlatformCodeId", "PlatformName", "UserId" },
                values: new object[] { 3, "google", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "370f2e0a-7844-4c8b-9cd2-35cb5568dd57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47932b56-9f54-4094-85dc-e40ecf95f011");

            migrationBuilder.DeleteData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1602644b-5c89-47a7-92a1-e1fa1fe30408", null, "NormalUser", "NORMALUSER" },
                    { "cd111682-f052-4f10-88af-74ade56a7b7e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 1,
                column: "PlatformName",
                value: "kakao");

            migrationBuilder.UpdateData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 2,
                column: "PlatformName",
                value: "google");
        }
    }
}
