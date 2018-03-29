using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class TipoEvento : Comun
    {
        public string _title = "Tipo de Evento";

        public DataTable TipoEventoSelect()
        {
            return te.TipoEventoSelect();
        }

        public DataTable TipoEventoActivoSelect()
        {
            return te.TipoEventoActivoSelect();
        }

        public DataTable TipoEventoSelectById(prop.TipoEvento item)
        {
            return te.TipoEventoSelectById(item);
        }

        public string TipoEventoInsert(prop.TipoEvento item)
        {
            return te.TipoEventoInsert(item);
        }

        public int TipoEventoUpdate(prop.TipoEvento item)
        {
            return te.TipoEventoUpdate(item);
        }

        public int TipoEventoDesactivar(prop.TipoEvento item)
        {
            if (!validarTipoEvento(item.Id))
                return te.TipoEventoDesactivar(item);
            else
                return 0;
        }

        public bool validarTipoEvento(object idtipoevento)
        {
            return ev.validarTipoEvento(idtipoevento);
        }

        public bool TipoEventoEstatus(object id)
        {
            string obtenido = te.TipoEventoEstatus(id);
            if (obtenido == "0")
                return false;
            else
                return true;
        }

        public void cargarTipoEvento_DropDownList(ref System.Web.UI.WebControls.DropDownList dropdownlist)
        {
            Controles.LlenarDropDownList(ref dropdownlist, te.TipoEventoActivoSelect(), "Descripcion", "IdTipEve");
        }

    }
}
