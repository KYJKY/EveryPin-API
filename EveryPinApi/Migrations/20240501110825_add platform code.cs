using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class addplatformcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CodeOAuthPlatforms",
                table: "CodeOAuthPlatforms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "923a3112-78df-4baf-8127-5aa87babcea7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fafbb86f-5268-49e8-a8a0-c35be787f05a");

            migrationBuilder.DropColumn(
                name: "PlatformCodeId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "CodeOAuthPlatforms",
                newName: "CodeOAuthPlatform");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodeOAuthPlatform",
                table: "CodeOAuthPlatform",
                column: "PlatformCodeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c207deb-2865-49c0-8398-3b800ca13852", null, "NormalUser", "NORMALUSER" },
                    { "3570fcfe-f177-4597-971b-7eed1b11df04", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "CodeOAuthPlatform",
                columns: new[] { "PlatformCodeId", "PlatformName" },
                values: new object[,]
                {
                    { 1, "kakao" },
                    { 2, "google" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CodeOAuthPlatform",
                table: "CodeOAuthPlatform");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c207deb-2865-49c0-8398-3b800ca13852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3570fcfe-f177-4597-971b-7eed1b11df04");

            migrationBuilder.DeleteData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "CodeOAuthPlatform",
                newName: "CodeOAuthPlatforms");

            migrationBuilder.AddColumn<int>(
                name: "PlatformCodeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodeOAuthPlatforms",
                table: "CodeOAuthPlatforms",
                column: "PlatformCodeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "923a3112-78df-4baf-8127-5aa87babcea7", null, "Administrator", "ADMINISTRATOR" },
                    { "fafbb86f-5268-49e8-a8a0-c35be787f05a", null, "NormalUser", "NORMALUSER" }
                });
        }
    }
}
