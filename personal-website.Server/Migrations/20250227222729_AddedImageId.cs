using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace personal_website.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Pets", null },
                    { 2, "Cats", 1 },
                    { 3, "Dogs", 1 },
                    { 4, "Technology", null },
                    { 5, "Software", 4 },
                    { 6, "Website", 4 },
                    { 7, "Foods", null },
                    { 8, "Arts", null },
                    { 9, "Fitness", null }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "Email", "FeedbackComment", "FeedbackName", "NeededResponse" },
                values: new object[,]
                {
                    { 1, "test@test.com", "I love this website", "Website", false },
                    { 2, "meow@meow.com", "This website has security vulnerability", "Security Vulnerability", true },
                    { 3, "Real@fake.com", "This previous post is a lie", "Fake News", false }
                });

            migrationBuilder.InsertData(
                table: "PortfolioItemImages",
                columns: new[] { "Id", "Description", "FileSize", "Name" },
                values: new object[,]
                {
                    { 1, "Pic of cat", 100000, "Cat" },
                    { 2, "Pic of taco", 1000, "Taco" },
                    { 3, "Pic of dog", 100000000, "dog" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Body", "CategoryId", "CreatedDate", "Title", "UpdatedDate", "Visibility" },
                values: new object[,]
                {
                    { 1, "I love cats", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cats", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "I love Taco", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "PortfolioItems",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "ImageId", "Links", "Title", "UpdatedDate", "Version" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat pic", 1, "github.com", "Cat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.0.0" },
                    { 2, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taco pic", 2, "meow.com", "Taco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0.0.3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PortfolioItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PortfolioItemImages",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
