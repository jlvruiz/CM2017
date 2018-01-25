using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class Localizacion
    {
        public string _title = "Localización";

        BaseDeDatos.Tablas.Localizacion lo = new BaseDeDatos.Tablas.Localizacion();

        public DataTable LocalizacionesSelect()
        {
            return lo.LocalizacionesSelect();
        }

        public DataTable LocalizacionesActivoSelect()
        {
            return lo.LocalizacionesActivoSelect();
        }

        public DataTable LocalizacionSelectById(prop.Localizacion item)
        {
            return lo.LocalizacionSelectById(item);
        }

        public int LocalizacionDesactivar(prop.Localizacion item)
        {
            return lo.LocalizacionDesactivar(item);
        }

        public string LocalizacionInsert(prop.Localizacion item)
        {
            return lo.LocalizacionInsert(item);
        }

        public int LocalizacionUpdate(prop.Localizacion item)
        {
            return lo.LocalizacionUpdate(item);
        }
    }
}
