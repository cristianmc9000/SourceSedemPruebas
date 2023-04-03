using Dominio.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Entities
{
    [Table("prueba_pasatiempo", Schema = "public")]
    public class PruebaPasatiempo : AuditableBaseEntity
    {
        [Key]
        public int IdPasatiempo { get; set; }
        public string Nombre { get; set; }
        public List<PruebaPerpas> PruebaPerpas { get; set; } = new List<PruebaPerpas>();
    }
}
