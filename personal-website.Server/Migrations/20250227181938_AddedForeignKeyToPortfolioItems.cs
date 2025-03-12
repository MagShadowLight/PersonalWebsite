using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyToPortfolioItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "PortfolioItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItems_ImageId",
                table: "PortfolioItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageId",
                table: "PortfolioItems",
                column: "ImageId",
                principalTable: "PortfolioItemImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageId",
                table: "PortfolioItems");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioItems_ImageId",
                table: "PortfolioItems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PortfolioItems");
        }
    }
}
