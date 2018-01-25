using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class ClienteInterno : BaseDeDatos
    {
        public DataTable ClienteInternoSelect()
        {
            CreateTextCommand("SELECT * FROM ClienteInterno ORDER BY Descripcion");
            return Select();
        }

        public DataTable ClienteInternoSelectById(prop.ClienteInterno item)
        {
            CreateTextCommand("SELECT * FROM ClienteInterno WHERE IdCteInt=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        public int ClienteInternoDesactivar(prop.ClienteInterno item)
        {
            CreateTextCommand("UPDATE ClienteInterno SET Visible=? WHERE IdCteInt=?");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        public int ClienteInternoUpdate(prop.ClienteInterno item)
        {
            CreateTextCommand("UPDATE ClienteInterno SET Descripcion=?, Visible=? WHERE IdCteInt=?");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }


    }
}
