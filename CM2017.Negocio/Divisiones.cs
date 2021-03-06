﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class Divisiones : Comun
    {
        public string _title = "Divisiones";

        public DataTable DivisionesSelect()
        {
            return di.DivisionesSelect();
        }

        public DataTable DivisionesActivoSelect()
        {
            return di.DivisionesActivoSelect();
        }

        public DataTable DivisionesSelectById(prop.Divisiones item)
        {
            return di.DivisionesSelectById(item);
        }

        public int DivisionDesactivar(prop.Divisiones item)
        {
            return di.DivisionDesactivar(item);
        }

        public int DivisionUpdate(prop.Divisiones item)
        {
            return di.DivisionUpdate(item);
        }

        public void cargarDivisiones_RadioButtonList(ref System.Web.UI.WebControls.RadioButtonList radiobuttonlist)
        {
            Controles.LlenarRadioButtonList(ref radiobuttonlist, di.DivisionesActivoSelect(), "Descripcion", "IdDivision");
        }


    }
}
