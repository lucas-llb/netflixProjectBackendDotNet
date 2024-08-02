using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netflixProjectBackendDotNet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddingMissingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "WatchTimes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WatchTimeEpisodeId",
                table: "Episodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WatchTimeUserId",
                table: "Episodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 1, 23, 16, 58, 240, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 8, 1, 23, 16, 58, 239, DateTimeKind.Utc).AddTicks(7495), "$2a$12$XtBlOghCHQQ27sLXDJVk4eqxVCGo6F3O8332rw6R5pSxFqP0m1iq6" });

            migrationBuilder.CreateIndex(
                name: "IX_WatchTimes_UserEntityId",
                table: "WatchTimes",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_WatchTimeUserId_WatchTimeEpisodeId",
                table: "Episodes",
                columns: new[] { "WatchTimeUserId", "WatchTimeEpisodeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_WatchTimes_WatchTimeUserId_WatchTimeEpisodeId",
                table: "Episodes",
                columns: new[] { "WatchTimeUserId", "WatchTimeEpisodeId" },
                principalTable: "WatchTimes",
                principalColumns: new[] { "UserId", "EpisodeId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchTimes_Users_UserEntityId",
                table: "WatchTimes",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_WatchTimes_WatchTimeUserId_WatchTimeEpisodeId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchTimes_Users_UserEntityId",
                table: "WatchTimes");

            migrationBuilder.DropIndex(
                name: "IX_WatchTimes_UserEntityId",
                table: "WatchTimes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_WatchTimeUserId_WatchTimeEpisodeId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "WatchTimes");

            migrationBuilder.DropColumn(
                name: "WatchTimeEpisodeId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "WatchTimeUserId",
                table: "Episodes");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 22, 0, 36, 976, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 4, 14, 22, 0, 36, 975, DateTimeKind.Utc).AddTicks(9808), "$2a$12$yE2c7tjaz7ojD4kcDk4e8ORo3u1pEaZLcmmeT390lkQK0K6Az7JKe" });
        }
    }
}
