using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities.Seguridad
{

    [Table("gen_clasificador", Schema ="public")]
    public class GenClasificador : AuditableBaseEntity 
    {
        [Key]
        public int IdgenClasificador { get; set; }
        public string Descripcion { get; set; }

    }
}
