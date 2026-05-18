using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Web.Migrations
{
    public partial class AddNewLightsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Countdown",
                table: "HomeStatuses");

            migrationBuilder.AddColumn<bool>(
                name: "IsDuvarLightOn",
                table: "HomeStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOkumaLightOn",
                table: "HomeStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSarkitLightOn",
                table: "HomeStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTavanLightOn",
                table: "HomeStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDuvarLightOn",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "IsOkumaLightOn",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "IsSarkitLightOn",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "IsTavanLightOn",
                table: "HomeStatuses");

            migrationBuilder.AddColumn<int>(
                name: "Countdown",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
