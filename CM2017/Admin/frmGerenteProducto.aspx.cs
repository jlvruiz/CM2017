using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmGerenteProducto : Comun
    {
        public static int IdGerente = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sesion"] == null)
                Response.Redirect("../Default.aspx");

            Page.Title = objGerentes._title;

            if (!IsPostBack)
                CargarGerentes();
        }

        protected void CargarGerentes()
        {
            LlenarGridView(GridView1, objGerentes.GerentesSelect());
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdGerente"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    GerentesEntity.Id = val;
                    foreach (System.Data.DataRow row in objGerentes.GerentesSelectById(GerentesEntity).Rows)
                    {
                        IdGerente = val;
                        txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
                        txtCorreo.Text = row["Correo"] == DBNull.Value ? "" : row["Correo"].ToString();
                        chkActivo.Checked = activoInactivo(row["Activo"]);
                        editar = 1;
                        lblTitulo.Text = "Editar";
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
                }
                if (currentCommand == "Delete")
                {
                    int activo = GridView1.Rows[rowIndex].Cells[4].Text == "Activo" ? 1 : 0;
                    GerentesEntity.Id = val;
                    if (activo == 1)
                        activo = 0;
                    else
                        activo = 1;
                    GerentesEntity.Activo = activo;
                    int obt = objGerentes.GerenteDesactivar(GerentesEntity);
                    CargarGerentes();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnbAgregar_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Agregar";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            chkActivo.Checked = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            GerentesEntity.Id = IdGerente;
            GerentesEntity.Nombre = txtNombre.Text == string.Empty ? "" : txtNombre.Text;
            GerentesEntity.Correo = txtCorreo.Text == string.Empty ? "" : txtCorreo.Text;
            if (chkActivo.Checked == true)
                GerentesEntity.Activo = 1;
            else
                GerentesEntity.Activo = 0;
            if (editar == 0)
                objGerentes.GerenteInsert(GerentesEntity);
            else if (editar == 1)
            {
                objGerentes.GerenteUpdate(GerentesEntity);
                editar = 0;
            }
            txtNombre.Text = "";
            txtCorreo.Text = "";
            chkActivo.Checked = false;
            CargarGerentes();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarGerentes();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }


    }
}