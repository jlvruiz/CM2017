﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmProductos : Comun
    {
        public static int IdProducto = 0;
        public static int editar = 0;
        int cont = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.PageIndex = 0;
                CargarProductos();
            }
        }
        protected void CargarProductos()
        {
            GridView1.DataSource = objProductos.ProductosSelect();
            GridView1.DataBind();
        }

        int indexOfColumn = 1;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[indexOfColumn].Visible = false; //IdProducto
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void lnbAgregar_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Agregar";

            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ProductosEntity.Id = IdProducto;
            ProductosEntity.Descripcion = txtDescripcion.Text == string.Empty ? "" : txtDescripcion.Text;
            if (chkActivo.Checked == true)
                ProductosEntity.Activo = 1;
            else
                ProductosEntity.Activo = 0;
            if (editar == 0)
            {
                objProductos.ProductoInsert(ProductosEntity);
            }
            else if (editar == 1)
            {
                objProductos.ProductoUpdate(ProductosEntity);
                editar = 0;
            }
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            CargarProductos();
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarPantallaBloqueo", "javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();", true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView dg = (GridView)sender;
            if (dg.SelectedRow.Cells[0].Text == string.Empty)
                cont++;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarProductos();
        }

        protected void LigaEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string val = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            ProductosEntity.Id = int.Parse(val);
            foreach (System.Data.DataRow fila in objProductos.ProductosSelectById(ProductosEntity).Rows)
            {
                IdProducto = int.Parse(val);
                txtDescripcion.Text = fila["Descripcion"] == DBNull.Value ? "" : fila["Descripcion"].ToString();
                chkActivo.Checked = fila["Visible"] == DBNull.Value ? int.Parse(fila["Visible"].ToString()) == 0 ? false : true : int.Parse(fila["Visible"].ToString()) == 1 ? true : false;
                editar = 1;
                lblTitulo.Text = "Editar";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        protected void LigaBorrar_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string val = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            int activo = int.Parse(GridView1.DataKeys[row.RowIndex].Values[1].ToString());
            ProductosEntity.Id = int.Parse(val);
            if (activo == 1)
                activo = 0;
            else
                activo = 1;
            ProductosEntity.Activo = activo;
            int obt = objProductos.ProductosDesactivar(ProductosEntity);
            CargarProductos();
        }
    }
}