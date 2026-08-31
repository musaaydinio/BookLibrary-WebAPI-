using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017a1aa8-fd9e-4d84-99fa-7b0ade7625ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64c1fa53-2baf-4d68-8333-e60c20c2b0ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4da778e-f8b5-4ca5-8359-63964e1746b1");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1408e9b4-6d79-432e-b6aa-7307daf5aea3", null, "Admin", "ADMIN" },
                    { "3ccd641a-70f4-40b9-8731-b6307af5df8c", null, "Editor", "EDITOR" },
                    { "de4c58b2-0f38-4ce0-bc21-c9ee2d0dde99", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Developer" },
                    { 2, "Network" },
                    { 3, "Coding" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1408e9b4-6d79-432e-b6aa-7307daf5aea3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ccd641a-70f4-40b9-8731-b6307af5df8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de4c58b2-0f38-4ce0-bc21-c9ee2d0dde99");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "017a1aa8-fd9e-4d84-99fa-7b0ade7625ed", null, "Editor", "EDITOR" },
                    { "64c1fa53-2baf-4d68-8333-e60c20c2b0ac", null, "User", "USER" },
                    { "a4da778e-f8b5-4ca5-8359-63964e1746b1", null, "Admin", "ADMIN" }
                });
        }
    }
}
