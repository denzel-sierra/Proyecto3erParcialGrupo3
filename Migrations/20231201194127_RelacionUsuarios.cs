using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class RelacionUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IDUsuario",
                table: "Reserva",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IDUsuario",
                table: "EncabezadoFactura",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IDUsuario",
                table: "Reserva",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoFactura_IDUsuario",
                table: "EncabezadoFactura",
                column: "IDUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoFactura_AspNetUsers_IDUsuario",
                table: "EncabezadoFactura",
                column: "IDUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_AspNetUsers_IDUsuario",
                table: "Reserva",
                column: "IDUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoFactura_AspNetUsers_IDUsuario",
                table: "EncabezadoFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_AspNetUsers_IDUsuario",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IDUsuario",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_EncabezadoFactura_IDUsuario",
                table: "EncabezadoFactura");

            migrationBuilder.AlterColumn<string>(
                name: "IDUsuario",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IDUsuario",
                table: "EncabezadoFactura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
