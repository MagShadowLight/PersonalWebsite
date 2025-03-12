using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class linkedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "PortfolioItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItems_CategoryId",
                table: "PortfolioItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoriesId",
                table: "Categories",
                column: "CategoriesId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoriesId",
                table: "Categories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_Categories_CategoryId",
                table: "PortfolioItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoriesId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_Categories_CategoryId",
                table: "PortfolioItems");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioItems_CategoryId",
                table: "PortfolioItems");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoriesId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "PortfolioItems");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Blogs");
        }
    }
}
