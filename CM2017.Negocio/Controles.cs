using System.Data;
using System.Web.UI.WebControls;

namespace CM2017.Negocio
{
    public static class Controles
    {
        public static void LlenarDropDownList(ref DropDownList dropdownlist, DataTable datatable, string titulo, string valor)
        {
            dropdownlist.DataSource = datatable;
            dropdownlist.DataTextField = titulo;
            dropdownlist.DataValueField = valor;
            dropdownlist.DataBind();
        }

        public static void LlenarRadioButtonList(ref RadioButtonList radiobuttonlist, DataTable datatable, string titulo, string valor)
        {
            radiobuttonlist.DataSource = datatable;
            radiobuttonlist.DataTextField = titulo;
            radiobuttonlist.DataValueField = valor;
            radiobuttonlist.DataBind();
        }

        public static void LlenarGridView(GridView gridview, DataTable datatable)
        {
            gridview.DataSource = datatable;
            gridview.EmptyDataText = "No hay registros para mostrar.";
            gridview.DataBind();
        }

        public static void LlenarCheckBoxList(ref CheckBoxList checkbox, DataTable datatable, string titulo, string valor)
        {
            checkbox.DataSource = datatable;
            checkbox.DataTextField = titulo;
            checkbox.DataValueField = valor;
            checkbox.DataBind();
        }



    }
}
