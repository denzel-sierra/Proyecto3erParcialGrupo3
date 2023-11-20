using Proyecto3erParcialGrupo3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto3erParcialGrupo3.Models;

namespace Proyecto3erParcialGrupo3.Data
{
    public class Configuraciones
    {
        // Configuraciones de Usuarios
        public class UsuariosConfig : IEntityTypeConfiguration<Usuario>
        {
            public void Configure(EntityTypeBuilder<Usuario> builder)
            {
                // Elementos de Usuario
                //
                //--- Llave Primaria
                builder.HasKey(x => x.UsuarioId);
                //--- Relaciones
                //   |
                //   |--- Taxis
                builder.HasMany(a => a.Taxis).WithOne(a => a.Usuario).HasForeignKey(a => a.UsuarioId);
                //--- Placa
                builder.Property(a => a.NombreUsuario).HasColumnType("varchar(20)").HasColumnName("Usuario");
                //--- Observacion
                builder.Property(a => a.Contraseña).HasColumnType("varchar(20)").HasColumnName("Contraseña");
            }
        }

        // Configuraciones de Taxis
        public class TaxisConfig : IEntityTypeConfiguration<Taxi>
        {
            public void Configure(EntityTypeBuilder<Taxi> builder)
            {
                // Elementos de Taxi
                //
                //--- Llave Primaria
                builder.HasKey(x => x.TaxiId);
                //--- Relaciones
                //   |
                //   |--- Registros Diarios
                builder.HasMany(a => a.RegistrosDiarios).WithOne(a => a.Taxi).HasForeignKey(a => a.TaxiId);
                //--- Placa
                builder.Property(a => a.Placa).HasColumnType("varchar(8)").HasColumnName("Placa");
                //--- Observacion
                builder.Property(a => a.Observacion).HasColumnType("varchar(255)").HasColumnName("Observacion");
            }
        }

        // Configuraciones de Registros Diarios
        public class RegistrosDiariosConfig : IEntityTypeConfiguration<RegistroDiario>
        {

            public void Configure(EntityTypeBuilder<RegistroDiario> builder)
            {
                // Elementos de los Registros
                //
                //--- Llave Primaria
                builder.HasKey(x => x.RegistroId);
                //--- TotalDia
                builder.Property(a => a.TotalDia).HasColumnType("decimal(8,2)").HasColumnName("TotalDia");
                //--- PagoBase
                builder.Property(a => a.PagoBase).HasColumnType("decimal(8,2)").HasColumnName("PagoBase");
                //--- PagoConductor
                builder.Property(a => a.PagoConductor).HasColumnType("decimal(8,2)").HasColumnName("PagoConductor");
                //--- PagoDueño
                builder.Property(a => a.PagoDueño).HasColumnType("decimal(8,2)").HasColumnName("PagoDueño");
                //--- Gastos
                builder.Property(a => a.Gastos).HasColumnType("decimal(8,2)").HasColumnName("Gastos");
                //--- Observacion
                builder.Property(a => a.Observacion).HasColumnType("varchar(255)").HasColumnName("Observacion");
            }
        }
    }
}
