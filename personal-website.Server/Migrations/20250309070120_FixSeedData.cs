using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "Images/cat.jpg");

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "Images/taco.jpg");

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "Images/dog.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "/Images/cat.jpg");

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "/Images/taco.jpg");

            migrationBuilder.UpdateData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "/Images/dog.jpg");
        }
    }
}
