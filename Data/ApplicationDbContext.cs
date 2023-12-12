using HotelManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static HotelManager.Data.Configuraciones;

namespace HotelManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        // Entidades
        //
        //--- Usuarios
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //--- Cita
        public DbSet<Cita> Cita { get; set; }
        //--- CorrelativoSAR
        public DbSet<CorrelativoSAR> CorrelativoSAR { get; set; }
        public DbSet<EncabezadoFactura> EncabezadoFactura { get; set; }
        //--- Habitacion
        public DbSet<Habitacion> Habitacion { get; set; }
        //--- Reserva
        public DbSet<Reserva> Reserva { get; set; }
        //--- TipoHabitacion}
        public DbSet<TipoHabitacion> TipoHabitacion { get; set; }

        // Configuraciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Cita
            modelBuilder.ApplyConfiguration(new CitasConfig());
            // CorrelativoSAR
            modelBuilder.ApplyConfiguration(new CorrelativoSARConfig());
            // EncabezadoFacturaConfig
            modelBuilder.ApplyConfiguration(new EncabezadoFacturaConfig());
            // HabitacionConfig
            modelBuilder.ApplyConfiguration(new HabitacionConfig());
            // ReservaConfig
            modelBuilder.ApplyConfiguration(new ReservaConfig());
            modelBuilder.ApplyConfiguration(new TipoHabitacionConfig());
        }
    }
}
