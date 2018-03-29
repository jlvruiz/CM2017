using System.Data;
using System.Web.UI.WebControls;
using prop = CM2017.Propiedades;

namespace ServiciosWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "TeamLeader" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione TeamLeader.svc o TeamLeader.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class TeamLeader : ITeamLeader
    {
        CM2017.Negocio.GerenteTL tl = new CM2017.Negocio.GerenteTL();

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
            CM2017.Negocio.Controles.LlenarDropDownList(ref dropdownlist, tl.GerentesTLActivoSelect(), "Nombre", "IdTL");
        }



    }
}
