using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.ModuloPersona
{
	public class PruebaPersonaDto
	{
		public int IdPersona { get; set; }

        //[Required(ErrorMessage = "Este campo es obligatorio")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string LugarNacimiento { get; set; }

        //[Required(ErrorMessage = "Este campo es obligatorio")]
        [EmpresaSeleccionada(ErrorMessage = "Debe seleccionar una empresa")]
        public int IdEmpresa { get; set; }
		[Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(10, ErrorMessage = "El nombre debe tener como máximo 10 caracteres")]
        [RegularExpression("^[A-Za-z ÑñÁáÉéÍíÓóÚú]+$", ErrorMessage = "Este campo solo acepta letras.")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(10, ErrorMessage = "El nombre debe tener como máximo 10 caracteres")]
        public string Paterno { get; set; }
        [StringLength(10, ErrorMessage = "El nombre debe tener como máximo 10 caracteres")]
		public string Materno { get; set; }
		public bool VerDetalle { get; set; }
        //public List<string> Pasatiempos { get; set; } = new List<string>();
        public IEnumerable<string> Pasatiempos { get; set; } = new List<string>();
        //public List<int> Pasatiempos { get; set; } = new List<int>();


    }
    public class EmpresaSeleccionadaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int idEmpresa = (int)value;
            return idEmpresa > 0;
        }
    }
}
