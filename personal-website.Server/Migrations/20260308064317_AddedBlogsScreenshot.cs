using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedBlogsScreenshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogsScreenshotId",
                table: "Blogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BlogsScreenshot",
                columns: table => new
                {
                    BlogsScreenshotId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsScreenshot", x => x.BlogsScreenshotId);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "BlogsScreenshotId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "BlogsScreenshotId",
                value: 2);

            migrationBuilder.InsertData(
                table: "BlogsScreenshot",
                columns: new[] { "BlogsScreenshotId", "Description", "Path" },
                values: new object[,]
                {
                    { 1, "Cat", "Images\\cat.jpg" },
                    { 2, "Taco", "Images\\taco.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogsScreenshotId",
                table: "Blogs",
                column: "BlogsScreenshotId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogsScreenshot_BlogsScreenshotId",
                table: "Blogs",
                column: "BlogsScreenshotId",
                principalTable: "BlogsScreenshot",
                principalColumn: "BlogsScreenshotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogsScreenshot_BlogsScreenshotId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "BlogsScreenshot");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogsScreenshotId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogsScreenshotId",
                table: "Blogs");
        }
    }
}
