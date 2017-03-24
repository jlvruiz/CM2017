using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmLocacion : System.Web.UI.Page
    {
        Negocio.Localizacion localizacion;
        Negocio.LocalizacionEntity localizacionEntity;

        public static int IdLoc = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarLocalizaciones();

        }

        protected void CargarLocalizaciones()
        {
            localizacion = new Negocio.Localizacion();
            GridView1.DataSource = localizacion.LocalizacionesSelect();
            GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            localizacion = new Negocio.Localizacion();
            localizacionEntity = new Negocio.LocalizacionEntity();

            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[6].Text);
            localizacionEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            localizacionEntity.Activo = activo;
            int obt = localizacion.LocalizacionDesactivar(localizacionEntity);
            CargarLocalizaciones();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdLoc"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    tblAgregar.Visible = true;
                    localizacion = new Negocio.Localizacion();
                    localizacionEntity = new Negocio.LocalizacionEntity();
                    localizacionEntity.Id = val;
                    foreach (System.Data.DataRow row in localizacion.LocalizacionSelectById(localizacionEntity).Rows)
                    {
                        IdLoc = val;
                        txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
                        rblTipo.SelectedValue = row["Tipo"].ToString();
                        txtMotivo.Text = row["Motivo"] == DBNull.Value ? "" : row["Motivo"].ToString();
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
            localizacion = new Negocio.Localizacion();
            localizacionEntity = new Negocio.LocalizacionEntity();
            localizacionEntity.Id = IdLoc;
            localizacionEntity.Nombre = txtNombre.Text == string.Empty ? "" : txtNombre.Text;
            localizacionEntity.Tipo = rblTipo.SelectedIndex;
            localizacionEntity.Motivo = txtMotivo.Text == string.Empty ? "" : txtMotivo.Text;
            if (chkActivo.Checked == true)
                localizacionEntity.Activo = 1;
            else
                localizacionEntity.Activo = 0;
            if (editar == 0)
                localizacion.LocalizacionInsert(localizacionEntity);
            else if (editar == 1)
            {
                localizacion.LocalizacionUpdate(localizacionEntity);
                editar = 0;
            }
            txtNombre.Text = "";
            rblTipo.SelectedIndex = 0;
            txtMotivo.Text = "";
            chkActivo.Checked = false;
            CargarLocalizaciones();
        }





    }
}