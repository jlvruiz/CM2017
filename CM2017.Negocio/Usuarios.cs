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

        public int Responsable { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Contra { get; set; }
        public bool Activo { get; set; }

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

        public DataRow UsuarioSeleccionarPorId()
        {
            us.Idusuario = Responsable;
            return us.UsuarioSeleccionarPorId().Rows[0];
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

        public string UsuarioAgregar()
        {
            us.Nombre = Nombre;
            us.Correo = Correo;
            us.Clave = Clave;
            us.Contra = Contra;
            us.Visible = Activo;
            us.usuarioAgregar();
            return "Listo";
        }

    }
}
