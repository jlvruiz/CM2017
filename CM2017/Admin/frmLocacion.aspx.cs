using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmLocacion : Comun
    {
        public static int IdLoc = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarLocalizaciones();

        }

        protected void CargarLocalizaciones()
        {
            GridView1.DataSource = objLocalizacion.LocalizacionesSelect();
            GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[6].Text);
            LocalizacionEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            LocalizacionEntity.Activo = activo;
            int obt = objLocalizacion.LocalizacionDesactivar(LocalizacionEntity);
            CargarLocalizaciones();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdLoc"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    LocalizacionEntity.Id = val;
                    foreach (System.Data.DataRow row in objLocalizacion.LocalizacionSelectById(LocalizacionEntity).Rows)
                    {
                        IdLoc = val;
                        txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
                        rblTipo.SelectedValue = row["Tipo"].ToString();
                        txtMotivo.Text = row["Motivo"] == DBNull.Value ? "" : row["Motivo"].ToString();
                        chkActivo.Checked = row["Visible"] == DBNull.Value ? int.Parse(row["Visible"].ToString()) == 0 ? false : true : int.Parse(row["Visible"].ToString()) == 1 ? true : false;
                        editar = 1;
                        lblTitulo.Text = "Editar";
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
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
            rblTipo.SelectedIndex = 0;
            txtMotivo.Text = "";
            chkActivo.Checked = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            LocalizacionEntity.Id = IdLoc;
            LocalizacionEntity.Nombre = txtNombre.Text == string.Empty ? "" : txtNombre.Text;
            LocalizacionEntity.Tipo = rblTipo.SelectedIndex;
            LocalizacionEntity.Motivo = txtMotivo.Text == string.Empty ? "" : txtMotivo.Text;
            if (chkActivo.Checked == true)
                LocalizacionEntity.Activo = 1;
            else
                LocalizacionEntity.Activo = 0;
            if (editar == 0)
                objLocalizacion.LocalizacionInsert(LocalizacionEntity);
            else if (editar == 1)
            {
                objLocalizacion.LocalizacionUpdate(LocalizacionEntity);
                editar = 0;
            }
            txtNombre.Text = "";
            rblTipo.SelectedIndex = 0;
            txtMotivo.Text = "";
            chkActivo.Checked = false;
            CargarLocalizaciones();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }





    }
}