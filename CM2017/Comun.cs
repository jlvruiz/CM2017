using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017
{
    public class Comun : System.Web.UI.Page
    {

        private string cadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\users\joseluis\documents\visual studio 2015\Projects\CM2017\CM2017\DB\CM.mdb;";

        public CM2017.Negocio.Usuarios Usuarios;
        public CM2017.Negocio.UsuariosEntity UsuariosEntity;
        public CM2017.Negocio.TipoEvento objTipoEvento;
        public CM2017.Negocio.TipoEventoEntity TipoEventoEntity;
        public CM2017.Negocio.Gerentes objGerentes;
        public CM2017.Negocio.GerentesEntity TipoGerentesEntity;
        public CM2017.Negocio.Productos objProductos;
        public CM2017.Negocio.ProductosEntity TipoProductosEntity;

        public Comun()
        {
            Usuarios = new Negocio.Usuarios(cadenaConexion);
            UsuariosEntity = new Negocio.UsuariosEntity();
            objTipoEvento = new Negocio.TipoEvento();
            TipoEventoEntity = new Negocio.TipoEventoEntity();
            objGerentes = new Negocio.Gerentes();
            TipoGerentesEntity = new Negocio.GerentesEntity();
            objProductos = new Negocio.Productos();
            TipoProductosEntity = new Negocio.ProductosEntity();
        }

        public void LlenarGridView(GridView gridview, DataTable datatable)
        {
            gridview.DataSource = datatable;
            gridview.EmptyDataText = "No hay registros para mostrar.";
            gridview.DataBind();
        }

        public void LlenarDropDownList(DropDownList dropdownlist, DataTable datatable, string titulo, string valor)
        {
            dropdownlist.DataSource = datatable;
            dropdownlist.DataTextField = titulo;
            dropdownlist.DataValueField = valor;
            dropdownlist.DataBind();
        }

        public void LlenarRadioButtonList(RadioButtonList radiobuttonlist, DataTable datatable, string titulo, string valor)
        {
            radiobuttonlist.DataSource = datatable;
            radiobuttonlist.DataTextField = titulo;
            radiobuttonlist.DataValueField = valor;
            radiobuttonlist.DataBind();
        }


    }
}