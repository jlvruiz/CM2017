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
        BaseDeDatos.BaseDeDatos db = new BaseDeDatos.BaseDeDatos("");

        public DataTable LocalizacionesSelect()
        {
            db.CreateTextCommand("select * from Localizacion order by Nombre");
            return db.Select();
        }
        public DataTable LocalizacionesActivoSelect()
        {
            db.CreateTextCommand("select * from Localizacion where Visible=1");
            return db.Select();
        }
        public DataTable LocalizacionSelectById(LocalizacionEntity item)
        {
            db.CreateTextCommand("select * from Localizacion where IdLoc=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }

        public int LocalizacionDesactivar(LocalizacionEntity item)
        {
            db.CreateTextCommand("update Localizacion set Visible=? where IdLoc=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

        public string LocalizacionInsert(LocalizacionEntity item)
        {
            db.CreateTextCommand("insert into Localizacion (Nombre,Tipo,Motivo,Visible) values (?,?,?,?)");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Tipo.ToString());
            db.AddParameter("?", item.Motivo);
            db.AddParameter("?", item.Activo.ToString());
            return db.Insert();
        }

        public int LocalizacionUpdate(LocalizacionEntity item)
        {
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
