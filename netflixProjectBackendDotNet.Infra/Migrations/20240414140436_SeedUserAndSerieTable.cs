using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace netflixProjectBackendDotNet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndSerieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Featured", "Name", "Synopsis", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9171), true, "Prison Break", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/prisonbreak.jpg" },
                    { 2, 1, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9283), true, "Breaking Bad", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/breakingbad.jpg" },
                    { 3, 6, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9285), true, "The Boys", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/theboys.jpg" },
                    { 4, 3, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9286), true, "Friends", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/friends.jpg" },
                    { 5, 3, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9287), true, "How I Met Your Mother", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/himym.jpg" },
                    { 6, 5, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9291), true, "Game of Thrones", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/got.jpg" },
                    { 7, 5, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9292), true, "House of the Dragon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/hotd.jpg" },
                    { 8, 6, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9293), true, "The Last of Us", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/tlou.jpg" },
                    { 9, 4, new DateTime(2024, 4, 14, 14, 4, 36, 512, DateTimeKind.Utc).AddTicks(9294), true, "Vikings", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "/serie/vikings.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birth", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 1, new DateTime(1991, 1, 1, 2, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 14, 11, 4, 36, 512, DateTimeKind.Local).AddTicks(2575), "admin@email.com", "Admin", "User", "$2a$12$ojQ8ZUs9jZi.GmXGphkUmOgvZxwuhyfYRGoaJS84phXxqr2GlfQ7C", "(31) 99999-9999", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
