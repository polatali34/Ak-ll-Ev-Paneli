using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Web.Migrations
{
    public partial class AddRoomBrightnessSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BalconyBrightness",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BathroomBrightness",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BedroomBrightness",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Countdown",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HallBrightness",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KitchenBrightness",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LivingRoomBrightness",
                table: "HomeStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalconyBrightness",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "BathroomBrightness",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "BedroomBrightness",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "Countdown",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "HallBrightness",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "KitchenBrightness",
                table: "HomeStatuses");

            migrationBuilder.DropColumn(
                name: "LivingRoomBrightness",
                table: "HomeStatuses");
        }
    }
}
