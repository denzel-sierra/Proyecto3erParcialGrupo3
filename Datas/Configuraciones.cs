using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Proyecto3erParcialGrupo3.Models;

namespace Proyecto3erParcialGrupo3.Datas
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
                builder.HasOne(c => c.Usuario).WithMany(u => u.Citas).HasForeignKey(c => c.IDUsuario);

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

                builder.Property(s => s.NumeroCAI).HasColumnType("varchar(255)");
                builder.Property(a => a.PrecioUnitario).HasColumnType("decimal(8,2)").HasColumnName("PrecioUnitario");
                builder.Property(a => a.SubTotalLinea).HasColumnType("decimal(8,2)").HasColumnName("SubTotalLinea");
                //llave foranea
                builder.HasOne(c => c.EncabezadoFactura).WithMany(u => u.DetalleProductoFacturas).HasForeignKey(c => c.IDFactura);
                builder.HasOne(c => c.Producto).WithMany(u => u.DetalleProductoFacturas).HasForeignKey(c => c.IDProducto);

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
                //llave foranea
                builder.HasOne(c => c.EncabezadoFactura).WithMany(u => u.DetalleServicioFacturas).HasForeignKey(c => c.IDFactura);
                builder.HasOne(c => c.ServicioHotel).WithMany(u => u.DetalleServicioFacturas).HasForeignKey(c => c.IDServicio);

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
                builder.HasOne(c => c.CorrelativoSAR).WithMany(u => u.EncabezadoFacturas).HasForeignKey(c => c.IDCorrelativoSAR);
                builder.HasOne(c => c.Usuario).WithMany(u => u.EncabezadoFacturas).HasForeignKey(c => c.IDUsuario);

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
                //llave foranea
                builder.HasOne(c => c.Usuario).WithMany(u => u.Reservas).HasForeignKey(c => c.IDUsuario);
                builder.HasOne(c => c.Habitacion).WithMany(u => u.Reservas).HasForeignKey(c => c.IDHabitacion);
                builder.HasOne(c => c.EncabezadoFactura).WithMany(u => u.Reservas).HasForeignKey(c => c.IDFactura);


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
        public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
        {
            public void Configure(EntityTypeBuilder<Usuario> builder)
            {
                //llave
                builder.HasKey(x => x.IDUsuario);

                builder.Property(s => s.Rol).HasColumnType("varchar(255)");
                builder.Property(s => s.Nombre).HasColumnType("varchar(255)");
                builder.Property(s => s.Direccion).HasColumnType("varchar(255)");
                builder.Property(s => s.CorreoElectronico).HasColumnType("varchar(255)");
                builder.Property(s => s.NumeroTelefono).HasColumnType("varchar(255)");
                builder.Property(s => s.NombreUsuario).HasColumnType("varchar(255)");
                builder.Property(s => s.Contraseña).HasColumnType("varchar(255)");


            }
        }
    }
