using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilOficios.Entidades
{
    public class Servicio
    {
        public int CodUsuario { get; set; }
        public string Descripcion  { get; set; }
        public string FechaFin { get; set; }
        public int CodCategoria { get; set; }
        public int codLocalizacion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
}
