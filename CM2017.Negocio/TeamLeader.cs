using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class GerenteTL
    {
        public string _title = "Team Leader";

        BaseDeDatos.Tablas.GerenteTL tl = new BaseDeDatos.Tablas.GerenteTL();

        public DataTable GerentesTLSelect()
        {
            return tl.GerentesTLSelect();
        }

        public DataTable GerentesTLActivoSelect()
        {
            return tl.GerentesTLActivoSelect();
        }

        public DataTable GerenteTLSelectById(prop.TeamLeader item)
        {
            return tl.GerenteTLSelectById(item);
        }

        public int GerenteTLDesactivar(prop.TeamLeader item)
        {
            return tl.GerenteTLDesactivar(item);
        }

        public string GerenteTLInsert(prop.TeamLeader item)
        {
            return tl.GerenteTLInsert(item);
        }

        public int GerenteTLUpdate(prop.TeamLeader item)
        {
            return tl.GerenteTLUpdate(item);
        }
    }
}
