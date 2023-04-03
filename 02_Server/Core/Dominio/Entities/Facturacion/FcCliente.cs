using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("fc_cliente", Schema = "public")]
    public class FcCliente : AuditableBaseEntity
    {
        [Key]
        public int IdfcCliente { get; set; }
        public string NitCarnet { get; set; }
        public string Cliente { get; set; }

    }
}
