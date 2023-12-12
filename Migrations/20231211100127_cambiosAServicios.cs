using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class cambiosAServicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "ServicioHotel");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DetalleServicioFactura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duracion",
                table: "ServicioHotel",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DetalleServicioFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
