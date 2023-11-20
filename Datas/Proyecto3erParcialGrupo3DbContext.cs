using Microsoft.EntityFrameworkCore;
using Proyecto3erParcialGrupo3.Models;
using static Proyecto3erParcialGrupo3.Data.Configuraciones;
using static Proyecto3erParcialGrupo3.Datas.Configuraciones;

namespace Proyecto3erParcialGrupo3.Data
{
    public class DbTaxisDbContext : DbContext
    {
        // Constructor
        public DbTaxisDbContext(DbContextOptions<DbTaxisDbContext> options) : base(options) { }

        // Entidades
        //
        //--- Usuarios
        public DbSet<Usuario> Usuarios { get; set; }
        //--- Taxis
        public DbSet<Taxi> Taxi { get; set; }
        //--- Departamentos
        public DbSet<RegistroDiario> RegistroDiario { get; set; }

        // Configuraciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Usuarios
            modelBuilder.ApplyConfiguration(new UsuariosConfig());
            // Taxis
            modelBuilder.ApplyConfiguration(new TaxisConfig());
            // RegistrosDiarios
            modelBuilder.ApplyConfiguration(new RegistrosDiariosConfig());
        }
    }
}
