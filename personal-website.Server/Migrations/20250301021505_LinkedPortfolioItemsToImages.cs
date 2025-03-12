using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class LinkedPortfolioItemsToImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageId",
                table: "PortfolioItems");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "PortfolioItems",
                newName: "ImageID");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioItems_ImageId",
                table: "PortfolioItems",
                newName: "IX_PortfolioItems_ImageID");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "PortfolioItemImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "PortfolioItemImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "FileSize", "Path", "PortfolioId" },
                values: new object[] { 12006L, "/Images/cat.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FileSize", "Path", "PortfolioId" },
                values: new object[] { 14400L, "/Images/taco.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FileSize", "Path", "PortfolioId" },
                values: new object[] { 21457L, "/Images/dog.jpg", 0 });

            migrationBuilder.InsertData(
                table: "PortfolioItems",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "ImageID", "Links", "Title", "UpdatedDate", "Version" },
                values: new object[] { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dog pic", 3, "woof.com", "Dog", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0.1.0" });

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageID",
                table: "PortfolioItems",
                column: "ImageID",
                principalTable: "PortfolioItemImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageID",
                table: "PortfolioItems");

            migrationBuilder.DeleteData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Path",
                table: "PortfolioItemImages");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "PortfolioItemImages");

            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "PortfolioItems",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioItems_ImageID",
                table: "PortfolioItems",
                newName: "IX_PortfolioItems_ImageId");

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "PortfolioItemImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "FileSize",
                value: 100000);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileSize",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileSize",
                value: 100000000);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItems_PortfolioItemImages_ImageId",
                table: "PortfolioItems",
                column: "ImageId",
                principalTable: "PortfolioItemImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
