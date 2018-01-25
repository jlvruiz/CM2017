using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class TipoAudiencia: BaseDeDatos
    {
        public DataTable TipoAudienciaSelect()
        {
            CreateTextCommand("SELECT * FROM Audiencia ORDER BY Descripcion");
            return Select();
        }

        public DataTable TipoAudienciaActivoSelect()
        {
            CreateTextCommand("SELECT * FROM Audiencia WHERE Visible=1");
            return Select();
        }

        public DataTable TipoAudienciaSelectById(prop.TipoAudiencia item)
        {
            CreateTextCommand("SELECT * FROM Audiencia WHERE IdAudiencia=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        public string TipoAudienciaEstatus(object id)
        {
            CreateTextCommand("SELECT visible FROM Audiencia WHERE IdAudiencia=? ");
            AddParameter("?", id);
            return Select().Rows[0][0].ToString();
        }

        public int TipoAudienciaDesactivar(prop.TipoAudiencia item)
        {
            CreateTextCommand("UPDATE Audiencia SET Visible=? WHERE IdAudiencia=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        public int TipoAudienciaUpdate(prop.TipoAudiencia item)
        {
            CreateTextCommand("UPDATE Audiencia SET Descripcion=?, Visible=? WHERE IdAudiencia=? ");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
    }
}
