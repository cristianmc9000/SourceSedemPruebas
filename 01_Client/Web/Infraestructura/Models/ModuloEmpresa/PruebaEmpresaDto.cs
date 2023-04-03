using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.ModuloEmpresa
{
    public class PruebaEmpresaDto
    {

        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Departamento { get; set; }

        public bool VerDetalle { get; set; }
    }
}

