using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class LocalizacionEntity
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public int Tipo { get; set; }
        public string Motivo { get; set; }
        public int Activo { get; set; }
    }
    public class Localizacion
    {
        public string _cadena = string.Empty;

        public Localizacion(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public DataTable LocalizacionesSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Localizacion order by Nombre");
            return db.Select();
        }
        public DataTable LocalizacionesActivoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Localizacion where Visible=1");
            return db.Select();
        }
        public DataTable LocalizacionSelectById(LocalizacionEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Localizacion where IdLoc=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }

        public int LocalizacionDesactivar(LocalizacionEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Localizacion set Visible=? where IdLoc=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

        public string LocalizacionInsert(LocalizacionEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("insert into Localizacion (Nombre,Tipo,Motivo,Visible) values (?,?,?,?)");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Tipo.ToString());
            db.AddParameter("?", item.Motivo);
            db.AddParameter("?", item.Activo.ToString());
            return db.Insert();
        }

        public int LocalizacionUpdate(LocalizacionEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Localizacion set Nombre=?, Tipo=?, Motivo=?, Visible=? where IdLoc=? ");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Tipo.ToString());
            db.AddParameter("?", item.Motivo);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
    }
}
