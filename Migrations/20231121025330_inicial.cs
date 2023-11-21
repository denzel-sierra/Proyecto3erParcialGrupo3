using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto3erParcialGrupo3.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorrelativoSAR",
                columns: table => new
                {
                    IDCorrelativoSAR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCAI = table.Column<string>(type: "varchar(255)", nullable: false),
                    NumeroInicial = table.Column<int>(type: "int", nullable: false),
                    NumeroFinal = table.Column<int>(type: "int", nullable: false),
                    UltimoUtilizado = table.Column<int>(type: "int", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrelativoSAR", x => x.IDCorrelativoSAR);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    IDHabitacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoHabitacion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.IDHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IDProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreProducto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Existencias = table.Column<int>(type: "int", nullable: false)
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
                    NombreServicio = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "time", nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioHotel", x => x.IDServicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rol = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(255)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(255)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "varchar(255)", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "varchar(255)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "varchar(255)", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    IDCita = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaHoraCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoCita = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.IDCita);
                    table.ForeignKey(
                        name: "FK_Cita_Usuarios_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncabezadoFactura",
                columns: table => new
                {
                    IDFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCorrelativoSAR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroFacturaSAR = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotalFactura = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DescuentoFactura = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ImpuestoFactura = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    TotalFactura = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Eliminada = table.Column<bool>(type: "bit", nullable: false),
                    CorrelativoSARIDCorrelativoSAR = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncabezadoFactura", x => x.IDFactura);
                    table.ForeignKey(
                        name: "FK_EncabezadoFactura_CorrelativoSAR_CorrelativoSARIDCorrelativoSAR",
                        column: x => x.CorrelativoSARIDCorrelativoSAR,
                        principalTable: "CorrelativoSAR",
                        principalColumn: "IDCorrelativoSAR",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncabezadoFactura_Usuarios_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProductoFactura",
                columns: table => new
                {
                    IDDetalleFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    SubTotalLinea = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductoIDProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    IDServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    SubTotalLinea = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ServicioHotelIDServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IDReserva = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDHabitacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCheckin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoReserva = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IDReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_EncabezadoFactura_IDFactura",
                        column: x => x.IDFactura,
                        principalTable: "EncabezadoFactura",
                        principalColumn: "IDFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Habitacion_IDHabitacion",
                        column: x => x.IDHabitacion,
                        principalTable: "Habitacion",
                        principalColumn: "IDHabitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuarios_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IDUsuario",
                table: "Cita",
                column: "IDUsuario");

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

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoFactura_CorrelativoSARIDCorrelativoSAR",
                table: "EncabezadoFactura",
                column: "CorrelativoSARIDCorrelativoSAR");

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoFactura_IDUsuario",
                table: "EncabezadoFactura",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IDFactura",
                table: "Reserva",
                column: "IDFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IDHabitacion",
                table: "Reserva",
                column: "IDHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IDUsuario",
                table: "Reserva",
                column: "IDUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "DetalleProductoFactura");

            migrationBuilder.DropTable(
                name: "DetalleServicioFactura");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "ServicioHotel");

            migrationBuilder.DropTable(
                name: "EncabezadoFactura");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "CorrelativoSAR");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
