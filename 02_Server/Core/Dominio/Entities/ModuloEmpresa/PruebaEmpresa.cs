using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Entities
{
    [Table("prueba_empresa", Schema = "public")]
    public class PruebaEmpresa : AuditableBaseEntity
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
    }
}
