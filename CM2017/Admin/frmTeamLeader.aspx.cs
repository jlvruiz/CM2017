using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmTeamLeader : Comun
    {
        public static int IdGerente = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = objGerenteTL._title;

            if (!IsPostBack)
                CargarGerentes();
        }

        protected void CargarGerentes()
        {
            LlenarGridView(GridView1, objGerenteTL.GerentesTLSelect());
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdTL"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    GerentesEntity.Id = val;
                    foreach (System.Data.DataRow row in objGerenteTL.GerenteTLSelectById(GerenteTLEntity).Rows)
                    {
                        IdGerente = val;
                        txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
                        txtCorreo.Text = row["Correo"] == DBNull.Value ? "" : row["Correo"].ToString();
                        chkActivo.Checked = row["Activo"] == DBNull.Value ? int.Parse(row["Activo"].ToString()) == 0 ? false : true : int.Parse(row["Activo"].ToString()) == 1 ? true : false;
                        editar = 1;
                        lblTitulo.Text = "Editar";
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
                }
                if (currentCommand == "Delete")
                {
                    int activo = int.Parse(GridView1.Rows[rowIndex].Cells[4].Text);
                    GerenteTLEntity.Id = val;
                    if (activo == 1)
                        activo = 0;
                    else
                        activo = 1;
                    GerenteTLEntity.Activo = activo;
                    int obt = objGerenteTL.GerenteTLDesactivar(GerenteTLEntity);
                    CargarGerentes();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnbAgregar_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Agregar nuevo";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            chkActivo.Checked = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            GerenteTLEntity.Id = IdGerente;
            GerenteTLEntity.Nombre = txtNombre.Text == string.Empty ? "" : txtNombre.Text;
            GerenteTLEntity.Correo = txtCorreo.Text == string.Empty ? "" : txtCorreo.Text;
            if (chkActivo.Checked == true)
                GerenteTLEntity.Activo = 1;
            else
                GerenteTLEntity.Activo = 0;
            if (editar == 0)
            {
                if (txtNombre.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mantenerPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
                    txtNombre.Focus();
                }
                else if (txtCorreo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mantenerPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
                    txtCorreo.Focus();
                }
                else
                {
                    objGerenteTL.GerenteTLInsert(GerenteTLEntity);
                    procesadoExitoso();
                }
            }
            else if (editar == 1)
            {
                objGerenteTL.GerenteTLUpdate(GerenteTLEntity);
                editar = 0;
                procesadoExitoso();
            }
        }

        private void procesadoExitoso()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            chkActivo.Checked = false;
            CargarGerentes();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide('slow'); $('#divEncima').hide();", true);        
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarGerentes();
        }


    }
}