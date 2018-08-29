using Microsoft.EntityFrameworkCore.Migrations;

namespace Clockwork.API.Migrations
{
    public partial class AddTimeZoneColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeZoneId",
                table: "CurrentTimeQueries");

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "CurrentTimeQueries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "CurrentTimeQueries");

            migrationBuilder.AddColumn<int>(
                name: "TimeZoneId",
                table: "CurrentTimeQueries",
                nullable: false,
                defaultValue: 0);
        }
    }
}
