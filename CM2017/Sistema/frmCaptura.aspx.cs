using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Sistema
{
    public partial class frmCaptura : Comun
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaInicial();
                //Checar si se entrará en modo edición
                if (Request.QueryString["e"] == "1")
                {
                    CargarEvento(Request.QueryString["Id"]);
                }
            }
        }

        protected void CargaInicial()
        {
            CargarTipoEvento();
            CargarGerenteProducto();
            CargarGerenteProducto();
            CargarProducto();
            CargarTipoAudiencia();
            CargarLocacion();
            CargarDivision();
            CargarAreaTerapeutica();
            CargarTeamLeader();
        }
        protected void CargarTipoEvento()
        {           
            //Negocio.TipoEvento objTipoEvento = new Negocio.TipoEvento();
            LlenarDropDownList(ddlTipoEvento, objTipoEvento.TipoEventoActivoSelect(), "Descripcion", "IdTipEve");
        }
        protected void CargarGerenteProducto()
        {
            //Negocio.Gerentes objGerentes = new Negocio.Gerentes();
            LlenarDropDownList(ddlGteProd, objGerentes.GerentesActivoSelect(), "Nombre", "IdGerente");
        }
        protected void CargarProducto()
        {
            //Negocio.Productos objProductos = new Negocio.Productos();
            chkProducto.DataSource = objProductos.ProductosSelectActivos(); ;
            chkProducto.DataTextField= "Descripcion";
            chkProducto.DataValueField = "IdProducto";
            chkProducto.DataBind();
        }
        protected void CargarTipoAudiencia()
        {
            Negocio.TipoAudiencia objTipoAudiencia = new Negocio.TipoAudiencia();
            LlenarDropDownList(ddlAudiencia, objTipoAudiencia.TipoAudienciaActivoSelect(), "Descripcion", "IdAudiencia");
        }
        protected void CargarLocacion()
        {
            Negocio.Localizacion objLocalizacion = new Negocio.Localizacion();
            LlenarDropDownList(ddlLocalizacion, objLocalizacion.LocalizacionesActivoSelect(), "Nombre", "IdLoc");
        }
        protected void CargarDivision()
        {
            Negocio.Divisiones objDivisiones = new Negocio.Divisiones();
            LlenarRadioButtonList(rblDivision, objDivisiones.DivisionesActivoSelect(), "Descripcion", "IdDivision");
        }
        protected void CargarAreaTerapeutica()
        {
            Negocio.AreaTerapeutica objAreaTerapeutica = new Negocio.AreaTerapeutica();
            LlenarRadioButtonList(rblAT, objAreaTerapeutica.AreaTerapeuticaActivoSelect(), objAreaTerapeutica.DataText, objAreaTerapeutica.DataValue);
        }
        protected void CargarTeamLeader()
        {
            Negocio.GerenteTL objGerenteTL = new Negocio.GerenteTL();
            LlenarDropDownList(ddlTeamLeader, objGerenteTL.GerentesTLActivoSelect(), "Nombre", "IdTL");
        }
        protected void CargarEvento(string id)
        {
            Negocio.Eventos objEventos = new Negocio.Eventos();

            foreach (System.Data.DataRow row in objEventos.EventosSelectById(id).Rows)
            {
                TextBox1.Text = row["NombreEvento"] == DBNull.Value ? "" : row["NombreEvento"].ToString();
                TextBox2.Text = row["FechaSolicitud"] == DBNull.Value ? DateTime.Now.ToString() : DateTime.Parse(row["FechaSolicitud"].ToString()).ToString();
                TextBox3.Text = row["FechaInicioEvento"] == DBNull.Value ? DateTime.Now.ToString("dd/mm/yyyy") : DateTime.Parse(row["FechaInicioEvento"].ToString()).ToString("dd/MM/yyyy");
                TextBox4.Text = row["FechaFinEvento"] == DBNull.Value ? DateTime.Now.ToString("dd/mm/yyyy") : DateTime.Parse(row["FechaFinEvento"].ToString()).ToString("dd/MM/yyyy");
                ddlTipoEvento.SelectedValue = row["TipoEvento"] == DBNull.Value ? "1" : row["TipoEvento"].ToString();
                RadioButtonList2.SelectedValue = row["FlujoAutorizacion"] == DBNull.Value ? "1" : row["FlujoAutorizacion"].ToString();
                ddlGteProd.SelectedValue = row["GteProducto"] == DBNull.Value ? "1" : row["GteProducto"].ToString();

                string productosseleccionados = row["Producto"] == DBNull.Value ? "1" : row["Producto"].ToString().Trim();

                productosseleccionados = productosseleccionados.Replace("(","");
                productosseleccionados = productosseleccionados.Replace(")","");

                List<string> resultado = productosseleccionados.Split(',').ToList();

                foreach (ListItem item in chkProducto.Items)
                {
                    if (resultado.Contains(item.Value))
                        item.Selected = true;
                }

                ddlAudiencia.SelectedValue = row["TipoAudiencia"] == DBNull.Value ? "1" : row["TipoAudiencia"].ToString();
                TextBox5.Text = row["Invitados"] == DBNull.Value ? "" : row["Invitados"].ToString();
                TextBox6.Text = row["Objetivo"] == DBNull.Value ? "" : row["Objetivo"].ToString();
                RadioButtonList1.SelectedValue = row["Locacion1"] == DBNull.Value ? "1" : row["Locacion1"].ToString();
                ddlLocalizacion.SelectedValue = row["Locacion2"] == DBNull.Value ? "1" : row["Locacion2"].ToString();
                TextBox7.Text = row["Agenda"] == DBNull.Value ? "" : row["Agenda"].ToString();
                rblDivision.SelectedValue = row["Division"] == DBNull.Value ? "1" : row["Division"].ToString();
                rblAT.SelectedValue = row["AreaTerapeutica"] == DBNull.Value ? "1" : row["AreaTerapeutica"].ToString();
                ddlTeamLeader.SelectedValue = row["TeamLeader"] == DBNull.Value ? "1" : row["TeamLeader"].ToString();
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Guardar la captura del evento
            Negocio.EventosEntity eventosentity = new Negocio.EventosEntity();
            eventosentity.NombreEvento = TextBox1.Text == string.Empty ? "" : TextBox1.Text;
            eventosentity.FechaSolicitud = TextBox2.Text == string.Empty ? DateTime.Now : DateTime.Parse(TextBox2.Text);
            eventosentity.FechaInicioEvento = TextBox3.Text == string.Empty ? DateTime.Now : DateTime.Parse(TextBox3.Text);
            eventosentity.FechaFinEvento = TextBox4.Text == string.Empty ? DateTime.Now : DateTime.Parse(TextBox4.Text);
            eventosentity.TipoEvento = ddlTipoEvento.SelectedValue == string.Empty ? 0 : int.Parse(ddlTipoEvento.SelectedValue);
            eventosentity.FlujoAutorizacion = RadioButtonList2.SelectedValue == string.Empty ? 0 : int.Parse(RadioButtonList2.SelectedValue);
            eventosentity.GteProducto = ddlGteProd.SelectedValue == string.Empty ? 0 : int.Parse(ddlGteProd.SelectedValue);

            string seleccionados = "";
            foreach (ListItem item in chkProducto.Items)
            {
                if (item.Selected)
                {
                    seleccionados += item.Value + ",";
                }
            }

            eventosentity.Producto = seleccionados.Substring(0,seleccionados.Length-1);
            eventosentity.TipoAudiencia = ddlAudiencia.SelectedValue == string.Empty ? 0 : int.Parse(ddlAudiencia.SelectedValue);
            eventosentity.Invitados = TextBox5.Text == string.Empty ? 0 : int.Parse(TextBox5.Text);
            eventosentity.Objetivo = TextBox6.Text == string.Empty ? "" : TextBox6.Text;
            eventosentity.Locacion1 = RadioButtonList1.SelectedValue == string.Empty ? 0 : int.Parse(RadioButtonList1.SelectedValue);
            eventosentity.Locacion2 = ddlLocalizacion.SelectedValue == string.Empty ? 0 : int.Parse(ddlLocalizacion.SelectedValue);
            eventosentity.Agenda = TextBox7.Text == string.Empty ? "" : TextBox7.Text;
            eventosentity.Division = rblDivision.SelectedValue == string.Empty ? 0 : int.Parse(rblDivision.SelectedValue);
            eventosentity.AreaTerapeutica = rblAT.SelectedValue == string.Empty ? 0 : int.Parse(rblAT.SelectedValue);
            eventosentity.TeamLeader = ddlTeamLeader.SelectedValue == string.Empty ? 0 : int.Parse(ddlTeamLeader.SelectedValue);
            Negocio.Eventos objEventos = new Negocio.Eventos();
            string procesado = objEventos.EventoInsert(eventosentity);
            lblMsg.Text = "Se guardó el evento.";
        }


    }
}