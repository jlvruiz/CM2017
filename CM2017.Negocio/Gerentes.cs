using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI.WebControls;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class Gerentes : Comun
    {
        public string _title = "Gerentes de Producto";

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

        public void cargarGerentes_DropDownList(ref DropDownList dropdownlist)
        {
            Controles.LlenarDropDownList(ref dropdownlist, gr.GerentesActivoSelect(), "Nombre", "IdGerente");
        }


    }
}
