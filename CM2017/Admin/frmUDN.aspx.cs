using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmUDN : System.Web.UI.Page
    {
        Negocio.UDN udn;
        Negocio.UDNEntity udnEntity;

        public static int IdUDN = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarUDN();
        }
        protected void CargarUDN()
        {
            udn = new Negocio.UDN();
            GridView1.DataSource = udn.UDNSelect();
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            udn = new Negocio.UDN();
            udnEntity = new Negocio.UDNEntity();

            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[4].Text);
            udnEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            udnEntity.Activo = activo;
            int obt = udn.UDNDesactivar(udnEntity);
            CargarUDN();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdUDN"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    tblAgregar.Visible = true;
                    udn = new Negocio.UDN();
                    udnEntity = new Negocio.UDNEntity();
                    udnEntity.Id = val;
                    foreach (System.Data.DataRow row in udn.UDNSelectById(udnEntity).Rows)
                    {
                        IdUDN = val;
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
            udn = new Negocio.UDN();
            udnEntity = new Negocio.UDNEntity();
            udnEntity.Id = IdUDN;
            udnEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                udnEntity.Activo = 1;
            else
                udnEntity.Activo = 0;
            if (editar == 0)
            {
                //usuarios.UsuarioInsert(usuariosEntity);
            }
            else if (editar == 1)
            {
                udn.UDNUpdate(udnEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarUDN();
        }
    }
}