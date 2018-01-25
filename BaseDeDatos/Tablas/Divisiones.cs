using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Divisiones : BaseDeDatos
    {
        public DataTable DivisionesSelect()
        {
            CreateTextCommand("SELECT * FROM Divisiones");
            return Select();
        }
        public DataTable DivisionesActivoSelect()
        {
            CreateTextCommand("SELECT * FROM Divisiones WHERE Visible=1");
            return Select();
        }
        public DataTable DivisionesSelectById(prop.Divisiones item)
        {
            CreateTextCommand("SELECT * FROM Divisiones WHERE IdDivision=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }
        public int DivisionDesactivar(prop.Divisiones item)
        {
            CreateTextCommand("UPDATE Divisiones SET Visible=? WHERE IdDivision=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
        public int DivisionUpdate(prop.Divisiones item)
        {
            CreateTextCommand("UPDATE Divisiones SET Descripcion=?, Visible=? WHERE IdDivision=? ");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }


    }
}
