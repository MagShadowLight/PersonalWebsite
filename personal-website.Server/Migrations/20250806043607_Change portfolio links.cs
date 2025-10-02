using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class Changeportfoliolinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Links",
                value: "example.com");

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Links",
                value: "gitlab.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Links",
                value: "meow.com");

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Links",
                value: "woof.com");
        }
    }
}
