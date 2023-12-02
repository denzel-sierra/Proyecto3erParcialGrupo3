using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class RelacionTipoHabitacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Habitacion");

            migrationBuilder.DropColumn(
                name: "TipoHabitacion",
                table: "Habitacion");

            migrationBuilder.AddColumn<Guid>(
                name: "IDTipoHabitacion",
                table: "Habitacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_IDTipoHabitacion",
                table: "Habitacion",
                column: "IDTipoHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacion_TipoHabitacion_IDTipoHabitacion",
                table: "Habitacion",
                column: "IDTipoHabitacion",
                principalTable: "TipoHabitacion",
                principalColumn: "IDTipoHabitacion",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacion_TipoHabitacion_IDTipoHabitacion",
                table: "Habitacion");

            migrationBuilder.DropIndex(
                name: "IX_Habitacion_IDTipoHabitacion",
                table: "Habitacion");

            migrationBuilder.DropColumn(
                name: "IDTipoHabitacion",
                table: "Habitacion");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Habitacion",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoHabitacion",
                table: "Habitacion",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");
        }
    }
}
