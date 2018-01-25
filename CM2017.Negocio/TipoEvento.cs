using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class TipoEvento
    {
        public string _title = "Tipo de Evento";

        BaseDeDatos.Tablas.TipoEvento te = new BaseDeDatos.Tablas.TipoEvento();

        public DataTable TipoEventoSelect()
        {
            return te.TipoEventoSelect();
        }

        public DataTable TipoEventoActivoSelect()
        {
            return te.TipoEventoActivoSelect();
        }

        public DataTable TipoEventoSelectById(prop.TipoEvento item)
        {
            return te.TipoEventoSelectById(item);
        }

        public string TipoEventoInsert(prop.TipoEvento item)
        {
            return te.TipoEventoInsert(item);
        }

        public int TipoEventoUpdate(prop.TipoEvento item)
        {
            return te.TipoEventoUpdate(item);
        }

        public int TipoEventoDesactivar(prop.TipoEvento item)
        {
            if (!validarTipoEvento(item.Id))
                return te.TipoEventoDesactivar(item);
            else
                return 0;
        }

        public bool validarTipoEvento(object idtipoevento)
        {
            BaseDeDatos.Tablas.Eventos ev = new BaseDeDatos.Tablas.Eventos();
            return ev.validarTipoEvento(idtipoevento);
        }

        public bool TipoEventoEstatus(object id)
        {
            string obtenido = te.TipoEventoEstatus(id);
            if (obtenido == "0")
                return false;
            else
                return true;
        }

    }
}
