using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyForBlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoriesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoriesId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoriesId",
                table: "Blogs",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoriesId",
                table: "Blogs",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoriesId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoriesId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Blogs");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
