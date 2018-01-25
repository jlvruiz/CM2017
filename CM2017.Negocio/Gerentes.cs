using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class Gerentes
    {
        public string _title = "Gerentes de Producto";

        BaseDeDatos.Tablas.Gerentes gr = new BaseDeDatos.Tablas.Gerentes();

        public DataTable GerentesSelect()
        {
            return gr.GerentesSelect();
        }

        public DataTable GerentesActivoSelect()
        {
            return gr.GerentesActivoSelect();
        }

        public DataTable GerentesSelectById(prop.Gerentes item)
        {
            return gr.GerentesSelectById(item);
        }

        public int GerenteDesactivar(prop.Gerentes item)
        {
            return gr.GerenteDesactivar(item);
        }

        public string GerenteInsert(prop.Gerentes item)
        {
            return gr.GerenteInsert(item);
        }

        public int GerenteUpdate(prop.Gerentes item)
        {
            return gr.GerenteUpdate(item);
        }


    }
}
