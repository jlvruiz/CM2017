using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class ClienteInterno
    {
        public string _title = "Cliente Interno";

        BaseDeDatos.Tablas.ClienteInterno ci = new BaseDeDatos.Tablas.ClienteInterno();

        public DataTable ClienteInternoSelect()
        {
            return ci.ClienteInternoSelect();
        }

        public DataTable ClienteInternoSelectById(prop.ClienteInterno item)
        {
            return ci.ClienteInternoSelectById(item);
        }

        public int ClienteInternoDesactivar(prop.ClienteInterno item)
        {
            return ci.ClienteInternoDesactivar(item);
        }

        public int ClienteInternoUpdate(prop.ClienteInterno item)
        {
            return ci.ClienteInternoUpdate(item);
        }


    }
}
