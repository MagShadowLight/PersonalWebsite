using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogsScreenshot",
                keyColumn: "BlogsScreenshotId",
                keyValue: 1,
                column: "Path",
                value: "images/cat.png");

            migrationBuilder.UpdateData(
                table: "BlogsScreenshot",
                keyColumn: "BlogsScreenshotId",
                keyValue: 2,
                column: "Path",
                value: "images/taco.png");

            migrationBuilder.UpdateData(
                table: "BlogsScreenshot",
                keyColumn: "BlogsScreenshotId",
                keyValue: 3,
                column: "Path",
                value: "images/loremispum.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogsScreenshot",
                keyColumn: "BlogsScreenshotId",
                keyValue: 1,
                column: "Path",
                value: "images\\cat.png");

            migrationBuilder.UpdateData(
                table: "BlogsScreenshot",
                keyColumn: "BlogsScreenshotId",
                keyValue: 2,
                column: "Path",
                value: "images\\taco.png");

            migrationBuilder.UpdateData(
                table: "BlogsScreenshot",
                keyColumn: "BlogsScreenshotId",
                keyValue: 3,
                column: "Path",
                value: "images\\loremispum.png");
        }
    }
}
