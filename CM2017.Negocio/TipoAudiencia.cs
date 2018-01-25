using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class TipoAudiencia
    {
        public string _title = "Tipo de Audiencia";

        BaseDeDatos.Tablas.TipoAudiencia ta = new BaseDeDatos.Tablas.TipoAudiencia();

        public DataTable TipoAudienciaSelect()
        {
            return ta.TipoAudienciaSelect();
        }

        public DataTable TipoAudienciaActivoSelect()
        {
            return ta.TipoAudienciaActivoSelect();
        }

        public DataTable TipoAudienciaSelectById(prop.TipoAudiencia item)
        {
            return ta.TipoAudienciaSelectById(item);
        }

        public int TipoAudienciaDesactivar(prop.TipoAudiencia item)
        {
            if (validarTipoAudiencia(item.Id))
                return ta.TipoAudienciaDesactivar(item);
            else
                return 0;
        }

        public int TipoAudienciaUpdate(prop.TipoAudiencia item)
        {
            return ta.TipoAudienciaUpdate(item);
        }

        public bool validarTipoAudiencia(object idtipoaudiencia)
        {
            BaseDeDatos.Tablas.Eventos ev = new BaseDeDatos.Tablas.Eventos();
            return ev.validarAudiencia(idtipoaudiencia);
        }

        public bool TipoAudienciaEstatus(object id)
        {
            string obtenido = ta.TipoAudienciaEstatus(id);
            if (obtenido == "0")
                return false;
            else
                return true;
        }



    }
}
