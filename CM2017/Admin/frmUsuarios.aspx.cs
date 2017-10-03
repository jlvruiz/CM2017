﻿using System;
using System.Web.UI;
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
            LlenarGridView(GridView1, objUsuarios.UsuariosSelect());
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Id = System.Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int activo = int.Parse(GridView1.Rows[e.RowIndex].Cells[6].Text);
            string estatus = string.Empty;
            UsuariosEntity.Id = Id;
            if (activo == 1)
            {
                activo = 0;
                estatus = "inactivo";
            }
            else
            {
                activo = 1;
                estatus = "activo";
            }
            UsuariosEntity.Activo = activo;
            int obt = objUsuarios.UsuarioDesactivar(UsuariosEntity);
            ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showWarningToast', '<br />Cambió el estatus del registro a " + estatus + "');", true);
            CargarUsuarios();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);

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
                    UsuariosEntity.Id = val;
                    foreach (System.Data.DataRow row in objUsuarios.UsuariosSelectById(UsuariosEntity).Rows)
                    {
                        IdUsuario = val;
                        txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
                        txtCorreo.Text = row["Correo"] == DBNull.Value ? "" : row["Correo"].ToString();
                        txtClave.Text = row["Clave"] == DBNull.Value ? "" : row["Clave"].ToString();
                        txtContra.Text = row["Contra"] == DBNull.Value ? "" : row["Contra"].ToString();
                        chkActivo.Checked = row["Activo"] == DBNull.Value ? row["Activo"].ToString() == "False" ? false : true : row["Activo"].ToString() == "True" ? true: false;
                        editar = 1;
                        lblTitulo.Text = "Editar";
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
                }
                if (e.CommandName == "Increase")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnbAgregar_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Agregar";
            txtNombre.Text = "";
            txtClave.Text = "";
            txtContra.Text = "";
            txtCorreo.Text = "";
            chkActivo.Checked = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
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
            {
                objUsuarios.UsuarioInsert(UsuariosEntity);
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showSuccessToast', '<br />Se agregó el registro exitosamente.');", true);
                CargarUsuarios();
            }
            else if (editar == 1)
            {
                objUsuarios.UsuarioUpdate(UsuariosEntity);
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showSuccessToast', '<br />Se actualizó el registro exitosamente.');", true);
                editar = 0;
                CargarUsuarios();
            }
            else if (editar == 2)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = objUsuarios.UsuariosBuscar(UsuariosEntity);
                if (dt.Rows.Count > 0)
                    LlenarGridView(GridView1, objUsuarios.UsuariosBuscar(UsuariosEntity));
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showWarningToast', '<br />No hay registros que coincidan con su búsqueda.');", true);

                editar = 0;
            }
            txtNombre.Text = "";
            txtClave.Text = "";
            txtContra.Text = "";
            chkActivo.Checked = false;
        }

        protected void lnkBuscar_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Buscar";
            editar = 2;
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }
    }
}