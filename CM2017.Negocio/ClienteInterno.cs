using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class ClienteInternoEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }

    public class ClienteInterno
    {
        public string _cadena = string.Empty;

        public ClienteInterno(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public DataTable ClienteInternoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from ClienteInterno order by Descripcion");
            return db.Select();
        }

        public DataTable ClienteInternoSelectById(ClienteInternoEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from ClienteInterno where IdCteInt=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }

        public int ClienteInternoDesactivar(ClienteInternoEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update ClienteInterno set Visible=? where IdCteInt=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

        public int ClienteInternoUpdate(ClienteInternoEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update ClienteInterno set Descripcion=?, Visible=? where IdCteInt=? ");
            db.AddParameter("?", item.Descripcion);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }


    }
}
