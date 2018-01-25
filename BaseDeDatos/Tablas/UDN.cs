using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class UDN : BaseDeDatos
    {
        public DataTable UDNSelect()
        {
            CreateTextCommand("SELECT * FROM UDN");
            return Select();
        }

        public DataTable UDNSelectById(prop.UDN item)
        {
            CreateTextCommand("SELECT * FROM UDN WHERE IdUDN=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        public int UDNDesactivar(prop.UDN item)
        {
            CreateTextCommand("UPDATE UDN SET Visible=? WHERE IdUDN=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        public int UDNUpdate(prop.UDN item)
        {
            CreateTextCommand("UPDATE UDN SET Descripcion=?, Visible=? WHERE IdUDN=? ");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
    }
}
