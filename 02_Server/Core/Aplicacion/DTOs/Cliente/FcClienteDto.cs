using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Cliente
{
    public class FcClienteDto
    {
        public int IdfcCliente { get; set; }
        public string NitCarnet { get; set; }
        public string Cliente { get; set; }
        public bool VerDetalle { get; set; }

    }
}
