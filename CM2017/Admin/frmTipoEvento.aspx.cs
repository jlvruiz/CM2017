using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmTipoEvento : Comun
    {
        public static int IdTipoEvento = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = objTipoEvento._title;

            if (!IsPostBack)
                CargarTipoEvento();
        }
        protected void CargarTipoEvento()
        {
            LlenarGridView(GridView1, objTipoEvento.TipoEventoSelect());
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = GridView1.Rows[e.RowIndex].Cells[4].Text == "Activo" ? 1 : 0;
            TipoEventoEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            TipoEventoEntity.Activo = activo;
            int obt = objTipoEvento.TipoEventoDesactivar(TipoEventoEntity);
            if (obt == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showWarningToast', '<br />No se puede desactivar este tipo de Evento porque esta asignado a un evento que se desarrollará proximamente');", true);
            else
                CargarTipoEvento();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdTipEve"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    TipoEventoEntity.Id = val;
                    foreach (System.Data.DataRow row in objTipoEvento.TipoEventoSelectById(TipoEventoEntity).Rows)
                    {
                        IdTipoEvento = val;
                        txtDescripcion.Text = row["Descripcion"] == DBNull.Value ? "" : row["Descripcion"].ToString();
                        chkActivo.Checked = activoInactivo(row["Visible"]);
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
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            TipoEventoEntity.Id = IdTipoEvento;
            TipoEventoEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                TipoEventoEntity.Activo = 1;
            else
                TipoEventoEntity.Activo = 0;
            if (editar == 0)
            {
                //usuarios.UsuarioInsert(usuariosEntity);
                objTipoEvento.TipoEventoInsert(TipoEventoEntity);
            }
            else if (editar == 1)
            {
                objTipoEvento.TipoEventoUpdate(TipoEventoEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarTipoEvento();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }
    }
}