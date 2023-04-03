
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Contexts
{
    public class GenericContexDb : DbContext
    {
        public GenericContexDb(DbContextOptions options) : base(options)
        {

        }

        //TODO: Agregar aqui DbSets de las entidades de dominio correspondiente al contexto de conexcion general.

        #region DbSets
        public DbSet<FcCliente> Cliente { get; set; }
        public DbSet<FcSucursal> Sucursal { get; set; }
        public DbSet<PruebaPersona> Persona { get; set; }
        public DbSet<PruebaEmpresa> Empresa { get; set; }
        public DbSet<PruebaPasatiempo> Pasatiempo { get; set; }
        public DbSet<PruebaPerpas> Perpas { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define la clave primaria compuesta
            modelBuilder.Entity<PruebaPerpas>()
                .HasKey(pp => new { pp.PersonaIdPersona, pp.PasatiempoIdPasatiempo });

            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PruebaPerpas>()
        //        .HasKey(e => new { e.IdPersona, e.IdPasatiempo });
        //
        //    modelBuilder.Entity<PruebaPerpas>()
        //        .ToTable("prueba_persona_pasatiempo", schema: "public");
        //
        //}

    }
}
