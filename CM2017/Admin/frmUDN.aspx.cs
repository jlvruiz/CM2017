using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmUDN :Comun
    {
        public static int IdUDN = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarUDN();
        }
        protected void CargarUDN()
        {
            GridView1.DataSource = objUDN.UDNSelect();
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
            UDNEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            UDNEntity.Activo = activo;
            int obt = objUDN.UDNDesactivar(UDNEntity);
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
                    UDNEntity.Id = val;
                    foreach (System.Data.DataRow row in objUDN.UDNSelectById(UDNEntity).Rows)
                    {
                        IdUDN = val;
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
            UDNEntity.Id = IdUDN;
            UDNEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                UDNEntity.Activo = 1;
            else
                UDNEntity.Activo = 0;
            if (editar == 0)
            {
                
            }
            else if (editar == 1)
            {
                objUDN.UDNUpdate(UDNEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarUDN();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }
    }
}