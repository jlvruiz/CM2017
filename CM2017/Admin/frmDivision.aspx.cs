using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmDivision : Comun
    {
        public static int IdDivision = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarDivisiones();
        }
        protected void CargarDivisiones()
        {
            GridView1.DataSource = objDivisiones.DivisionesSelect();
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[4].Text);
            DivisionesEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            DivisionesEntity.Activo = activo;
            int obt = objDivisiones.DivisionDesactivar(DivisionesEntity);
            CargarDivisiones();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdDivision"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    DivisionesEntity.Id = val;
                    foreach (System.Data.DataRow row in objDivisiones.DivisionesSelectById(DivisionesEntity).Rows)
                    {
                        IdDivision = val;
                        txtDescripcion.Text = row["Descripcion"] == DBNull.Value ? "" : row["Descripcion"].ToString();
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
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DivisionesEntity.Id = IdDivision;
            DivisionesEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                DivisionesEntity.Activo = 1;
            else
                DivisionesEntity.Activo = 0;
            if (editar == 0)
            {
                //usuarios.UsuarioInsert(usuariosEntity);
            }
            else if (editar == 1)
            {
                objDivisiones.DivisionUpdate(DivisionesEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarDivisiones();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }



    }
}