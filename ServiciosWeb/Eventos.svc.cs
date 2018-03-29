using System.Data;
using prop = CM2017.Propiedades;

namespace ServiciosWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Eventos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Eventos.svc o Eventos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Eventos : IEventos
    {
        CM2017.Negocio.Eventos eventos = new CM2017.Negocio.Eventos();

        public DataTable EventosSelect()
        {
            return eventos.EventosSelect();
        }

        public DataTable EventosDesactivadosSelect()
        {
            return eventos.EventosDesactivadosSelect();
        }

        public DataTable EventosTerminadosSelect()
        {
            return eventos.EventosTerminadosSelect();
        }

        public DataTable EventosSelectById(string id)
        {
            return eventos.EventosSelectById(id);
        }

        public DataTable EventosDetalleSelect(string id)
        {
            return eventos.EventosDetalleSelect(id);
        }

        public string EventoInsert(prop.Eventos item)
        {
            return eventos.EventoInsert(item);
        }

        public int EventoUpdate(prop.Eventos item)
        {
            return eventos.EventoUpdate(item);
        }

        public void EventoDesactivar(string id)
        {
            eventos.EventoDesactivar(id);
        }

        public bool EventoReactivar(string id)
        {
            return eventos.EventoReactivar(id);
        }

        public void TerminarEvento()
        {
            eventos.TerminarEvento();
        }
    }
}
