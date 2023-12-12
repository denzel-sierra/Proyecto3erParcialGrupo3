using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class noMasProductosYservicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleProductoFactura");

            migrationBuilder.DropTable(
                name: "DetalleServicioFactura");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "ServicioHotel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IDProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Existencias = table.Column<int>(type: "int", nullable: false),
                    NombreProducto = table.Column<string>(type: "varchar(255)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IDProducto);
                });

            migrationBuilder.CreateTable(
                name: "ServicioHotel",
                columns: table => new
                {
                    IDServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false),
                    NombreServicio = table.Column<string>(type: "varchar(255)", nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioHotel", x => x.IDServicio);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProductoFactura",
                columns: table => new
                {
                    IDDetalleFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoIDProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IDProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    SubTotalLinea = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProductoFactura", x => x.IDDetalleFactura);
                    table.ForeignKey(
                        name: "FK_DetalleProductoFactura_EncabezadoFactura_IDFactura",
                        column: x => x.IDFactura,
                        principalTable: "EncabezadoFactura",
                        principalColumn: "IDFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProductoFactura_Producto_ProductoIDProducto",
                        column: x => x.ProductoIDProducto,
                        principalTable: "Producto",
                        principalColumn: "IDProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleServicioFactura",
                columns: table => new
                {
                    IDDetalleFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicioHotelIDServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    SubTotalLinea = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleServicioFactura", x => x.IDDetalleFactura);
                    table.ForeignKey(
                        name: "FK_DetalleServicioFactura_EncabezadoFactura_IDFactura",
                        column: x => x.IDFactura,
                        principalTable: "EncabezadoFactura",
                        principalColumn: "IDFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleServicioFactura_ServicioHotel_ServicioHotelIDServicio",
                        column: x => x.ServicioHotelIDServicio,
                        principalTable: "ServicioHotel",
                        principalColumn: "IDServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProductoFactura_IDFactura",
                table: "DetalleProductoFactura",
                column: "IDFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProductoFactura_ProductoIDProducto",
                table: "DetalleProductoFactura",
                column: "ProductoIDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleServicioFactura_IDFactura",
                table: "DetalleServicioFactura",
                column: "IDFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleServicioFactura_ServicioHotelIDServicio",
                table: "DetalleServicioFactura",
                column: "ServicioHotelIDServicio");
        }
    }
}
