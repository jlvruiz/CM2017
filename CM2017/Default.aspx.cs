using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.FindControl("Menu").Visible = false;

        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            //EventosServicios.EventosClient eventoS = new EventosServicios.EventosClient();
            //eventoS.TerminarEvento();
            Negocio.Eventos ev = new Negocio.Eventos();
            Negocio.TipoAudiencia ta = new Negocio.TipoAudiencia();
            ev.TerminarEvento();
            ta.TipoAudienciaBajaUltimoEvento();
            Response.Redirect("/Sistema/Inicio.aspx");
        }
    }
}