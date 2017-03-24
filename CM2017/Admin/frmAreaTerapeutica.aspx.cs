using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmAreaTerapeutica : System.Web.UI.Page
    {
        Negocio.AreaTerapeutica areaterapeutica;
        Negocio.AreaTerapeuticaEntity areaterapeuticaEntity;

        public static int IdAreaTerapeutica = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarAreaTerapeutica();
        }
        protected void CargarAreaTerapeutica()
        {
            areaterapeutica = new Negocio.AreaTerapeutica();
            GridView1.DataSource = areaterapeutica.AreaTerapeuticaSelect();
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            areaterapeutica = new Negocio.AreaTerapeutica();
            areaterapeuticaEntity = new Negocio.AreaTerapeuticaEntity();

            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[4].Text);
            areaterapeuticaEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            areaterapeuticaEntity.Activo = activo;
            int obt = areaterapeutica.AreaTerapeuticaDesactivar(areaterapeuticaEntity);
            CargarAreaTerapeutica();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdAT"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    tblAgregar.Visible = true;
                    areaterapeutica = new Negocio.AreaTerapeutica();
                    areaterapeuticaEntity = new Negocio.AreaTerapeuticaEntity();
                    areaterapeuticaEntity.Id = val;
                    foreach (System.Data.DataRow row in areaterapeutica.AreaTerapeuticaSelectById(areaterapeuticaEntity).Rows)
                    {
                        IdAreaTerapeutica = val;
                        txtDescripcion.Text = row["Descripcion"] == DBNull.Value ? "" : row["Descripcion"].ToString();
                        chkActivo.Checked = row["Visible"] == DBNull.Value ? int.Parse(row["Visible"].ToString()) == 0 ? false : true : int.Parse(row["Visible"].ToString()) == 1 ? true : false;
                        editar = 1;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnbAgregar_Click(object sender, EventArgs e)
        {
            tblAgregar.Visible = true;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            tblAgregar.Visible = false;
            areaterapeutica = new Negocio.AreaTerapeutica();
            areaterapeuticaEntity = new Negocio.AreaTerapeuticaEntity();
            areaterapeuticaEntity.Id = IdAreaTerapeutica;
            areaterapeuticaEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                areaterapeuticaEntity.Activo = 1;
            else
                areaterapeuticaEntity.Activo = 0;
            if (editar == 0)
            {
                //usuarios.UsuarioInsert(usuariosEntity);
            }
            else if (editar == 1)
            {
                areaterapeutica.AreaTerapeuticaUpdate(areaterapeuticaEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarAreaTerapeutica();
        }
    }
}