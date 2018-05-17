using CM2017.IU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Sistema
{
    public partial class Inicio : Comun
    {
        int indexOfColumn = 1;

        Concentrador Manejador_Sesion = new Concentrador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sesion"] == null)
                Response.Redirect("Default.aspx");

            Manejador_Sesion = (Concentrador)Session["sesion"];

            if (!IsPostBack)
            {
                Page.Title = inicio._title;

                lblFechaYHora.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " " + Manejador_Sesion.Usuarios.Nombre;

                GridView1.PageIndex = 0;
                CargarEventos();
            }
        }

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
            string val = "";
            if (sender is LinkButton)
            {
                LinkButton btn = sender as LinkButton;
                GridViewRow row = btn.NamingContainer as GridViewRow;
                val = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            }
            else if (sender is ImageButton)
            {
                ImageButton imgbtn = sender as ImageButton;
                GridViewRow row2 = imgbtn.NamingContainer as GridViewRow;
                val = GridView1.DataKeys[row2.RowIndex].Values[0].ToString();
            }
            
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
            try
            {
                //Prueba de llenado con propiedades --
                Propiedades.Eventos eventos = new Propiedades.Eventos();
                eventos = objEventos.EventosSeleccionId();                
                LlenarGridView(GridView1, objEventos.EventosSelect());
                //Fin prueba -------------------------
                //EventosServicios.EventosClient eventoS = new EventosServicios.EventosClient();
                //LlenarGridView(GridView1, eventoS.EventosSelect());
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showDangerToast', '<br />Error del sistema: " + ex.Message + "');", true);
            }
        }

        public void cargarDetalle(string Id)
        {
            GridView2.DataSource = objEventos.EventosDetalleSelect(Id);
            GridView2.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void LigaDesactivar_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string val = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            objEventos.EventoDesactivar(val);
            CargarEventos();
        }


    }
}