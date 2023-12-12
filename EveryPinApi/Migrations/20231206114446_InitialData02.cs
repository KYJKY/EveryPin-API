using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EveryPinApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: new Guid("8b23a1d6-860a-4ff2-becd-d7c8a8c238a5"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 20, 44, 46, 206, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: new Guid("a13ffaa2-c689-4d24-8f65-12df4b9d724c"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 6, 20, 44, 46, 206, DateTimeKind.Local).AddTicks(9095), "홍홍홍" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: new Guid("8b23a1d6-860a-4ff2-becd-d7c8a8c238a5"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 20, 43, 16, 420, DateTimeKind.Local).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: new Guid("a13ffaa2-c689-4d24-8f65-12df4b9d724c"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 6, 20, 43, 16, 420, DateTimeKind.Local).AddTicks(9702), "Name" });
        }
    }
}
