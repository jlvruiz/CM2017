using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM2017.Propiedades;
using System.Collections;
using System.Web.UI;

namespace CM2017.IU
{
    public class ManejadorSesion
    {
        Usuarios _usuarios;

        public Usuarios Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }

        public void ActualizarSesion()
        {
            Hashtable informacion = new Hashtable();
            Page _Pagina = new Page();
            informacion.Add("Usuario", _usuarios);
            _Pagina.Session.Add("Informacion", informacion);
        }

        public void DescargarSesion()
        {
            Hashtable informacion = new Hashtable();
            Page _Pagina = new Page();
            _usuarios = (Usuarios)informacion["Usuario"];
        }


    }
}
