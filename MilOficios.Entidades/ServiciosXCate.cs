using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilOficios.Entidades
{
    public class ServiciosXCate
    {
        public int codServicio { get; set; } 
        public string nombre { get; set; }
        public string urlFoto { get; set; }
        public int calificacion { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string estado { get; set; }
        public string descripcionServicio { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }             
    }
    public class ServicioCabecera
    {
        public List<ServiciosXCate> listaServicio { get; set; } = new List<ServiciosXCate>();
    }
}
