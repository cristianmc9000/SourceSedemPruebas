using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.ModuloPersona
{
	public class PruebaPersonaDto
	{
		public int IdPersona { get; set; }
		public string FechaNacimiento { get; set; }
		public string LugarNacimiento { get; set; }
		public int IdEmpresa { get; set; }
		[StringLength(maximumLength: 10)]
		public string Nombres { get; set; }
        [StringLength(maximumLength: 10)]
        public string Paterno { get; set; }
        [StringLength(maximumLength: 10)]
        public string Materno { get; set; } = null!;
        //public ICollection<PruebaPerpas> Pasatiempos { get; set; }
    }
}
