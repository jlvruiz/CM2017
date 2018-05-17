using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class ClienteInterno : BaseDeDatos
    {
        public DataTable ClienteInternoSelect()
        {
            CreateTextCommand("SELECT IdCteInt, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM ClienteInterno ORDER BY Descripcion");
            return Select();
        }

        public DataTable ClienteInternoSelectById(prop.ClienteInterno item)
        {
            CreateTextCommand("SELECT IdCteInt, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM ClienteInterno WHERE IdCteInt=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }

        public int ClienteInternoDesactivar(prop.ClienteInterno item)
        {
            CreateTextCommand("UPDATE ClienteInterno SET Visible=? WHERE IdCteInt=?");
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        public int ClienteInternoUpdate(prop.ClienteInterno item)
        {
            CreateTextCommand("UPDATE ClienteInterno SET Descripcion=?, Visible=? WHERE IdCteInt=?");
            AddParameter("?", item.Descripcion, OleDbType.VarChar, 255);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }
    }
}
