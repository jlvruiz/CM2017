using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class TipoEventoEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class TipoEvento
    {
        public string _cadena = string.Empty;

        public TipoEvento(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public DataTable TipoEventoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from TipoEvento order by descripcion");
            return db.Select();
        }
        public DataTable TipoEventoActivoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from TipoEvento where Visible=1 order by descripcion");
            return db.Select();
        }
        public DataTable TipoEventoSelectById(TipoEventoEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from TipoEvento where IdTipEve=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }
        public int TipoEventoDesactivar(TipoEventoEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update TipoEvento set Visible=? where IdTipEve=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
        public int TipoEventoUpdate(TipoEventoEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update TipoEvento set Descripcion=?, Visible=? where IdTipEve=? ");
            db.AddParameter("?", item.Descripcion);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
    }
}
