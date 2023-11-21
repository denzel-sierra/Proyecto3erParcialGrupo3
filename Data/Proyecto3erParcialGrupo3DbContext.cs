﻿using Microsoft.EntityFrameworkCore;
using Proyecto3erParcialGrupo3.Models;
using static Proyecto3erParcialGrupo3.Data.Configuraciones;

namespace Proyecto3erParcialGrupo3.Data
{
    public class Proyecto3erParcialGrupo3DbContext : DbContext
    {
        // Constructor
        public Proyecto3erParcialGrupo3DbContext(DbContextOptions<Proyecto3erParcialGrupo3DbContext> options) : base(options) { }

        // Entidades
        //
        //--- Usuarios
        public DbSet<Usuario> Usuarios { get; set; }
        //--- Cita
        public DbSet<Cita> Cita { get; set; }
        //--- CorrelativoSAR
        public DbSet<CorrelativoSAR> CorrelativoSAR { get; set; }
        //--- DetalleProductoFactura
        public DbSet<DetalleProductoFactura> DetalleProductoFactura { get; set; }
        //--- DetalleServicioFactura
        public DbSet<DetalleServicioFactura> DetalleServicioFactura { get; set; }
        //--- EncabezadoFactura
        public DbSet<EncabezadoFactura> EncabezadoFactura { get; set; }
        //--- Habitacion
        public DbSet<Habitacion> Habitacion { get; set; }
        //--- Producto
        public DbSet<Producto> Producto { get; set; }
        //--- Reserva
        public DbSet<Reserva> Reserva { get; set; }
        //--- ServicioHotel
        public DbSet<ServicioHotel> ServicioHotel { get; set; }


        // Configuraciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Usuarios
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            // Cita
            modelBuilder.ApplyConfiguration(new CitasConfig());
            // CorrelativoSAR
            modelBuilder.ApplyConfiguration(new CorrelativoSARConfig());
            // DetalleProductoFacturaConfig
            modelBuilder.ApplyConfiguration(new DetalleProductoFacturaConfig());
            // DetalleServicioFacturaConfig
            modelBuilder.ApplyConfiguration(new DetalleServicioFacturaConfig());
            // EncabezadoFacturaConfig
            modelBuilder.ApplyConfiguration(new EncabezadoFacturaConfig());
            // HabitacionConfig
            modelBuilder.ApplyConfiguration(new HabitacionConfig());
            // ProductoConfig
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            // ReservaConfig
            modelBuilder.ApplyConfiguration(new ReservaConfig());
            // ServicioHotelConfig
            modelBuilder.ApplyConfiguration(new ServicioHotelConfig());
        }
    }
}
