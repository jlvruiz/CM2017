using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmAreaTerapeutica : Comun
    {
        
        public static int IdAreaTerapeutica = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = objAreaTerapeutica._title;
            if (!IsPostBack)
                CargarAreaTerapeutica();

        }
        protected void CargarAreaTerapeutica()
        {
            LlenarGridView(GridView1, objAreaTerapeutica.AreaTerapeuticaSelect());            
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = GridView1.Rows[e.RowIndex].Cells[4].Text == "Activo" ? 1 : 0;
            AreaTerapeuticaEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            AreaTerapeuticaEntity.Activo = activo;
            string nombreEvento = "";
            int obt = objAreaTerapeutica.AreaTerapeuticaDesactivar(AreaTerapeuticaEntity, ref nombreEvento);
            if (obt == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showWarningToast', '<br />No se puede desactivar <strong>"+ GridView1.Rows[e.RowIndex].Cells[3].Text + "</strong> porque esta asignada al evento <strong>" + nombreEvento + "</strong> que se desarrollará proximamente');", true);
            else
                CargarAreaTerapeutica();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdAT"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    AreaTerapeuticaEntity = new Propiedades.AreaTerapeutica();
                    AreaTerapeuticaEntity.Id = val;
                    foreach (System.Data.DataRow row in objAreaTerapeutica.AreaTerapeuticaSelectById(AreaTerapeuticaEntity).Rows)
                    {
                        IdAreaTerapeutica = val;
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
            AreaTerapeuticaEntity = new Propiedades.AreaTerapeutica();
            AreaTerapeuticaEntity.Id = IdAreaTerapeutica;
            AreaTerapeuticaEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                AreaTerapeuticaEntity.Activo = 1;
            else
                AreaTerapeuticaEntity.Activo = 0;
            if (editar == 0)
            {
                //usuarios.UsuarioInsert(usuariosEntity);
            }
            else if (editar == 1)
            {
                objAreaTerapeutica.AreaTerapeuticaUpdate(AreaTerapeuticaEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarAreaTerapeutica();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }


    }
}