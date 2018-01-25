using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM2017.Admin
{
    public partial class frmEventosTerminados : Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = eventosterminados._title;

                //GridView1.PageIndex = 0;
                CargarEventos();
            }
        }

        protected void CargarEventos()
        {
            LlenarGridView(GridView1, objEventos.EventosTerminadosSelect());
        }



    
    }
}