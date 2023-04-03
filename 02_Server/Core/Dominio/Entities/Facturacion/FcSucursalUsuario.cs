using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("fc_sucursal_usuario", Schema = "public")]
    public class FcSucursalUsuario : AuditableBaseEntity
    {
        [Key]
        public int IdfcSucursalUsuario { get; set; }
        public int? IdfcUsuario { get; set; }
        public int? IdfcSucursal { get; set; }
        public bool Estado { get; set; }
    }
}
