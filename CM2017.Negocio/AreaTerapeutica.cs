using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class AreaTerapeutica
    {
        public string _title = "Area Terapeútica";
        public string DataText = "Descripcion";
        public string DataValue = "IdAT";

        BaseDeDatos.Tablas.AreaTerapeutica at = new BaseDeDatos.Tablas.AreaTerapeutica();

        public DataTable AreaTerapeuticaSelect()
        {
            return at.AreaTerapeuticaSelect();
        }

        public DataTable AreaTerapeuticaActivoSelect()
        {
            return at.AreaTerapeuticaActivoSelect();
        }

        public DataTable AreaTerapeuticaSelectById(prop.AreaTerapeutica entidad)
        {
            return at.AreaTerapeuticaSelectById(entidad);
        }

        public int AreaTerapeuticaDesactivar(prop.AreaTerapeutica entidad)
        {
            if (!validarAreaTerapeutica(entidad.Id))
                return at.AreaTerapeuticaDesactivar(entidad);
            else
                return 0;
        }

        public int AreaTerapeuticaUpdate(prop.AreaTerapeutica entidad)
        {
            return at.AreaTerapeuticaUpdate(entidad);
        }

        public bool validarAreaTerapeutica(object idareaterapeutica)
        {
            BaseDeDatos.Tablas.Eventos ev = new BaseDeDatos.Tablas.Eventos();
            return ev.validarAreaTerapeutica(idareaterapeutica);
        }

        public bool AreaTerapeuticaEstatus(object idareaterapeutica)
        {            
            string obtenido = at.AreaTerapeuticaEstatus(idareaterapeutica);
            if (obtenido == "0")
                return false;
            else
                return true;
        }

    }
}
