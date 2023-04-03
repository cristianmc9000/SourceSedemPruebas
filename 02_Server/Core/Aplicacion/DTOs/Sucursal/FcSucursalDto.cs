using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Sucursal
{
    public class FcSucursalDto
    {
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
        public bool VerDetalle { get; set; }
    }
    
}
