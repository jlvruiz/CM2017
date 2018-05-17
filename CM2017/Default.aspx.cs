using CM2017.IU;
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
        Concentrador Manejador_Sesion = new Concentrador();

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.FindControl("Menu").Visible = false;

        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            //EventosServicios.EventosClient eventoS = new EventosServicios.EventosClient();
            //eventoS.TerminarEvento();

            Manejador_Sesion.Inicializar();
            Manejador_Sesion.Usuarios.Nombre = "Administrador";
            Manejador_Sesion.Usuarios.Clave = "admin";
            Manejador_Sesion.Usuarios.Contra = "admin";
            Manejador_Sesion.Sistema.DireccionIP = "Pendiente";
            Manejador_Sesion.Sistema.Permisos = "0";
            Session["sesion"] = Manejador_Sesion;

            Negocio.Eventos ev = new Negocio.Eventos();
            Negocio.TipoAudiencia ta = new Negocio.TipoAudiencia();
            ev.TerminarEvento();
            ta.TipoAudienciaBajaUltimoEvento();
            if (LoginValidacion())
                Response.Redirect("/Sistema/Inicio.aspx");
        }

        protected bool LoginValidacion()
        {
            //validar el usuario que ha entrado
            if (txtClave.Text == "" && txtContra.Text == "")
            {
                
                return true;
            }
            else
                return false;
        }

        string prueba = "";

    }
}