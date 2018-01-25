using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Usuarios : BaseDeDatos
    {
        public DataTable UsuariosSelect()
        {
            CreateTextCommand("SELECT * FROM ResponsableCM ORDER BY Nombre");
            return Select();
        }

        public DataTable UsuariosSelectById(prop.Usuarios item)
        {
            CreateTextCommand("SELECT * FROM ResponsableCM WHERE IdResCM=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        public DataTable UsuariosBuscar(prop.Usuarios item)
        {
            CreateTextCommand("SELECT * FROM ResponsableCM WHERE Nombre LIKE ? ");
            AddParameter("?", "%" + item.Nombre + "%");
            return Select();
        }

        public string UsuarioInsert(prop.Usuarios item)
        {
            CreateTextCommand("INSERT INTO ResponsableCM (Nombre, Correo, Clave, Contra, Activo) VALUES (?,?,?,?,?)");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Correo);
            AddParameter("?", item.Clave);
            AddParameter("?", item.Contrasena);
            AddParameter("?", item.Activo.ToString());
            return Insert();
        }

        public int UsuarioDesactivar(prop.Usuarios item)
        {
            CreateTextCommand("UPDATE ResponsableCM SET Activo=? WHERE IdResCM=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        public int UsuarioUpdate(prop.Usuarios item)
        {
            CreateTextCommand("UPDATE ResponsableCM SET Nombre=?, Correo=?, clave=?, contra=?, Activo=? WHERE IdResCM=? ");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Correo);
            AddParameter("?", item.Clave);
            AddParameter("?", item.Contrasena);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

    }
}
