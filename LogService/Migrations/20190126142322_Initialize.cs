using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogService.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "LogsEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "LogsEntries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentTime",
                table: "LogsEntries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "LogsEntries");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "LogsEntries");

            migrationBuilder.DropColumn(
                name: "SentTime",
                table: "LogsEntries");
        }
    }
}
