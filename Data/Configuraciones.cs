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
        public class DetalleProductoFacturaConfig : IEntityTypeConfiguration<DetalleProductoFactura>
        {
            public void Configure(EntityTypeBuilder<DetalleProductoFactura> builder)
            {
                //llave
                builder.HasKey(x => x.IDDetalleFactura);
                builder.Property(a => a.PrecioUnitario).HasColumnType("decimal(8,2)").HasColumnName("PrecioUnitario");
                builder.Property(a => a.SubTotalLinea).HasColumnType("decimal(8,2)").HasColumnName("SubTotalLinea");
            }
        }
        public class DetalleServicioFacturaConfig : IEntityTypeConfiguration<DetalleServicioFactura>
        {
            public void Configure(EntityTypeBuilder<DetalleServicioFactura> builder)
            {
                //llave
                builder.HasKey(x => x.IDDetalleFactura);

                builder.Property(a => a.PrecioUnitario).HasColumnType("decimal(8,2)").HasColumnName("PrecioUnitario");
                builder.Property(a => a.SubTotalLinea).HasColumnType("decimal(8,2)").HasColumnName("SubTotalLinea");

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

                //llave foranea
                builder.HasMany(a => a.Reservas).WithOne(a => a.EncabezadoFactura).HasForeignKey(a => a.IDFactura);
                builder.HasMany(a => a.DetalleProductoFacturas).WithOne(a => a.EncabezadoFactura).HasForeignKey(a => a.IDFactura);
                builder.HasMany(a => a.DetalleServicioFacturas).WithOne(a => a.EncabezadoFactura).HasForeignKey(a => a.IDFactura);
                builder.HasOne(r => r.ApplicationUser).WithMany().HasForeignKey(r => r.IDUsuario).IsRequired(true);

            }
        }
        public class HabitacionConfig : IEntityTypeConfiguration<Habitacion>
        {
            public void Configure(EntityTypeBuilder<Habitacion> builder)
            {
                //llave
                builder.HasKey(x => x.IDHabitacion);

                builder.Property(s => s.TipoHabitacion).HasColumnType("varchar(255)");
                builder.Property(s => s.Descripcion).HasColumnType("varchar(255)");
                builder.Property(a => a.Tarifa).HasColumnType("decimal(8,2)").HasColumnName("Tarifa");

                //llave foranea
                builder.HasMany(a => a.Reservas).WithOne(a => a.Habitacion).HasForeignKey(a => a.IDHabitacion);


            }
        }
        public class ProductoConfig : IEntityTypeConfiguration<Producto>
        {
            public void Configure(EntityTypeBuilder<Producto> builder)
            {
                //llave
                builder.HasKey(x => x.IDProducto);

                builder.Property(s => s.NombreProducto).HasColumnType("varchar(255)");
                builder.Property(s => s.Descripcion).HasColumnType("varchar(255)");
                builder.Property(a => a.PrecioUnitario).HasColumnType("decimal(8,2)").HasColumnName("PrecioUnitario");

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
        public class ServicioHotelConfig : IEntityTypeConfiguration<ServicioHotel>
        {
            public void Configure(EntityTypeBuilder<ServicioHotel> builder)
            {
                //llave
                builder.HasKey(x => x.IDServicio);

                builder.Property(s => s.NombreServicio).HasColumnType("varchar(255)");
                builder.Property(s => s.Descripcion).HasColumnType("varchar(255)");
                builder.Property(a => a.Tarifa).HasColumnType("decimal(8,2)").HasColumnName("Tarifa");

            }
        }
    }
}
