using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilOficios.Entidades
{
    public class Rol
    {
        public int codRol { get; set; }
        public string nomRol { get; set; }
    }
    public class Rolcabecera
    {
        public List<Rol> listaRol { get; set; } = new List<Rol>();
    }
}