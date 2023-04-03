using Dominio.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities
{
    [Table("prueba_persona_pasatiempo", Schema = "public")]
    public class PruebaPerpas : AuditableBaseEntity
    {
        
        public int PersonaIdPersona { get; set; }
        public int PasatiempoIdPasatiempo { get; set; }
        public PruebaPersona Persona { get; set; } = null;
        public PruebaPasatiempo Pasatiempo { get; set; } = null;

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PruebaPerpas>()
        //        .HasKey(pp => new { pp.IdPersona, pp.IdPasatiempo });
        //}
    }
}
