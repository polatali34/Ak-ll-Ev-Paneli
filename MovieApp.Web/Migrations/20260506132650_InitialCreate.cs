using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    IsLightOn = table.Column<bool>(type: "bit", nullable: false),
                    IsMotorRunning = table.Column<bool>(type: "bit", nullable: false),
                    Countdown = table.Column<int>(type: "int", nullable: false),
                    SetMinutes = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    ConnectionQuality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastSyncTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeStatuses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeStatuses");
        }
    }
}
