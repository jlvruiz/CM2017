using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Sistema
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.PageIndex = 0;
                CargarEventos();
            }
        }

        int indexOfColumn = 1;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[indexOfColumn].Visible = false; //Id
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarEventos();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();
            cargarDetalle(id);
        }

        protected void LigaEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string val = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            Response.Redirect("frmCaptura.aspx?e=1&Id=" + val);
        }

        protected void LigaDetalle_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string val = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            cargarDetalle(val);
        }

        protected void CargarEventos()
        {
            Negocio.Eventos eventos = new Negocio.Eventos();
            GridView1.DataSource = eventos.EventosSelect();
            GridView1.DataBind();
        }

        public void cargarDetalle(string Id)
        {
            Negocio.Eventos eventos = new Negocio.Eventos();
            GridView2.DataSource = eventos.EventosDetalleSelect(Id);
            GridView2.DataBind();
        }

        
    }
}