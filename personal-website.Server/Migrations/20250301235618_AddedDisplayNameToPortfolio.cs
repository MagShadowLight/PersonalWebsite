using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedDisplayNameToPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "PortfolioItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayName",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayName",
                value: "Taco");

            migrationBuilder.UpdateData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayName",
                value: "Dog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "PortfolioItems");
        }
    }
}
