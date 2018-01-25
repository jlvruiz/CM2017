﻿using System;
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
            Negocio.Eventos ev = new Negocio.Eventos();
            ev.TerminarEvento();
            Response.Redirect("/Sistema/Inicio.aspx");
        }
    }
}