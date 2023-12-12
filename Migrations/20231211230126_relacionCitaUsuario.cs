using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class relacionCitaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IDUsuario",
                table: "Cita",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IDUsuario",
                table: "Cita",
                column: "IDUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_AspNetUsers_IDUsuario",
                table: "Cita",
                column: "IDUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_AspNetUsers_IDUsuario",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_IDUsuario",
                table: "Cita");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDUsuario",
                table: "Cita",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
