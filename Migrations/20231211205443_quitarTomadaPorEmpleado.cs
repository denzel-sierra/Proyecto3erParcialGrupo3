using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class quitarTomadaPorEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TomadaPorEmpleado",
                table: "Cita");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TomadaPorEmpleado",
                table: "Cita",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
