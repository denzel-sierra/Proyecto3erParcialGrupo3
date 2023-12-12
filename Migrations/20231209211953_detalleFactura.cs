using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class detalleFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EncabezadoFacturaIDFactura",
                table: "ServicioHotel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicioHotel_EncabezadoFacturaIDFactura",
                table: "ServicioHotel",
                column: "EncabezadoFacturaIDFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioHotel_EncabezadoFactura_EncabezadoFacturaIDFactura",
                table: "ServicioHotel",
                column: "EncabezadoFacturaIDFactura",
                principalTable: "EncabezadoFactura",
                principalColumn: "IDFactura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioHotel_EncabezadoFactura_EncabezadoFacturaIDFactura",
                table: "ServicioHotel");

            migrationBuilder.DropIndex(
                name: "IX_ServicioHotel_EncabezadoFacturaIDFactura",
                table: "ServicioHotel");

            migrationBuilder.DropColumn(
                name: "EncabezadoFacturaIDFactura",
                table: "ServicioHotel");
        }
    }
}
