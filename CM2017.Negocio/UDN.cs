using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class UDNEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class UDN
    {
        public string _cadena = string.Empty;

        public UDN(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public DataTable UDNSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from UDN");
            return db.Select();
        }
        public DataTable UDNSelectById(UDNEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from UDN where IdUDN=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }
        public int UDNDesactivar(UDNEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update UDN set Visible=? where IdUDN=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
        public int UDNUpdate(UDNEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update UDN set Descripcion=?, Visible=? where IdUDN=? ");
            db.AddParameter("?", item.Descripcion);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
    }
}
