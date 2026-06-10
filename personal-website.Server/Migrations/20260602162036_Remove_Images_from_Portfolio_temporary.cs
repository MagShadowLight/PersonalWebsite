using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Images_from_Portfolio_temporary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageID",
                table: "PortfolioItems");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioItems_ImageID",
                table: "PortfolioItems");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "PortfolioItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "PortfolioItemImages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "ItemsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "ItemsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "ItemsId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItemImages_ItemsId",
                table: "PortfolioItemImages",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItemImages_PortfolioItems_ItemsId",
                table: "PortfolioItemImages",
                column: "ItemsId",
                principalTable: "PortfolioItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItemImages_PortfolioItems_ItemsId",
                table: "PortfolioItemImages");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioItemImages_ItemsId",
                table: "PortfolioItemImages");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "PortfolioItemImages");

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "PortfolioItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageID",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItems_ImageID",
                table: "PortfolioItems",
                column: "ImageID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageID",
                table: "PortfolioItems",
                column: "ImageID",
                principalTable: "PortfolioItemImages",
                principalColumn: "Id");
        }
    }
}
