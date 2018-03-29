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
    public class Divisiones : BaseDeDatos
    {
        public DataTable DivisionesSelect()
        {
            CreateTextCommand("SELECT IdDivision, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Divisiones");
            return Select();
        }
        public DataTable DivisionesActivoSelect()
        {
            CreateTextCommand("SELECT IdDivision, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Divisiones WHERE Visible=1");
            return Select();
        }
        public DataTable DivisionesSelectById(prop.Divisiones item)
        {
            CreateTextCommand("SELECT IdDivision, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Divisiones WHERE IdDivision=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }
        public int DivisionDesactivar(prop.Divisiones item)
        {
            CreateTextCommand("UPDATE Divisiones SET Visible=? WHERE IdDivision=? ");
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }
        public int DivisionUpdate(prop.Divisiones item)
        {
            CreateTextCommand("UPDATE Divisiones SET Descripcion=?, Visible=? WHERE IdDivision=? ");
            AddParameter("?", item.Descripcion, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }


    }
}
