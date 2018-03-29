using System.Web.UI.WebControls;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class GerenteTL : Comun
    {
        public string _title = "Team Leader";

        public DataTable GerentesTLSelect()
        {
            return tl.GerentesTLSelect();
        }

        public DataTable GerentesTLActivoSelect()
        {
            return tl.GerentesTLActivoSelect();
        }

        public DataTable GerenteTLSelectById(prop.TeamLeader item)
        {
            return tl.GerenteTLSelectById(item);
        }

        public int GerenteTLDesactivar(prop.TeamLeader item)
        {
            return tl.GerenteTLDesactivar(item);
        }

        public string GerenteTLInsert(prop.TeamLeader item)
        {
            return tl.GerenteTLInsert(item);
        }

        public int GerenteTLUpdate(prop.TeamLeader item)
        {
            return tl.GerenteTLUpdate(item);
        }

        public void cargarTeamLeader_DropDownList(ref DropDownList dropdownlist)
        {
            Controles.LlenarDropDownList(ref dropdownlist, tl.GerentesTLActivoSelect(), "Nombre", "IdTL");
        }


    }
}
