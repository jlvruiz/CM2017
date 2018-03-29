using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class AreaTerapeutica : Comun
    {
        public string _title = "Area Terapeútica";

        public DataTable AreaTerapeuticaSelect()
        {
            return at.AreaTerapeuticaSelect();
        }

        public DataTable AreaTerapeuticaActivoSelect()
        {
            return at.AreaTerapeuticaSelectActivo();
        }

        public DataTable AreaTerapeuticaSelectById(prop.AreaTerapeutica entidad)
        {
            return at.AreaTerapeuticaSelectById(entidad);
        }

        public int AreaTerapeuticaDesactivar(prop.AreaTerapeutica entidad, ref string nombreevento)
        {
            if (validarAreaTerapeutica(entidad.Id, ref nombreevento))
                return 0;
            else
                return at.AreaTerapeuticaUpdateDesactivar(entidad);
        }

        public int AreaTerapeuticaUpdate(prop.AreaTerapeutica entidad)
        {
            return at.AreaTerapeuticaUpdate(entidad);
        }

        public bool validarAreaTerapeutica(object idareaterapeutica, ref string nombreevento)
        {
            string obtenido = "0";
            DataTable dt = new DataTable();
            dt = ev.validarAreaTerapeutica(idareaterapeutica);
            if (dt.Rows.Count > 0)
                obtenido = dt.Rows[0][0].ToString();
            if (obtenido == idareaterapeutica.ToString())
            {
                nombreevento = dt.Rows[0][1].ToString();
                return true;
            }
            else
                return false;
        }

        public bool AreaTerapeuticaEstatus(object idareaterapeutica)
        {            
            string obtenido = at.AreaTerapeuticaSelectEstatus(idareaterapeutica);
            if (obtenido == "0")
                return false;
            else
                return true;
        }

        public void cargarAreaTerapeutica_RadioButtonList(ref System.Web.UI.WebControls.RadioButtonList radiobuttonlist)
        {
            Controles.LlenarRadioButtonList(ref radiobuttonlist, at.AreaTerapeuticaSelect(), "Descripcion", "IdAT");
        }

    }
}
