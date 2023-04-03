using Dominio.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Dominio.Entities
{
	[Table("prueba_persona", Schema = "public")]
	public class PruebaPersona : AuditableBaseEntity
	{
		[Key]
		public int IdPersona { get; set; }
		public string FechaNacimiento { get; set; }
		public string LugarNacimiento { get; set; }
		public int IdEmpresa { get; set; }
		public string Nombres { get; set; }
		public string Paterno { get; set; }
		public string Materno { get; set; }
		public List<PruebaPerpas> PruebaPerpas { get; set; } = new List<PruebaPerpas>();

	}
}
