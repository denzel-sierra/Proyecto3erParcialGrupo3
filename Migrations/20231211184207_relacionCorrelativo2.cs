using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class relacionCorrelativo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoFactura_CorrelativoSAR_CorrelativoSARIDCorrelativoSAR",
                table: "EncabezadoFactura");

            migrationBuilder.DropIndex(
                name: "IX_EncabezadoFactura_CorrelativoSARIDCorrelativoSAR",
                table: "EncabezadoFactura");

            migrationBuilder.DropColumn(
                name: "CorrelativoSARIDCorrelativoSAR",
                table: "EncabezadoFactura");

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoFactura_IDCorrelativoSAR",
                table: "EncabezadoFactura",
                column: "IDCorrelativoSAR");

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoFactura_CorrelativoSAR_IDCorrelativoSAR",
                table: "EncabezadoFactura",
                column: "IDCorrelativoSAR",
                principalTable: "CorrelativoSAR",
                principalColumn: "IDCorrelativoSAR",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoFactura_CorrelativoSAR_IDCorrelativoSAR",
                table: "EncabezadoFactura");

            migrationBuilder.DropIndex(
                name: "IX_EncabezadoFactura_IDCorrelativoSAR",
                table: "EncabezadoFactura");

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelativoSARIDCorrelativoSAR",
                table: "EncabezadoFactura",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoFactura_CorrelativoSARIDCorrelativoSAR",
                table: "EncabezadoFactura",
                column: "CorrelativoSARIDCorrelativoSAR");

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoFactura_CorrelativoSAR_CorrelativoSARIDCorrelativoSAR",
                table: "EncabezadoFactura",
                column: "CorrelativoSARIDCorrelativoSAR",
                principalTable: "CorrelativoSAR",
                principalColumn: "IDCorrelativoSAR",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
