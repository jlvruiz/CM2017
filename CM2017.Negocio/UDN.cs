using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class UDN
    {
        public string _title = "Unidad de Negocio";

        BaseDeDatos.Tablas.UDN un = new BaseDeDatos.Tablas.UDN();

        public DataTable UDNSelect()
        {
            return un.UDNSelect();
        }

        public DataTable UDNSelectById(prop.UDN item)
        {
            return un.UDNSelectById(item);
        }

        public int UDNDesactivar(prop.UDN item)
        {
            return un.UDNDesactivar(item);
        }

        public int UDNUpdate(prop.UDN item)
        {
            return un.UDNUpdate(item);
        }
    }
}
