using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.ModuloPasatiempo
{
    public class PruebaPasatiempoDto
    {
        public int IdPasatiempo { get; set; }
        public string Nombre { get; set; }
        //public ICollection<PruebaPerpas> Pasatiempos { get; set; }
    }
}
