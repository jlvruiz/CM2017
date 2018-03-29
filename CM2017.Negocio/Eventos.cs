using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class Eventos : Comun
    {
        public string _title = "Eventos";

        public DataTable EventosSelect()
        {
            return ev.EventosSelect();
        }

        public prop.Eventos EventosSeleccionId()
        {
            return ev.EventosSeleccionId();
        }

        public DataTable EventosDesactivadosSelect()
        {
            return ev.EventosDesactivadosSelect();
        }

        public DataTable EventosTerminadosSelect()
        {
            return ev.EventosTerminadosSelect();
        }

        public DataTable EventosSelectById(string id)
        {
            prop.Eventos eventos = new Propiedades.Eventos();
            return ev.EventosSelectById(id);
        }

        public DataTable EventosDetalleSelect(string id)
        {
            return ev.EventosDetalleSelect(id);
        }

        public string EventoInsert(prop.Eventos item)
        {
            return ev.EventoInsert(item);
        }

        public int EventoUpdate(prop.Eventos item)
        {
            return ev.EventoUpdate(item);
        }

        public void EventoDesactivar(string id)
        {
            ev.EventoDesactivar(id);
        }

        public bool EventoReactivar(string id)
        {
            CM2017.Negocio.AreaTerapeutica at = new Negocio.AreaTerapeutica();
            CM2017.Negocio.TipoEvento te = new TipoEvento();
            CM2017.Negocio.TipoAudiencia ta = new TipoAudiencia();

            DataTable dt = new DataTable();
            dt = EventosSelectById(id);

            if (at.AreaTerapeuticaEstatus(dt.Rows[0][16].ToString()) && te.TipoEventoEstatus(dt.Rows[0][5].ToString()) && ta.TipoAudienciaEstatus(dt.Rows[0][9].ToString()))
            {
                ev.EventoReactivar(id);
                return true;
            }
            else
                return false;
        }

        public void TerminarEvento()
        {
            ev.TerminarEvento();
        }

        public DataTable EventosEstadisticas()
        {
            return ev.EventosEstadisticas();
        }

        public int EventosEstadisticasTerminados()
        { 
            return ev.EventosTerminadosSelect().Rows.Count;
        }

        public int EventosEstadisticasCancelados()
        {
            return ev.EventosDesactivadosSelect().Rows.Count;
        }

        public int EventosEstadisticasEnProceso()
        {
            return ev.EventosSelect().Rows.Count;
        }

        

    }
}
