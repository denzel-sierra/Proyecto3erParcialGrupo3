using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HotelManager.Models;

namespace HotelManager.Data
{
    public class Configuraciones
    {
        public class CitasConfig : IEntityTypeConfiguration<Cita>
        {
            public void Configure(EntityTypeBuilder<Cita> builder)
            {
                //llave
                builder.HasKey(x => x.IDCita);
                //llave foranea

                builder.Property(s => s.EstadoCita).HasColumnType("varchar(255)");

                builder.HasOne(r => r.ApplicationUser).WithMany().HasForeignKey(r => r.IDUsuario).IsRequired(true).OnDelete(DeleteBehavior.NoAction);

            }
        }
        public class CorrelativoSARConfig : IEntityTypeConfiguration<CorrelativoSAR>
        {
            public void Configure(EntityTypeBuilder<CorrelativoSAR> builder)
            {
                //llave
                builder.HasKey(x => x.IDCorrelativoSAR);

                builder.Property(s => s.NumeroCAI).HasColumnType("varchar(255)");
            }
        }
        public class EncabezadoFacturaConfig : IEntityTypeConfiguration<EncabezadoFactura>
        {
            public void Configure(EntityTypeBuilder<EncabezadoFactura> builder)
            {
                //llave
                builder.HasKey(x => x.IDFactura);

                builder.Property(s => s.NumeroFacturaSAR).HasColumnType("varchar(255)");
                builder.Property(a => a.SubTotalFactura).HasColumnType("decimal(8,2)").HasColumnName("SubTotalFactura");
                builder.Property(a => a.DescuentoFactura).HasColumnType("decimal(8,2)").HasColumnName("DescuentoFactura");
                builder.Property(a => a.ImpuestoFactura).HasColumnType("decimal(8,2)").HasColumnName("ImpuestoFactura");
                builder.Property(a => a.TotalFactura).HasColumnType("decimal(8,2)").HasColumnName("TotalFactura");

                // Campo de IDReserva en EncabezadoFactura
                builder.Property(x => x.IDReserva).IsRequired(true);

                // Relación uno a uno con Reserva
                builder.HasOne(r => r.Reserva)
                    .WithOne()
                    .HasForeignKey<EncabezadoFactura>(r => r.IDReserva)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.NoAction);

                builder.HasOne(r => r.ApplicationUser).WithMany().HasForeignKey(r => r.IDUsuario).IsRequired(true);

                builder.HasOne(ef => ef.CorrelativoSAR)
                   .WithMany(cs => cs.EncabezadoFacturas)
                   .HasForeignKey(ef => ef.IDCorrelativoSAR)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Cascade);

            }
        }
        public class HabitacionConfig : IEntityTypeConfiguration<Habitacion>
        {
            public void Configure(EntityTypeBuilder<Habitacion> builder)
            {
                //llave
                builder.HasKey(x => x.IDHabitacion);

                builder.Property(a => a.Tarifa).HasColumnType("decimal(8,2)").HasColumnName("Tarifa");

                //llave foranea
                builder.HasMany(a => a.Reservas).WithOne(a => a.Habitacion).HasForeignKey(a => a.IDHabitacion);


            }
        }
        public class ReservaConfig : IEntityTypeConfiguration<Reserva>
        {
            public void Configure(EntityTypeBuilder<Reserva> builder)
            {
                //llave
                builder.HasKey(x => x.IDReserva);

                builder.Property(s => s.EstadoReserva).HasColumnType("varchar(255)");

                builder.HasOne(r => r.ApplicationUser).WithMany().HasForeignKey(r => r.IDUsuario).IsRequired(true);

            }
        }
        public class TipoHabitacionConfig : IEntityTypeConfiguration<TipoHabitacion>
        {
            public void Configure(EntityTypeBuilder<TipoHabitacion> builder)
            {
                builder.HasKey(x => x.IDTipoHabitacion);
                builder.Property(x => x.Descripcion).HasColumnType("varchar(255)");
                builder.Property(x => x.DescripcionLarga).HasColumnType("varchar(max)");

                // Llave foranea
                builder.HasMany(a => a.Habitaciones).WithOne(a => a.TipoHabitacion).HasForeignKey(a => a.IDTipoHabitacion);

            }
        }
    }
}
