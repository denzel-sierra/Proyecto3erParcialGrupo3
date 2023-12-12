using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class corregirRelacionFacturaReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_EncabezadoFactura_IDFactura",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IDFactura",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IDFactura",
                table: "Reserva");

            migrationBuilder.AddColumn<Guid>(
                name: "IDReserva",
                table: "EncabezadoFactura",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoFactura_IDReserva",
                table: "EncabezadoFactura",
                column: "IDReserva",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoFactura_Reserva_IDReserva",
                table: "EncabezadoFactura",
                column: "IDReserva",
                principalTable: "Reserva",
                principalColumn: "IDReserva");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoFactura_Reserva_IDReserva",
                table: "EncabezadoFactura");

            migrationBuilder.DropIndex(
                name: "IX_EncabezadoFactura_IDReserva",
                table: "EncabezadoFactura");

            migrationBuilder.DropColumn(
                name: "IDReserva",
                table: "EncabezadoFactura");

            migrationBuilder.AddColumn<Guid>(
                name: "IDFactura",
                table: "Reserva",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IDFactura",
                table: "Reserva",
                column: "IDFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_EncabezadoFactura_IDFactura",
                table: "Reserva",
                column: "IDFactura",
                principalTable: "EncabezadoFactura",
                principalColumn: "IDFactura");
        }
    }
}
