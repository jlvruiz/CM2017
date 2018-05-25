using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Sistema
{
    public partial class frmEstadisticas :  Comun
    {
        public int terminados = 0;
        public int desactivados = 0;
        public int activos = 0;

        #region Eventos ********************************************************************************************************

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sesion"] == null)
                Response.Redirect("Default.aspx");

            Page.Title = objEstadisticas._title;
            terminados = objEventos.EventosEstadisticasTerminados();
            desactivados = objEventos.EventosEstadisticasCancelados();
            activos = objEventos.EventosEstadisticasEnProceso();
        }

        #endregion
    }
}