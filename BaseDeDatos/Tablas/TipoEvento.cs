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
    public class TipoEvento : BaseDeDatos
    {
        public DataTable TipoEventoSelect()
        {
            CreateTextCommand("SELECT IdTipEve, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM TipoEvento ORDER BY descripcion");
            return Select();
        }

        public DataTable TipoEventoActivoSelect()
        {
            CreateTextCommand("SELECT IdTipEve, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM TipoEvento WHERE Visible=1 ORDER BY descripcion");
            return Select();
        }

        public DataTable TipoEventoSelectById(prop.TipoEvento item)
        {
            CreateTextCommand("SELECT IdTipEve, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM TipoEvento WHERE IdTipEve=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }

        public string TipoEventoEstatus(object id)
        {
            CreateTextCommand("SELECT visible FROM TipoEvento WHERE IdTipEve=? ");
            AddParameter("?", id, OleDbType.Numeric);
            return Select().Rows[0][0].ToString();
        }

        public string TipoEventoInsert(prop.TipoEvento item)
        {
            CreateTextCommand("INSERT INTO tipoevento (Descripcion, Visible) VALUES (?,?)");
            AddParameter("?", item.Descripcion, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            return Insert();
        }

        public int TipoEventoUpdate(prop.TipoEvento item)
        {
            CreateTextCommand("UPDATE TipoEvento SET Descripcion=?, Visible=? WHERE IdTipEve=? ");
            AddParameter("?", item.Descripcion, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        public int TipoEventoDesactivar(prop.TipoEvento item)
        {
            CreateTextCommand("UPDATE TipoEvento SET Visible=? WHERE IdTipEve=? ");
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

    }
}
