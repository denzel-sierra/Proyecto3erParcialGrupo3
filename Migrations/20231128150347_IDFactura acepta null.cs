using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class IDFacturaaceptanull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_EncabezadoFactura_IDFactura",
                table: "Reserva");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDFactura",
                table: "Reserva",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_EncabezadoFactura_IDFactura",
                table: "Reserva",
                column: "IDFactura",
                principalTable: "EncabezadoFactura",
                principalColumn: "IDFactura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_EncabezadoFactura_IDFactura",
                table: "Reserva");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDFactura",
                table: "Reserva",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_EncabezadoFactura_IDFactura",
                table: "Reserva",
                column: "IDFactura",
                principalTable: "EncabezadoFactura",
                principalColumn: "IDFactura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
