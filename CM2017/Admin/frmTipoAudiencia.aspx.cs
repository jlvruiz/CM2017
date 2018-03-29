using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmTipoAudiencia : Comun
    {
        Negocio.TipoAudiencia tipoaudiencia;
        Propiedades.TipoAudiencia tipoaudienciaEntity;

        public static int IdTipoAudiencia = 0;
        public static int editar = 0;
        int cont = 0;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = objTipoAudiencia._title;

            if (!IsPostBack)
            {
                GridView1.PageIndex = 0;
                CargarTipoAudiencia();
            }
                
        }

        protected void CargarTipoAudiencia()
        {
            LlenarGridView(GridView1, objTipoAudiencia.TipoAudienciaSelect());
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = GridView1.Rows[e.RowIndex].Cells[4].Text == "Activo" ? 1 : 0;
            TipoAudienciaEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            TipoAudienciaEntity.Activo = activo;
            int obt = objTipoAudiencia.TipoAudienciaDesactivar(TipoAudienciaEntity);
            if (obt == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showWarningToast', '<br />No se puede desactivar " + GridView1.Rows[e.RowIndex].Cells[3].Text + " porque esta asignado a un evento que se desarrollará proximamente');", true);
            else
                CargarTipoAudiencia();
        }

        int indexOfColumn = 2; //Posicion del Id
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[indexOfColumn].Visible = false; //IdTipoAudiencia
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdAudiencia"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    TipoAudienciaEntity.Id = val;
                    foreach (System.Data.DataRow row in objTipoAudiencia.TipoAudienciaSelectById(TipoAudienciaEntity).Rows)
                    {
                        IdTipoAudiencia = val;
                        txtDescripcion.Text = row["Descripcion"] == DBNull.Value ? "" : row["Descripcion"].ToString();
                        chkActivo.Checked = row["Visible"] == DBNull.Value ? row["Visible"].ToString() == "Inactivo" ? false : true : row["Visible"].ToString() == "Activo" ? true : false;
                        chkBloqueo.Checked = (row["Bloqueado"] == DBNull.Value || row["Bloqueado"].ToString() == "0") ? chkBloqueo.Checked = false : chkBloqueo.Checked = true;
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
            TipoAudienciaEntity.Id = IdTipoAudiencia;
            TipoAudienciaEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                TipoAudienciaEntity.Activo = 1;
            else
                TipoAudienciaEntity.Activo = 0;
            if (chkBloqueo.Checked == true)
                TipoAudienciaEntity.Bloqueado = 2;
            else
                TipoAudienciaEntity.Bloqueado = 0;
            if (editar == 0)
            {
                //Agregar nuevo
            }
            else if (editar == 1)
            {
                objTipoAudiencia.TipoAudienciaUpdate(TipoAudienciaEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarTipoAudiencia();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView dg = (GridView)sender;
            if (dg.SelectedRow.Cells[0].Text == string.Empty)
                cont++;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarTipoAudiencia();
        }


    }
}