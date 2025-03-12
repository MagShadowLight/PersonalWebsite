using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyForBlogsV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoriesId",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "Blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "Blogs",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
