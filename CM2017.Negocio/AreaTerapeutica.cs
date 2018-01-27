using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class AreaTerapeutica
    {
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
        public DataTable AreaTerapeuticaSelectById(AreaTerapeuticaEntity entidad)
        {
            return at.AreaTerapeuticaSelectById(entidad);
        }
        public int AreaTerapeuticaDesactivar(AreaTerapeuticaEntity entidad)
        {
            return at.AreaTerapeuticaDesactivar(entidad);
        }
        public int AreaTerapeuticaUpdate(AreaTerapeuticaEntity entidad)
        {
            return at.AreaTerapeuticaUpdate(entidad);
        }
    }
}
