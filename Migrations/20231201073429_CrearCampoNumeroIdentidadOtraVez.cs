using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class CrearCampoNumeroIdentidadOtraVez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroIdentidad",
                table: "Reserva");

            migrationBuilder.AddColumn<string>(
                name: "NumeroIdentidad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroIdentidad",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "NumeroIdentidad",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
