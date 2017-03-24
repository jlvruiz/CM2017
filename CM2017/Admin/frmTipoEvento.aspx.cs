using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmTipoEvento : System.Web.UI.Page
    {
        Negocio.TipoEvento tipoevento;
        Negocio.TipoEventoEntity tipoeventoEntity;

        public static int IdTipoEvento = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarTipoEvento();
        }
        protected void CargarTipoEvento()
        {
            tipoevento = new Negocio.TipoEvento();
            GridView1.DataSource = tipoevento.TipoEventoSelect();
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            tipoevento = new Negocio.TipoEvento();
            tipoeventoEntity = new Negocio.TipoEventoEntity();

            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[4].Text);
            tipoeventoEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            tipoeventoEntity.Activo = activo;
            int obt = tipoevento.TipoEventoDesactivar(tipoeventoEntity);
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
                    tblAgregar.Visible = true;
                    tipoevento = new Negocio.TipoEvento();
                    tipoeventoEntity = new Negocio.TipoEventoEntity();
                    tipoeventoEntity.Id = val;
                    foreach (System.Data.DataRow row in tipoevento.TipoEventoSelectById(tipoeventoEntity).Rows)
                    {
                        IdTipoEvento = val;
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
            tipoevento = new Negocio.TipoEvento();
            tipoeventoEntity = new Negocio.TipoEventoEntity();
            tipoeventoEntity.Id = IdTipoEvento;
            tipoeventoEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                tipoeventoEntity.Activo = 1;
            else
                tipoeventoEntity.Activo = 0;
            if (editar == 0)
            {
                //usuarios.UsuarioInsert(usuariosEntity);
            }
            else if (editar == 1)
            {
                tipoevento.TipoEventoUpdate(tipoeventoEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarTipoEvento();
        }
    }
}