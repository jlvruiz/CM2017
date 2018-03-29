using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Sistema
{
    public partial class frmCaptura : Comun
    {

        #region Eventos ********************************************************************************************************
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = captura._title;

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

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Modificar ó Guardar
            Propiedades.Eventos eventosentity = new Propiedades.Eventos();
            eventosentity.NombreEvento = TextBox1.Text == string.Empty ? "" : TextBox1.Text;
            eventosentity.FechaSolicitud = TextBox2.Text == string.Empty ? DateTime.Parse(DateTime.Now + " " + DateTime.Now.ToLongTimeString()) : DateTime.Parse(DateTime.Parse(TextBox2.Text) + "" + DateTime.Now.ToLongTimeString());
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
                    seleccionados += item.Text + ", ";
                }
            }
            eventosentity.Producto = seleccionados.Substring(0, seleccionados.Length - 1);
            eventosentity.TipoAudiencia = ddlAudiencia.SelectedValue == string.Empty ? 0 : int.Parse(ddlAudiencia.SelectedValue);
            eventosentity.Invitados = TextBox5.Text == string.Empty ? 0 : int.Parse(TextBox5.Text);
            eventosentity.Objetivo = TextBox6.Text == string.Empty ? "" : TextBox6.Text;
            eventosentity.Locacion1 = RadioButtonList1.SelectedValue == string.Empty ? 0 : int.Parse(RadioButtonList1.SelectedValue);
            eventosentity.Locacion2 = ddlLocalizacion.SelectedValue == string.Empty ? 0 : int.Parse(ddlLocalizacion.SelectedValue);
            eventosentity.Agenda = TextBox7.Text == string.Empty ? "" : TextBox7.Text;
            eventosentity.Division = rblDivision.SelectedValue == string.Empty ? 0 : int.Parse(rblDivision.SelectedValue);
            eventosentity.AreaTerapeutica = rblAT.SelectedValue == string.Empty ? 0 : int.Parse(rblAT.SelectedValue);
            eventosentity.TeamLeader = ddlTeamLeader.SelectedValue == string.Empty ? 0 : int.Parse(ddlTeamLeader.SelectedValue);
            if (Request.QueryString["Id"] != null)
                eventosentity.Id = int.Parse(Request.QueryString["Id"]);

            //Guardar el evento modificado
            if (Request.QueryString["e"] == "1")
            {
                string procesado = objEventos.EventoUpdate(eventosentity).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showSuccessToast', 'Se guardó el evento modificado.');", true);
            }
            else //Guardar la captura del evento nuevo
            {
                string procesado = objEventos.EventoInsert(eventosentity);
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showSuccessToast', 'Se guardó el nuevo evento.');", true);
            }
        }

        protected void ddlAudiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Validar si se dará de baja una opción e impedir que el usuario la use
            ValidarSiOpcionSeraDadaDeBaja();
        }

        #endregion

        #region Métodos ********************************************************************************************************

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
            objTipoEvento.cargarTipoEvento_DropDownList(ref ddlTipoEvento);
        }

        protected void CargarGerenteProducto()
        {
            objGerentes.cargarGerentes_DropDownList(ref ddlGteProd);
        }

        protected void CargarProducto()
        {
            objProductos.cargarProductos_CheckBoxList(ref chkProducto);
        }

        protected void CargarTipoAudiencia()
        {
            objTipoAudiencia.cargarTipoAudiencia_DropDownList(ref ddlAudiencia);
        }

        protected void CargarLocacion()
        {
            objLocalizacion.cargarLocalizacion_DropDownList(ref ddlLocalizacion);
        }

        protected void CargarDivision()
        {
            objDivisiones.cargarDivisiones_RadioButtonList(ref rblDivision);
        }

        protected void CargarAreaTerapeutica()
        {
            objAreaTerapeutica.cargarAreaTerapeutica_RadioButtonList(ref rblAT);
        }

        protected void CargarTeamLeader()
        {
            objGerenteTL.cargarTeamLeader_DropDownList(ref ddlTeamLeader);
        }

        protected void CargarEvento(string id)
        {
            try
            {
                foreach (System.Data.DataRow row in objEventos.EventosSelectById(id).Rows)
                {
                    TextBox1.Text =                     row["NombreEvento"]         == DBNull.Value ? "" : row["NombreEvento"].ToString();
                    TextBox2.Text =                     row["FechaSolicitud"]       == DBNull.Value ? DateTime.Now.ToString() : DateTime.Parse(row["FechaSolicitud"].ToString()).ToString("dd/MM/yyyy");
                    TextBox3.Text =                     row["FechaInicioEvento"]    == DBNull.Value ? DateTime.Now.ToString("dd/mm/yyyy") : DateTime.Parse(row["FechaInicioEvento"].ToString()).ToString("dd/MM/yyyy");
                    TextBox4.Text =                     row["FechaFinEvento"]       == DBNull.Value ? DateTime.Now.ToString("dd/mm/yyyy") : DateTime.Parse(row["FechaFinEvento"].ToString()).ToString("dd/MM/yyyy");
                    ddlTipoEvento.SelectedValue =       row["TipoEvento"]           == DBNull.Value ? "1" : row["TipoEvento"].ToString();
                    RadioButtonList2.SelectedValue =    row["FlujoAutorizacion"]    == DBNull.Value ? "1" : row["FlujoAutorizacion"].ToString();
                    ddlGteProd.SelectedValue =          row["GteProducto"]          == DBNull.Value ? "1" : row["GteProducto"].ToString();

                    string productosseleccionados =     row["Producto"]             == DBNull.Value ? "1" : row["Producto"].ToString().Trim();

                    productosseleccionados = productosseleccionados.Replace("(", "");
                    productosseleccionados = productosseleccionados.Replace(")", "");

                    List<string> resultado = productosseleccionados.Split(',').ToList();

                    foreach (ListItem item in chkProducto.Items)
                    {
                        if (resultado.Contains(item.Value))
                            item.Selected = true;
                    }

                    ddlAudiencia.SelectedValue =        row["TipoAudiencia"]    == DBNull.Value ? "1" : row["TipoAudiencia"].ToString();
                    TextBox5.Text =                     row["Invitados"]        == DBNull.Value ? "" : row["Invitados"].ToString();
                    TextBox6.Text =                     row["Objetivo"]         == DBNull.Value ? "" : row["Objetivo"].ToString();
                    RadioButtonList1.SelectedValue =    row["Locacion1"]        == DBNull.Value ? "1" : row["Locacion1"].ToString();
                    ddlLocalizacion.SelectedValue =     row["Locacion2"]        == DBNull.Value ? "1" : row["Locacion2"].ToString();
                    TextBox7.Text =                     row["Agenda"]           == DBNull.Value ? "" : row["Agenda"].ToString();
                    rblDivision.SelectedValue =         row["Division"]         == DBNull.Value ? "1" : row["Division"].ToString();
                    rblAT.SelectedValue =               row["AreaTerapeutica"]  == DBNull.Value ? "1" : row["AreaTerapeutica"].ToString();
                    ddlTeamLeader.SelectedValue =       row["TeamLeader"]       == DBNull.Value ? "1" : row["TeamLeader"].ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showErrorToast', 'Error en CargarEventos: " + ex.Message + "');", true);
            }
        }

        protected void ValidarSiOpcionSeraDadaDeBaja()
        {
            if (objTipoAudiencia.TipoAudienciaValidarSiBajaUltimoEvento(ddlAudiencia.SelectedValue))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showWarningToast', 'No puede usar " + ddlAudiencia.SelectedItem.Text + " porque será  dado de baja.');", true);
                return;
            }
        }

        #endregion
    }
}