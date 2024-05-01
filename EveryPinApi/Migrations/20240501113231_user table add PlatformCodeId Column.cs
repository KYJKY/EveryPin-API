using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class usertableaddPlatformCodeIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c207deb-2865-49c0-8398-3b800ca13852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3570fcfe-f177-4597-971b-7eed1b11df04");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CodeOAuthPlatform",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatformCodeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CodeOAuthPlatform",
                keyColumn: "PlatformCodeId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_CodeOAuthPlatform_UserId",
                table: "CodeOAuthPlatform",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodeOAuthPlatform_AspNetUsers_UserId",
                table: "CodeOAuthPlatform",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodeOAuthPlatform_AspNetUsers_UserId",
                table: "CodeOAuthPlatform");

            migrationBuilder.DropIndex(
                name: "IX_CodeOAuthPlatform_UserId",
                table: "CodeOAuthPlatform");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1602644b-5c89-47a7-92a1-e1fa1fe30408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd111682-f052-4f10-88af-74ade56a7b7e");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CodeOAuthPlatform");

            migrationBuilder.DropColumn(
                name: "PlatformCodeId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c207deb-2865-49c0-8398-3b800ca13852", null, "NormalUser", "NORMALUSER" },
                    { "3570fcfe-f177-4597-971b-7eed1b11df04", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
