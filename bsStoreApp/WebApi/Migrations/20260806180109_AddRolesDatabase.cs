using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
