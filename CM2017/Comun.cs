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

        //private string cadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JoseLuis\Documents\CM2017\CM2017\CM2017\DB\CM.mdb;";

        public CM2017.Negocio.Eventos objEventos;
        public CM2017.Negocio.EventosEntity EventosEntity;
        public CM2017.Negocio.Usuarios objUsuarios;
        public CM2017.Negocio.UsuariosEntity UsuariosEntity;
        public CM2017.Negocio.TipoEvento objTipoEvento;
        public CM2017.Negocio.TipoEventoEntity TipoEventoEntity;
        public CM2017.Negocio.Gerentes objGerentes;
        public CM2017.Negocio.GerentesEntity GerentesEntity;
        public CM2017.Negocio.Productos objProductos;
        public CM2017.Negocio.ProductosEntity ProductosEntity;
        public CM2017.Negocio.TipoAudiencia objTipoAudiencia;
        public CM2017.Negocio.TipoAudienciaEntity TipoAudienciaEntity;
        public CM2017.Negocio.Localizacion objLocalizacion;
        public CM2017.Negocio.LocalizacionEntity LocalizacionEntity;
        public CM2017.Negocio.Divisiones objDivisiones;
        public CM2017.Negocio.DivisionesEntity DivisionesEntity;
        public CM2017.Negocio.AreaTerapeutica objAreaTerapeutica;
        public CM2017.Negocio.AreaTerapeuticaEntity AreaTerapeuticaEntity;
        public CM2017.Negocio.GerenteTL objGerenteTL;
        public CM2017.Negocio.GerenteTLEntity GerenteTLEntity;
        public CM2017.Negocio.ClienteInterno objClienteInterno;
        public CM2017.Negocio.ClienteInternoEntity ClienteInternoEntity;
        public CM2017.Negocio.UDN objUDN;
        public CM2017.Negocio.UDNEntity UDNEntity;

        public Comun()
        {
            objEventos = new Negocio.Eventos();
            EventosEntity = new Negocio.EventosEntity();
            objUsuarios = new Negocio.Usuarios();
            UsuariosEntity = new Negocio.UsuariosEntity();
            objTipoEvento = new Negocio.TipoEvento();
            TipoEventoEntity = new Negocio.TipoEventoEntity();
            objGerentes = new Negocio.Gerentes();
            GerentesEntity = new Negocio.GerentesEntity();
            objProductos = new Negocio.Productos();
            ProductosEntity = new Negocio.ProductosEntity();
            objAreaTerapeutica = new Negocio.AreaTerapeutica();
            AreaTerapeuticaEntity = new Negocio.AreaTerapeuticaEntity();
            objTipoAudiencia = new Negocio.TipoAudiencia();
            TipoAudienciaEntity = new Negocio.TipoAudienciaEntity();
            objGerenteTL = new Negocio.GerenteTL();
            GerenteTLEntity = new Negocio.GerenteTLEntity();
            objClienteInterno = new Negocio.ClienteInterno();
            ClienteInternoEntity = new Negocio.ClienteInternoEntity();
            objDivisiones = new Negocio.Divisiones();
            DivisionesEntity = new Negocio.DivisionesEntity();
            objUDN = new Negocio.UDN();
            UDNEntity = new Negocio.UDNEntity();
            objLocalizacion = new Negocio.Localizacion();
            LocalizacionEntity = new Negocio.LocalizacionEntity();
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