﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto3erParcialGrupo3.Data;

#nullable disable

namespace Proyecto3erParcialGrupo3.Migrations
{
    [DbContext(typeof(Proyecto3erParcialGrupo3DbContext))]
    [Migration("20231121025330_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Cita", b =>
                {
                    b.Property<Guid>("IDCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EstadoCita")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaHoraCita")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDEmpleado")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDCita");

                    b.HasIndex("IDUsuario");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.CorrelativoSAR", b =>
                {
                    b.Property<Guid>("IDCorrelativoSAR")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicial")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaLimite")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<string>("NumeroCAI")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("NumeroFinal")
                        .HasColumnType("int");

                    b.Property<int>("NumeroInicial")
                        .HasColumnType("int");

                    b.Property<int>("UltimoUtilizado")
                        .HasColumnType("int");

                    b.HasKey("IDCorrelativoSAR");

                    b.ToTable("CorrelativoSAR");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.DetalleProductoFactura", b =>
                {
                    b.Property<Guid>("IDDetalleFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("IDFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("PrecioUnitario");

                    b.Property<Guid>("ProductoIDProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SubTotalLinea")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("SubTotalLinea");

                    b.HasKey("IDDetalleFactura");

                    b.HasIndex("IDFactura");

                    b.HasIndex("ProductoIDProducto");

                    b.ToTable("DetalleProductoFactura");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.DetalleServicioFactura", b =>
                {
                    b.Property<Guid>("IDDetalleFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("IDFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDServicio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("PrecioUnitario");

                    b.Property<Guid>("ServicioHotelIDServicio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SubTotalLinea")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("SubTotalLinea");

                    b.HasKey("IDDetalleFactura");

                    b.HasIndex("IDFactura");

                    b.HasIndex("ServicioHotelIDServicio");

                    b.ToTable("DetalleServicioFactura");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.EncabezadoFactura", b =>
                {
                    b.Property<Guid>("IDFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorrelativoSARIDCorrelativoSAR")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DescuentoFactura")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("DescuentoFactura");

                    b.Property<bool>("Eliminada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDCorrelativoSAR")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDEmpleado")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ImpuestoFactura")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("ImpuestoFactura");

                    b.Property<string>("NumeroFacturaSAR")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("SubTotalFactura")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("SubTotalFactura");

                    b.Property<decimal>("TotalFactura")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("TotalFactura");

                    b.HasKey("IDFactura");

                    b.HasIndex("CorrelativoSARIDCorrelativoSAR");

                    b.HasIndex("IDUsuario");

                    b.ToTable("EncabezadoFactura");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Habitacion", b =>
                {
                    b.Property<Guid>("IDHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<decimal>("Tarifa")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Tarifa");

                    b.Property<string>("TipoHabitacion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("IDHabitacion");

                    b.ToTable("Habitacion");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Producto", b =>
                {
                    b.Property<Guid>("IDProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Existencias")
                        .HasColumnType("int");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("PrecioUnitario");

                    b.HasKey("IDProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Reserva", b =>
                {
                    b.Property<Guid>("IDReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EstadoReserva")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCheckin")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDHabitacion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDReserva");

                    b.HasIndex("IDFactura");

                    b.HasIndex("IDHabitacion");

                    b.HasIndex("IDUsuario");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.ServicioHotel", b =>
                {
                    b.Property<Guid>("IDServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<TimeSpan>("Duracion")
                        .HasColumnType("time");

                    b.Property<string>("NombreServicio")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Tarifa")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Tarifa");

                    b.HasKey("IDServicio");

                    b.ToTable("ServicioHotel");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Usuario", b =>
                {
                    b.Property<Guid>("IDUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("IDUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Cita", b =>
                {
                    b.HasOne("Proyecto3erParcialGrupo3.Models.Usuario", "Usuario")
                        .WithMany("Citas")
                        .HasForeignKey("IDUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.DetalleProductoFactura", b =>
                {
                    b.HasOne("Proyecto3erParcialGrupo3.Models.EncabezadoFactura", "EncabezadoFactura")
                        .WithMany("DetalleProductoFacturas")
                        .HasForeignKey("IDFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto3erParcialGrupo3.Models.Producto", "Producto")
                        .WithMany("DetalleProductoFacturas")
                        .HasForeignKey("ProductoIDProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EncabezadoFactura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.DetalleServicioFactura", b =>
                {
                    b.HasOne("Proyecto3erParcialGrupo3.Models.EncabezadoFactura", "EncabezadoFactura")
                        .WithMany("DetalleServicioFacturas")
                        .HasForeignKey("IDFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto3erParcialGrupo3.Models.ServicioHotel", "ServicioHotel")
                        .WithMany("DetalleServicioFacturas")
                        .HasForeignKey("ServicioHotelIDServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EncabezadoFactura");

                    b.Navigation("ServicioHotel");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.EncabezadoFactura", b =>
                {
                    b.HasOne("Proyecto3erParcialGrupo3.Models.CorrelativoSAR", "CorrelativoSAR")
                        .WithMany("EncabezadoFacturas")
                        .HasForeignKey("CorrelativoSARIDCorrelativoSAR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto3erParcialGrupo3.Models.Usuario", "Usuario")
                        .WithMany("EncabezadoFacturas")
                        .HasForeignKey("IDUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorrelativoSAR");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Reserva", b =>
                {
                    b.HasOne("Proyecto3erParcialGrupo3.Models.EncabezadoFactura", "EncabezadoFactura")
                        .WithMany("Reservas")
                        .HasForeignKey("IDFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto3erParcialGrupo3.Models.Habitacion", "Habitacion")
                        .WithMany("Reservas")
                        .HasForeignKey("IDHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto3erParcialGrupo3.Models.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("IDUsuario");

                    b.Navigation("EncabezadoFactura");

                    b.Navigation("Habitacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.CorrelativoSAR", b =>
                {
                    b.Navigation("EncabezadoFacturas");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.EncabezadoFactura", b =>
                {
                    b.Navigation("DetalleProductoFacturas");

                    b.Navigation("DetalleServicioFacturas");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Habitacion", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Producto", b =>
                {
                    b.Navigation("DetalleProductoFacturas");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.ServicioHotel", b =>
                {
                    b.Navigation("DetalleServicioFacturas");
                });

            modelBuilder.Entity("Proyecto3erParcialGrupo3.Models.Usuario", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("EncabezadoFacturas");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
