using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyToPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoriesId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_Categories_CategoryId",
                table: "PortfolioItems");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Blogs",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoriesId",
                table: "Blogs",
                newName: "IX_Blogs_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "PortfolioItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_Categories_CategoryId",
                table: "PortfolioItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_Categories_CategoryId",
                table: "PortfolioItems");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Blogs",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                newName: "IX_Blogs_CategoriesId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "PortfolioItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoriesId",
                table: "Blogs",
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
    }
}
