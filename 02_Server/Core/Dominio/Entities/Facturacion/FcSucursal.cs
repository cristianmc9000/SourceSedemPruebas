using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("fc_sucursal", Schema = "public")]
    public class FcSucursal : AuditableBaseEntity
    {
        [Key]
        public int IdfcSucursal { get; set; }
        public int IdfcEmpresa { get; set; }
        public string DireccionSucursal { get; set; }
        public bool Estado { get; set; }
        public string UbicacionSucursal { get; set; }
        public string Telefono { get; set; }
        public string NombreSucursal { get; set; }
        public bool IdcEstado { get; set; }
        public int? IdArea { get; set; }
        public int? IdfcCufd { get; set; }

    }
}
