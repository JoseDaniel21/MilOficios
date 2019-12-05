using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilOficios.Entidades
{
    public class Solicitud
    {
        public int codServicio { get; set; }
        public double costo { get; set; }
        public double cotizacion { get; set; }
        public int codUsuario { get; set; }
    }
}
