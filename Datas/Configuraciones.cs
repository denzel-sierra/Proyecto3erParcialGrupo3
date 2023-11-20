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
    }
}
