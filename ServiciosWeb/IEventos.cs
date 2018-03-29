using System.Data;
using System.ServiceModel;
using prop = CM2017.Propiedades;

namespace ServiciosWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEventos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEventos
    {
        [OperationContract]
        DataTable EventosSelect();

        [OperationContract]
        DataTable EventosDesactivadosSelect();

        [OperationContract]
        DataTable EventosTerminadosSelect();

        [OperationContract]
        DataTable EventosSelectById(string id);

        [OperationContract]
        DataTable EventosDetalleSelect(string id);

        [OperationContract]
        string EventoInsert(prop.Eventos item);

        [OperationContract]
        int EventoUpdate(prop.Eventos item);

        [OperationContract]
        void EventoDesactivar(string id);

        [OperationContract]
        bool EventoReactivar(string id);

        [OperationContract]
        void TerminarEvento();
    }
}
