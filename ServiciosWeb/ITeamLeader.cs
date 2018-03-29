using System.Data;
using System.Web.UI.WebControls;
using System.ServiceModel;
using prop = CM2017.Propiedades;

namespace ServiciosWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITeamLeader" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITeamLeader
    {
        [OperationContract]
        DataTable GerentesTLSelect();

        [OperationContract]
        DataTable GerentesTLActivoSelect();

        [OperationContract]
        DataTable GerenteTLSelectById(prop.TeamLeader item);

        [OperationContract]
        int GerenteTLDesactivar(prop.TeamLeader item);

        [OperationContract]
        string GerenteTLInsert(prop.TeamLeader item);

        [OperationContract]
        int GerenteTLUpdate(prop.TeamLeader item);

        [OperationContract]
        void cargarTeamLeader_DropDownList(ref DropDownList dropdownlist);

    }
}
