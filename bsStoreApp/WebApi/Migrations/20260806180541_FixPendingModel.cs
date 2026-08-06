using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03c78a28-ff0e-4c1c-80f7-d4bbcbaafffa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332c5026-015c-46e7-98e5-463fdb267649");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b18af1-2ecc-4306-b7d0-064ff2a28687");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27e1a7fc-8fdf-4e03-9f51-5f0d7e16b851", null, "User", "USER" },
                    { "97272cd4-5369-41f2-b367-55c45df38a82", null, "Admin", "ADMIN" },
                    { "f32a1d13-801f-405c-8ae1-e88cdb1dee59", null, "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27e1a7fc-8fdf-4e03-9f51-5f0d7e16b851");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97272cd4-5369-41f2-b367-55c45df38a82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f32a1d13-801f-405c-8ae1-e88cdb1dee59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03c78a28-ff0e-4c1c-80f7-d4bbcbaafffa", null, "Editor", "EDITOR" },
                    { "332c5026-015c-46e7-98e5-463fdb267649", null, "Admin", "ADMIN" },
                    { "37b18af1-2ecc-4306-b7d0-064ff2a28687", null, "User", "USER" }
                });
        }
    }
}
