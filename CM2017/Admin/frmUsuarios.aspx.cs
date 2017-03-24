using System;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmUsuarios : Comun
    {
        public static int IdUsuario = 0;
        public static int editar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarUsuarios();
        }

        protected void CargarUsuarios()
        {
            LlenarGridView(GridView1, Usuarios.UsuariosSelect());
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Id = System.Int32.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[5].Text);
            UsuariosEntity.Id = Id;
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            UsuariosEntity.Activo = activo;
            int obt = Usuarios.UsuarioDesactivar(UsuariosEntity);            
            CargarUsuarios();
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
            int val = int.Parse(this.GridView1.DataKeys[rowIndex]["IdResCM"].ToString());

            try
            {
                if (currentCommand == "Select")
                {
                    tblAgregar.Visible = true;
                    UsuariosEntity.Id = val;
                    foreach (System.Data.DataRow row in Usuarios.UsuariosSelectById(UsuariosEntity).Rows)
                    {
                        IdUsuario = val;
                        txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
                        txtCorreo.Text = row["Correo"] == DBNull.Value ? "" : row["Correo"].ToString();
                        txtClave.Text = row["Clave"] == DBNull.Value ? "" : row["Clave"].ToString();
                        txtContra.Text = row["Contra"] == DBNull.Value ? "" : row["Contra"].ToString();
                        chkActivo.Checked = row["Activo"] == DBNull.Value ? int.Parse(row["Activo"].ToString()) == 0 ? false : true : int.Parse(row["Activo"].ToString()) == 1 ? true: false;
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
            UsuariosEntity.Id = IdUsuario;
            UsuariosEntity.Nombre = txtNombre.Text == string.Empty ? "" : txtNombre.Text;
            UsuariosEntity.Correo = txtCorreo.Text == string.Empty ? "" : txtCorreo.Text;
            UsuariosEntity.Clave = txtClave.Text == string.Empty ? "" : txtClave.Text;
            UsuariosEntity.Contrasena = txtContra.Text == string.Empty ? "" : txtContra.Text;
            if (chkActivo.Checked == true)
                UsuariosEntity.Activo = 1;
            else
                UsuariosEntity.Activo = 0;
            if (editar == 0)
                Usuarios.UsuarioInsert(UsuariosEntity);
            else if (editar == 1)
            {
                Usuarios.UsuarioUpdate(UsuariosEntity);
                editar = 0;
            }
            txtNombre.Text = "";
            txtClave.Text = "";
            txtContra.Text = "";
            chkActivo.Checked = false;
            CargarUsuarios();
        }
    }
}