using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "CreatedDate", "Name", "PhotoUrl", "SelfIntroduction", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("8b23a1d6-860a-4ff2-becd-d7c8a8c238a5"), new DateTime(2023, 12, 6, 20, 43, 16, 420, DateTimeKind.Local).AddTicks(9705), "Yi Sun-sin", null, "명량해전의 이순신 입니다.", null, new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212") },
                    { new Guid("a13ffaa2-c689-4d24-8f65-12df4b9d724c"), new DateTime(2023, 12, 6, 20, 43, 16, 420, DateTimeKind.Local).AddTicks(9702), "Name", null, "안녕하세요, 홍길동입니다.", null, new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "GoogleEmail", "GoogleId", "GoogleName", "KakaoEmail", "KakaoId", "KakaoName", "ProfileId" },
                values: new object[,]
                {
                    { new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"), "test01@gmail.com", "test01", "홍길동", null, null, null, new Guid("a13ffaa2-c689-4d24-8f65-12df4b9d724c") },
                    { new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"), null, null, null, "test02@naver.com", "test02", "이순신", new Guid("8b23a1d6-860a-4ff2-becd-d7c8a8c238a5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: new Guid("8b23a1d6-860a-4ff2-becd-d7c8a8c238a5"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: new Guid("a13ffaa2-c689-4d24-8f65-12df4b9d724c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"));
        }
    }
}
