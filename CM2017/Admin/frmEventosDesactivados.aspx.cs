using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmEventosDesactivados : Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = eventosdesactivados._title;

                //GridView1.PageIndex = 0;
                CargarEventos();
            }
        }

        protected void CargarEventos()
        {
            LlenarGridView(GridView1, objEventos.EventosDesactivadosSelect());
        }

        protected void LigaActivar_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string val = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            if (objEventos.EventoReactivar(val))
                CargarEventos();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "toastMessage", " $().toastmessage('showWarningToast', '<br />No se puede reactivar este evento porque unos de sus elementos esta inactivo, debe crear uno nuevo');", true);
        }
    }
}