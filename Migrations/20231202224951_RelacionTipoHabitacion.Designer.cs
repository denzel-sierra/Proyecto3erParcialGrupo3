﻿// <auto-generated />
using System;
using HotelManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231202224951_RelacionTipoHabitacion")]
    partial class RelacionTipoHabitacion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelManager.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NumeroIdentidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HotelManager.Models.Cita", b =>
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

                    b.Property<string>("IDUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDCita");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("HotelManager.Models.CorrelativoSAR", b =>
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

            modelBuilder.Entity("HotelManager.Models.DetalleProductoFactura", b =>
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

            modelBuilder.Entity("HotelManager.Models.DetalleServicioFactura", b =>
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

            modelBuilder.Entity("HotelManager.Models.EncabezadoFactura", b =>
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

                    b.Property<string>("IDUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("HotelManager.Models.Habitacion", b =>
                {
                    b.Property<Guid>("IDHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<Guid>("IDTipoHabitacion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<decimal>("Tarifa")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Tarifa");

                    b.HasKey("IDHabitacion");

                    b.HasIndex("IDTipoHabitacion");

                    b.ToTable("Habitacion");
                });

            modelBuilder.Entity("HotelManager.Models.Producto", b =>
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

            modelBuilder.Entity("HotelManager.Models.Reserva", b =>
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

                    b.Property<Guid?>("IDFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDHabitacion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IDUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IDReserva");

                    b.HasIndex("IDFactura");

                    b.HasIndex("IDHabitacion");

                    b.HasIndex("IDUsuario");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("HotelManager.Models.ServicioHotel", b =>
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

            modelBuilder.Entity("HotelManager.Models.TipoHabitacion", b =>
                {
                    b.Property<Guid>("IDTipoHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DescripcionLarga")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("IDTipoHabitacion");

                    b.ToTable("TipoHabitacion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HotelManager.Models.DetalleProductoFactura", b =>
                {
                    b.HasOne("HotelManager.Models.EncabezadoFactura", "EncabezadoFactura")
                        .WithMany("DetalleProductoFacturas")
                        .HasForeignKey("IDFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManager.Models.Producto", "Producto")
                        .WithMany("DetalleProductoFacturas")
                        .HasForeignKey("ProductoIDProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EncabezadoFactura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("HotelManager.Models.DetalleServicioFactura", b =>
                {
                    b.HasOne("HotelManager.Models.EncabezadoFactura", "EncabezadoFactura")
                        .WithMany("DetalleServicioFacturas")
                        .HasForeignKey("IDFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManager.Models.ServicioHotel", "ServicioHotel")
                        .WithMany("DetalleServicioFacturas")
                        .HasForeignKey("ServicioHotelIDServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EncabezadoFactura");

                    b.Navigation("ServicioHotel");
                });

            modelBuilder.Entity("HotelManager.Models.EncabezadoFactura", b =>
                {
                    b.HasOne("HotelManager.Models.CorrelativoSAR", "CorrelativoSAR")
                        .WithMany("EncabezadoFacturas")
                        .HasForeignKey("CorrelativoSARIDCorrelativoSAR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManager.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("IDUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("CorrelativoSAR");
                });

            modelBuilder.Entity("HotelManager.Models.Habitacion", b =>
                {
                    b.HasOne("HotelManager.Models.TipoHabitacion", "TipoHabitacion")
                        .WithMany("Habitaciones")
                        .HasForeignKey("IDTipoHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoHabitacion");
                });

            modelBuilder.Entity("HotelManager.Models.Reserva", b =>
                {
                    b.HasOne("HotelManager.Models.EncabezadoFactura", "EncabezadoFactura")
                        .WithMany("Reservas")
                        .HasForeignKey("IDFactura");

                    b.HasOne("HotelManager.Models.Habitacion", "Habitacion")
                        .WithMany("Reservas")
                        .HasForeignKey("IDHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManager.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("IDUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("EncabezadoFactura");

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HotelManager.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HotelManager.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManager.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HotelManager.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManager.Models.CorrelativoSAR", b =>
                {
                    b.Navigation("EncabezadoFacturas");
                });

            modelBuilder.Entity("HotelManager.Models.EncabezadoFactura", b =>
                {
                    b.Navigation("DetalleProductoFacturas");

                    b.Navigation("DetalleServicioFacturas");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("HotelManager.Models.Habitacion", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("HotelManager.Models.Producto", b =>
                {
                    b.Navigation("DetalleProductoFacturas");
                });

            modelBuilder.Entity("HotelManager.Models.ServicioHotel", b =>
                {
                    b.Navigation("DetalleServicioFacturas");
                });

            modelBuilder.Entity("HotelManager.Models.TipoHabitacion", b =>
                {
                    b.Navigation("Habitaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
