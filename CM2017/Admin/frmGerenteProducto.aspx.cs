using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmGerenteProducto : System.Web.UI.Page
    {
        Negocio.Gerentes gerentes;
        Negocio.GerentesEntity gerentesEntity;

        public static int IdGerente = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGerentes();
        }

        protected void CargarGerentes()
        {
            gerentes = new Negocio.Gerentes();
            GridView1.DataSource = gerentes.GerentesSelect();
            GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdGerente"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    tblAgregar.Visible = true;
                    gerentes = new Negocio.Gerentes();
                    gerentesEntity = new Negocio.GerentesEntity();
                    gerentesEntity.Id = val;
                    foreach (System.Data.DataRow row in gerentes.GerentesSelectById(gerentesEntity).Rows)
                    {
                        IdGerente = val;
                        txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
                        txtCorreo.Text = row["Correo"] == DBNull.Value ? "" : row["Correo"].ToString();
                        chkActivo.Checked = row["Activo"] == DBNull.Value ? int.Parse(row["Activo"].ToString()) == 0 ? false : true : int.Parse(row["Activo"].ToString()) == 1 ? true : false;
                        editar = 1;
                    }
                }
                if (currentCommand == "Delete")
                {
                    gerentes = new Negocio.Gerentes();
                    gerentesEntity = new Negocio.GerentesEntity();

                    int activo = int.Parse(GridView1.Rows[rowIndex].Cells[4].Text);
                    gerentesEntity.Id = val;
                    if (activo == 1)
                        activo = 0;
                    else
                        activo = 1;
                    gerentesEntity.Activo = activo;
                    int obt = gerentes.GerenteDesactivar(gerentesEntity);
                    CargarGerentes();
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
            gerentes = new Negocio.Gerentes();
            gerentesEntity = new Negocio.GerentesEntity();
            gerentesEntity.Id = IdGerente;
            gerentesEntity.Nombre = txtNombre.Text == string.Empty ? "" : txtNombre.Text;
            gerentesEntity.Correo = txtCorreo.Text == string.Empty ? "" : txtCorreo.Text;
            if (chkActivo.Checked == true)
                gerentesEntity.Activo = 1;
            else
                gerentesEntity.Activo = 0;
            if (editar == 0)
                gerentes.GerenteInsert(gerentesEntity);
            else if (editar == 1)
            {
                gerentes.GerenteUpdate(gerentesEntity);
                editar = 0;
            }
            txtNombre.Text = "";
            txtCorreo.Text = "";
            chkActivo.Checked = false;
            CargarGerentes();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarGerentes();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }
    }
}