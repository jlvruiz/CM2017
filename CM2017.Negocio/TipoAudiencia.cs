using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class TipoAudiencia : Comun
    {
        public string _title = "Tipo de Audiencia";

        public DataTable TipoAudienciaSelect()
        {
            return ta.TipoAudienciaSelect();
        }

        public DataTable TipoAudienciaActivoSelect()
        {
            return ta.TipoAudienciaActivoSelect();
        }

        public DataTable TipoAudienciaSelectById(prop.TipoAudiencia item)
        {
            return ta.TipoAudienciaSelectById(item);
        }

        public int TipoAudienciaDesactivar(prop.TipoAudiencia item)
        {
            if (validarTipoAudiencia(item.Id))
                return ta.TipoAudienciaDesactivar(item);
            else
                return 0;
        }

        public int TipoAudienciaUpdate(prop.TipoAudiencia item)
        {
            return ta.TipoAudienciaUpdate(item);
        }

        public bool validarTipoAudiencia(object idtipoaudiencia)
        {
            return ev.validarAudiencia(idtipoaudiencia);
        }

        public bool TipoAudienciaValidarSiBajaUltimoEvento(object id)
        {
            DataTable dt = new DataTable();
            dt = ta.TipoAudienciaValidarSiBajaUltimoEvento(id);
            if (dt.Rows[0][0].ToString() == "2")
                return true;
            else
                return false;
        }

        public bool TipoAudienciaEstatus(object id)
        {
            string obtenido = ta.TipoAudienciaEstatus(id);
            if (obtenido == "0")
                return false;
            else
                return true;
        }

        public void TipoAudienciaBajaUltimoEvento()
        {
            //Da de baja definitiva una opción si se ha indicado
            //y ya no podrá aparecer más para  agregarse a nuevos eventos
            DataTable dt = new DataTable();
            dt = ta.TipoAudienciaBajaUltimoEvento();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ta.TipoAudienciaBajaEnUltimoEvento(int.Parse(dr["Id"].ToString()));
                }
            }
        }

        public void cargarTipoAudiencia_DropDownList(ref System.Web.UI.WebControls.DropDownList dropdownlist)
        {
            Controles.LlenarDropDownList(ref dropdownlist,  ta.TipoAudienciaActivoSelect(), "Descripcion", "IdAudiencia");
        }



    }
}
