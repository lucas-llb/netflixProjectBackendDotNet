using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace netflixProjectBackendDotNet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserCategorySerie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Position" },
                values: new object[,]
                {
                    { 1, "Action", 1 },
                    { 2, "Documentary", 2 },
                    { 3, "Comedy", 3 },
                    { 4, "Drama", 4 },
                    { 5, "Fantasy", 5 },
                    { 6, "Adventure", 6 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birth", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 1, new DateTime(1991, 1, 1, 2, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 14, 22, 0, 36, 975, DateTimeKind.Utc).AddTicks(9808), "admin@email.com", "Admin", "User", "$2a$12$yE2c7tjaz7ojD4kcDk4e8ORo3u1pEaZLcmmeT390lkQK0K6Az7JKe", "(31) 99999-9999", 0 });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Featured", "Name", "Synopsis", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6255), true, "Prison Break", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/prisonbreak.jpg" },
                    { 2, 1, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6377), true, "Breaking Bad", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/breakingbad.jpg" },
                    { 3, 6, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6379), true, "The Boys", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/theboys.jpg" },
                    { 4, 3, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6380), true, "Friends", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/friends.jpg" },
                    { 5, 3, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6381), true, "How I Met Your Mother", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/himym.jpg" },
                    { 6, 5, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6390), true, "Game of Thrones", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/got.jpg" },
                    { 7, 5, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6391), true, "House of the Dragon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/hotd.jpg" },
                    { 8, 6, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6392), true, "The Last of Us", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/tlou.jpg" },
                    { 9, 4, new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6394), true, "Vikings", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/vikings.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

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
        }
    }
}
