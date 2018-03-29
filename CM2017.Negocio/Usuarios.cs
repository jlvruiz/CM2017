using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class Usuarios : Comun
    {
        public string _title = "Usuarios";

        public DataTable UsuariosSelect()
        {
            return us.UsuariosSelect();
        }
        public List<prop.Usuarios> UsuariosSeleccion()
        {
            return us.UsuariosSeleccion();
        }

        public DataTable UsuariosSelectById(prop.Usuarios item)
        {
            return us.UsuariosSelectById(item);
        }

        public DataTable UsuariosBuscar(prop.Usuarios item)
        {
            return us.UsuariosBuscar(item);
        }

        public int UsuarioDesactivar(prop.Usuarios item)
        {
            return us.UsuarioDesactivar(item);
        }

        public string UsuarioInsert(prop.Usuarios item)
        {
            return us.UsuarioInsert(item);
        }

        public int UsuarioUpdate(prop.Usuarios item)
        {
            return us.UsuarioUpdate(item);
        }

    }
}
