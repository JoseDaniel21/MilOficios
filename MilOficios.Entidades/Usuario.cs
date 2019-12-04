using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilOficios.Entidades
{
    public class Usuario
    {
        public int codUsuario { get; set; }
        public int idRol { get; set; }
        public string  nomRol { get; set; }
        public string contrasenia { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }
        public int activo { get; set; }
        public int eliminado { get; set; }
        public int telefono { get; set; }
        public int ubicacion { get; set; }
        public int latitud { get; set; }
        public int longitud { get; set; }
        public string urlFoto { get; set; }
        public string fechaNacimiento { get; set; }
    }
    public class UserAPi
    {
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public Boolean isActivo { get; set; }
        public Boolean isEliminado { get; set; }
        public string Fecha { get; set; }
        public string telefono { get; set; }
        public int TipoUsuario { get; set; }
        public int Localizacion { get; set; }
    }
}
