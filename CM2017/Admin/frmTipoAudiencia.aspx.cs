using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmTipoAudiencia : System.Web.UI.Page
    {
        Negocio.TipoAudiencia tipoaudiencia;
        Negocio.TipoAudienciaEntity tipoaudienciaEntity;

        public static int IdTipoAudiencia = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarTipoAudiencia();
        }
        protected void CargarTipoAudiencia()
        {
            tipoaudiencia = new Negocio.TipoAudiencia();
            GridView1.DataSource = tipoaudiencia.TipoAudienciaSelect();
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            tipoaudiencia = new Negocio.TipoAudiencia();
            tipoaudienciaEntity = new Negocio.TipoAudienciaEntity();

            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[4].Text);
            tipoaudienciaEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            tipoaudienciaEntity.Activo = activo;
            int obt = tipoaudiencia.TipoAudienciaDesactivar(tipoaudienciaEntity);
            CargarTipoAudiencia();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdAudiencia"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    tblAgregar.Visible = true;
                    tipoaudiencia = new Negocio.TipoAudiencia();
                    tipoaudienciaEntity = new Negocio.TipoAudienciaEntity();
                    tipoaudienciaEntity.Id = val;
                    foreach (System.Data.DataRow row in tipoaudiencia.TipoAudienciaSelectById(tipoaudienciaEntity).Rows)
                    {
                        IdTipoAudiencia = val;
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
            tipoaudiencia = new Negocio.TipoAudiencia();
            tipoaudienciaEntity = new Negocio.TipoAudienciaEntity();
            tipoaudienciaEntity.Id = IdTipoAudiencia;
            tipoaudienciaEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                tipoaudienciaEntity.Activo = 1;
            else
                tipoaudienciaEntity.Activo = 0;
            if (editar == 0)
            {
                //usuarios.UsuarioInsert(usuariosEntity);
            }
            else if (editar == 1)
            {
                tipoaudiencia.TipoAudienciaUpdate(tipoaudienciaEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarTipoAudiencia();
        }
    }
}