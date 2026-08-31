using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class createBetweenBookAndCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bf3d95b-6b33-4cbd-9114-e258d2d1bd8f", null, "User", "USER" },
                    { "40a676bb-7cee-4689-92f4-cf022a2925ed", null, "Editor", "EDITOR" },
                    { "dc79a260-2e7c-4c5c-a0f6-93220d671afc", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bf3d95b-6b33-4cbd-9114-e258d2d1bd8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40a676bb-7cee-4689-92f4-cf022a2925ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc79a260-2e7c-4c5c-a0f6-93220d671afc");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1408e9b4-6d79-432e-b6aa-7307daf5aea3", null, "Admin", "ADMIN" },
                    { "3ccd641a-70f4-40b9-8731-b6307af5df8c", null, "Editor", "EDITOR" },
                    { "de4c58b2-0f38-4ce0-bc21-c9ee2d0dde99", null, "User", "USER" }
                });
        }
    }
}
