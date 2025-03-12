using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyToPortfolioImage : Migration
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
                name: "PortfolioId",
                table: "PortfolioItemImages");

            migrationBuilder.AlterColumn<int>(
                name: "ImageID",
                table: "PortfolioItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItems_ImageID",
                table: "PortfolioItems",
                column: "ImageID",
                unique: true,
                filter: "[ImageID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageID",
                table: "PortfolioItems",
                column: "ImageID",
                principalTable: "PortfolioItemImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageID",
                table: "PortfolioItems");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioItems_ImageID",
                table: "PortfolioItems");

            migrationBuilder.AlterColumn<int>(
                name: "ImageID",
                table: "PortfolioItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "PortfolioItemImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "PortfolioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "PortfolioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "PortfolioId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItems_ImageID",
                table: "PortfolioItems",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageID",
                table: "PortfolioItems",
                column: "ImageID",
                principalTable: "PortfolioItemImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
