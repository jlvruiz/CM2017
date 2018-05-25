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
        public CM2017.Negocio.Inicio inicio;
        public CM2017.Negocio.Captura captura;
        public CM2017.Negocio.Eventos objEventos;
        public CM2017.Propiedades.Eventos EventosEntity;
        public CM2017.Negocio.EventosDesactivados eventosdesactivados;
        public CM2017.Negocio.EventosTerminados eventosterminados;

        public CM2017.Negocio.Estadisticas objEstadisticas;

        public CM2017.Negocio.Usuarios objUsuarios;
        public CM2017.Propiedades.Usuarios UsuariosEntity = new Propiedades.Usuarios();
        public CM2017.Negocio.TipoEvento objTipoEvento;
        public CM2017.Propiedades.TipoEvento TipoEventoEntity;
        public CM2017.Negocio.Gerentes objGerentes;
        public CM2017.Propiedades.Gerentes GerentesEntity;
        public CM2017.Negocio.Productos objProductos;
        public CM2017.Propiedades.Productos ProductosEntity;
        public CM2017.Negocio.TipoAudiencia objTipoAudiencia;
        public CM2017.Propiedades.TipoAudiencia TipoAudienciaEntity;
        public CM2017.Negocio.Localizacion objLocalizacion;
        public CM2017.Propiedades.Localizacion LocalizacionEntity;
        public CM2017.Negocio.Divisiones objDivisiones;
        public CM2017.Propiedades.Divisiones DivisionesEntity;
        public CM2017.Negocio.AreaTerapeutica objAreaTerapeutica;
        public CM2017.Propiedades.AreaTerapeutica AreaTerapeuticaEntity;
        public CM2017.Negocio.GerenteTL objGerenteTL;
        public CM2017.Propiedades.TeamLeader GerenteTLEntity;
        public CM2017.Negocio.ClienteInterno objClienteInterno;
        public CM2017.Propiedades.ClienteInterno ClienteInternoEntity;
        public CM2017.Negocio.UDN objUDN;
        public CM2017.Propiedades.UDN UDNEntity;

        public MensajesLocales ml;
   

        public Comun()
        {
            inicio = new Negocio.Inicio();
            captura = new Negocio.Captura();
            objEventos = new Negocio.Eventos();
            EventosEntity = new Propiedades.Eventos();
            eventosdesactivados = new Negocio.EventosDesactivados();
            eventosterminados = new Negocio.EventosTerminados();
            objEstadisticas = new Negocio.Estadisticas();
            objUsuarios = new Negocio.Usuarios();
            //UsuariosEntity = new Propiedades.Usuarios();
            objTipoEvento = new Negocio.TipoEvento();
            TipoEventoEntity = new Propiedades.TipoEvento();
            objGerentes = new Negocio.Gerentes();
            GerentesEntity = new Propiedades.Gerentes();
            objProductos = new Negocio.Productos();
            ProductosEntity = new Propiedades.Productos();
            objAreaTerapeutica = new Negocio.AreaTerapeutica();
            AreaTerapeuticaEntity = new Propiedades.AreaTerapeutica();
            objTipoAudiencia = new Negocio.TipoAudiencia();
            TipoAudienciaEntity = new Propiedades.TipoAudiencia();
            objGerenteTL = new Negocio.GerenteTL();
            GerenteTLEntity = new Propiedades.TeamLeader();
            objClienteInterno = new Negocio.ClienteInterno();
            ClienteInternoEntity = new Propiedades.ClienteInterno();
            objDivisiones = new Negocio.Divisiones();
            DivisionesEntity = new Propiedades.Divisiones();
            objUDN = new Negocio.UDN();
            UDNEntity = new Propiedades.UDN();
            objLocalizacion = new Negocio.Localizacion();
            LocalizacionEntity = new Propiedades.Localizacion();

            ml = new MensajesLocales();
        }

        public void LlenarGridView(GridView gridview, DataTable datatable)
        {
            gridview.DataSource = datatable;
            gridview.EmptyDataText = "No hay registros para mostrar.";
            gridview.DataBind();
        }

        public void LlenarGridView<T>(GridView gridview, List<T> lista)
        {
            gridview.DataSource = lista;
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
        public void LlenarDropDownList<T>(DropDownList dropdownlist, List<T> lista, string titulo, string valor)
        {
            dropdownlist.DataSource = lista;
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

        public void LlenarRadioButtonList<T>(RadioButtonList radiobuttonlist, List<T> lista, string titulo, string valor)
        {
            radiobuttonlist.DataSource = lista;
            radiobuttonlist.DataTextField = titulo;
            radiobuttonlist.DataValueField = valor;
            radiobuttonlist.DataBind();
        }

        public bool activoInactivo(object campo)
        {
            if (campo.ToString() == "Inactivo")
                return false;
            else if (campo.ToString() == "Activo")
                return true;
            else
                return false;
        }


    }
}