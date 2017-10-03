using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class GerentesEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Activo { get; set; }
    }
    public class Gerentes
    {
        public string _cadena = string.Empty;

        public Gerentes(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public DataTable GerentesSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Gerentes order by Nombre");
            return db.Select();
        }
        public DataTable GerentesActivoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Gerentes where Activo=1");
            return db.Select();
        }
        public DataTable GerentesSelectById(GerentesEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Gerentes where IdGerente=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }
        public int GerenteDesactivar(GerentesEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Gerentes set Activo=? where IdGerente=?");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
        public string GerenteInsert(GerentesEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("insert into Gerentes (Nombre, Correo, Activo) values (?,?,?)");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Correo);
            db.AddParameter("?", item.Activo.ToString());
            return db.Insert();
        }
        public int GerenteUpdate(GerentesEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Gerentes set Nombre=?, Correo=?, Activo=? where IdGerente=?");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Correo);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }


    }
}
