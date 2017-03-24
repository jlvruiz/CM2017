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
        public string _cadena = string.Empty; 

        public Usuarios(string cadena)
        {
            _cadena = cadena;
        }
        
        BaseDeDatos.BaseDeDatos db;

        public DataTable UsuariosSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from ResponsableCM order by Nombre");
            return db.Select();
        }

        public DataTable UsuariosSelectById(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from ResponsableCM where IdResCM=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }

        public int UsuarioDesactivar(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update ResponsableCM set Activo=? where IdResCM=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

        public string UsuarioInsert(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("insert into ResponsableCM (Nombre, Correo, Clave, Contra, Activo) values (?,?,?,?,?)");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Correo);
            db.AddParameter("?", item.Clave);
            db.AddParameter("?", item.Contrasena);
            db.AddParameter("?", item.Activo.ToString());
            return db.Insert();
        }

        public int UsuarioUpdate(UsuariosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update ResponsableCM set Nombre=?, Correo=?, clave=?, contra=?, Activo=? where IdResCM=? ");
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
