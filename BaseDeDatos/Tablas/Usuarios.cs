using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class UsuariosEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Activo { get; set; }
        public string Clave { get; set; }
        public string Contrasena { get; set; }
    }
    public class Usuarios
    {
        BaseDeDatos.BaseDeDatos db;

        public DataTable UsuariosSelect()
        {
            db = new BaseDeDatos.BaseDeDatos();
            db.CreateTextCommand("SELECT * FROM ResponsableCM ORDER BY Nombre");
            return db.Select();
        }

        public DataTable UsuariosSelectById(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos();
            db.CreateTextCommand("SELECT * FROM ResponsableCM WHERE IdResCM=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }

        public DataTable UsuariosBuscar(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos();
            db.CreateTextCommand("SELECT * FROM ResponsableCM WHERE Nombre LIKE ? ");
            db.AddParameter("?", "%" + item.Nombre + "%");
            return db.Select();
        }

        public int UsuarioDesactivar(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("UPDATE ResponsableCM SET Activo=? WHERE IdResCM=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

        public string UsuarioInsert(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos();
            db.CreateTextCommand("INSERT INTO ResponsableCM (Nombre, Correo, Clave, Contra, Activo) VALUES (?,?,?,?,?)");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Correo);
            db.AddParameter("?", item.Clave);
            db.AddParameter("?", item.Contrasena);
            db.AddParameter("?", item.Activo.ToString());
            return db.Insert();
        }

        public int UsuarioUpdate(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos();
            db.CreateTextCommand("UPDATE ResponsableCM SET Nombre=?, Correo=?, clave=?, contra=?, Activo=? WHERE IdResCM=? ");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Correo);
            db.AddParameter("?", item.Clave);
            db.AddParameter("?", item.Contrasena);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

    }
}
