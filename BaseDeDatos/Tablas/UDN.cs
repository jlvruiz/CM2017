using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class UDN : BaseDeDatos
    {
        public DataTable UDNSelect()
        {
            CreateTextCommand("SELECT IdUDN, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM UDN");
            return Select();
        }

        public DataTable UDNSelectById(prop.UDN item)
        {
            CreateTextCommand("SELECT IdUDN, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM UDN WHERE IdUDN=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }

        public int UDNDesactivar(prop.UDN item)
        {
            CreateTextCommand("UPDATE UDN SET Visible=? WHERE IdUDN=? ");
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        public int UDNUpdate(prop.UDN item)
        {
            CreateTextCommand("UPDATE UDN SET Descripcion=?, Visible=? WHERE IdUDN=? ");
            AddParameter("?", item.Descripcion, OleDbType.VarChar, 255);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }
    }
}
