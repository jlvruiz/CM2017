using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;


namespace BaseDeDatos.Tablas
{
    public class AreaTerapeutica : BaseDeDatos
    {
        public string _cadena = string.Empty;
        public string DataText = "Descripcion";
        public string DataValue = "IdAT";

        public DataTable AreaTerapeuticaSelect()
        {
            CreateTextCommand("SELECT * FROM AreaTerapeutica");
            return Select();
        }
        public DataTable AreaTerapeuticaActivoSelect()
        {
            CreateTextCommand("SELECT * FROM AreaTerapeutica WHERE Visible=1");
            return Select();
        }
        public DataTable AreaTerapeuticaSelectById(prop.AreaTerapeutica entidad)
        {
            CreateTextCommand("SELECT * FROM AreaTerapeutica WHERE IdAT=?");
            AddParameter("?", entidad.Id.ToString());
            return Select();
        }
        public string AreaTerapeuticaEstatus(object id)
        {
            CreateTextCommand("SELECT visible FROM AreaTerapeutica WHERE IdAT=? ");
            AddParameter("?", id);
            return Select().Rows[0][0].ToString();
        }
        public int AreaTerapeuticaDesactivar(prop.AreaTerapeutica entidad)
        {
            CreateTextCommand("UPDATE AreaTerapeutica SET Visible=? WHERE IdAT=? ");
            AddParameter("?", entidad.Activo.ToString());
            AddParameter("?", entidad.Id.ToString());
            return Update();
        }
        public int AreaTerapeuticaUpdate(prop.AreaTerapeutica entidad)
        {
            CreateTextCommand("UPDATE AreaTerapeutica SET Descripcion=?, Visible=? WHERE IdAT=? ");
            AddParameter("?", entidad.Descripcion);
            AddParameter("?", entidad.Activo.ToString());
            AddParameter("?", entidad.Id.ToString());
            return Update();
        }
    }
}
