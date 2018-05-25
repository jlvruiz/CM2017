using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CM2017
{
    public class MensajesLocales
    {

        public void MensajeSimple(Page PaginaActual, string mensaje)
        {
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "Mensajes", "bootbox.alert({ message: '" + mensaje + "', size: 'small'} );", true);
        }

        public void MensajeSimple2(Page PaginaActual, string mensaje)
        {
            PaginaActual.ClientScript.RegisterStartupScript(PaginaActual.GetType(), "Mensajes", "bootbox.alert({ message: '" + mensaje + "', size: 'small'} );", true);
        }




        /// <summary>
        /// Muestra mensajes usando un ScriptManager
        /// </summary>
        /// <param name="PaginaActual"></param>
        /// <param name="mensaje"></param>
        public void MensajePeligroSM(Page PaginaActual, string mensaje)
        {
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "Mensajes", "bootbox.alert({ message: '" + mensaje + "'} );", true);
        }

        /// <summary>
        /// Muestra mensajes usando un ClientScript
        /// </summary>
        /// <param name="PaginaActual"></param>
        /// <param name="mensaje"></param>
        public void MensajePeligroCS(Page PaginaActual, string mensaje)
        {
            //PaginaActual.ClientScript.RegisterStartupScript(PaginaActual.GetType(), "toastMessage", "$().toastmessage('showErrorToast', '" + mensaje + "');", true);
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "Mensajes", "bootbox.alert({ message: '" + mensaje + "'} );", true);
        }

        /// <summary>
        /// Muestra mensajes usando un ScriptManager
        /// </summary>
        /// <param name="PaginaActual"></param>
        /// <param name="mensaje"></param>
        public void MensajeAdvertenciaSM(Page PaginaActual, string mensaje)
        {
            //ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "toastMessage", " $().toastmessage('showWarningToast', '"+ mensaje +"');", true);
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "Mensajes", "bootbox.alert({ message: '" + mensaje + "'} );", true);
        }

        /// <summary>
        /// Muestra mensajes usando un ClientScript
        /// </summary>
        /// <param name="PaginaActual"></param>
        /// <param name="mensaje"></param>
        public void MensajeAdvertenciaCS(Page PaginaActual, string mensaje)
        {
            //PaginaActual.ClientScript.RegisterStartupScript(PaginaActual.GetType(), "toastMessage", "$().toastmessage('showWarningToast', '" + mensaje + "');", true);
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "Mensajes", "bootbox.alert({ message: '" + mensaje + "'} );", true);
        }

        /// <summary>
        /// Muestra mensajes usando un ScriptManager
        /// </summary>
        /// <param name="PaginaActual"></param>
        /// <param name="mensaje"></param>
        public void MensajeExitosoSM(Page PaginaActual, string mensaje)
        {
            //ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "toastMessage", " $().toastmessage('showSuccessToast', '" + mensaje + "');", true);
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "Mensajes", "bootbox.alert({ message: '" + mensaje + "'} );", true);
        }

        /// <summary>
        /// Muestra mensajes usando un ClientScript
        /// </summary>
        /// <param name="PaginaActual"></param>
        /// <param name="mensaje"></param>
        public void MensajeExitosoCL(Page PaginaActual, string mensaje)
        {
            PaginaActual.ClientScript.RegisterStartupScript(PaginaActual.GetType(), "toastMessage", "bootbox.alert({ message: '" + mensaje + "'} );", true);
        }

        //Mostrar/Ocultar pantalla de bloqueo

         /// <summary>
         /// Muestra la pantalla de bloqueo usando un ScriptManager
         /// </summary>
         /// <param name="PaginaActual"></param>
        public void AbrirPantallaBloqueoSM(Page PaginaActual)
        {
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "abrirPantallaBloqueo", "javascript: $('#divPantallaBloqueo').show(); $('#divEncima').show();", true);
        }

        /// <summary>
        /// Oculta la pantalla de bloqueo
        /// </summary>
        /// <param name="PaginaActual"></param>
        public void OcultarPantallaBloqueoSM(Page PaginaActual)
        {
            ScriptManager.RegisterStartupScript(PaginaActual, GetType(), "toastMessage", "$('#divPantallaBloqueo').hide('slow');", true);
        }


    }
}