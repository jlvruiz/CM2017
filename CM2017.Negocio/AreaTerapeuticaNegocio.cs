using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2017.Negocio
{
    public class AreaTerapeuticaNegocio
    {
        BaseDeDatos.Tablas.AreaTerapeutica dbLocal = new BaseDeDatos.Tablas.AreaTerapeutica();

        public DataTable AreaTerapeuticaSelect()
        {
            return dbLocal.AreaTerapeuticaSelect();
        }
    }
}
