using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM2017.Propiedades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Activo { get; set; }
        public string Clave { get; set; }
        public string Contrasena { get; set; }
    }
}
