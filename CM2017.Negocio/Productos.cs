using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace CM2017.Negocio
{
    public class Productos : Comun
    {
        public string _title = "Productos";

        /// <summary>
        /// Selecciona todos los registros de la tabla
        /// </summary>
        /// <returns></returns>
        public DataTable ProductosSelect()
        {
            return pr.ProductosSelect();
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla que estén activos
        /// </summary>
        /// <returns></returns>
        public DataTable ProductosSelectActivos()
        {
            return pr.ProductosSelectActivos();
        }

        /// <summary>
        /// Obtiene un registro de la tabla por su Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable ProductosSelectById(prop.Productos item)
        {
            return pr.ProductosSelectById(item);
        }

        /// <summary>
        /// Cambia el estatus del registro a activo/inactivo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ProductosDesactivar(prop.Productos item)
        {
            return pr.ProductosDesactivar(item);
        }

        /// <summary>
        /// Agrega un nuevo registro a la tabla
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ProductoInsert(prop.Productos item)
        {
            return pr.ProductoInsert(item);
        }

        /// <summary>
        /// Actualiza/Modifica un registro de la tabla por su Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ProductoUpdate(prop.Productos item)
        {
            return pr.ProductoUpdate(item);
        }

        public void cargarProductos_CheckBoxList(ref System.Web.UI.WebControls.CheckBoxList checkboxlist)
        {
            Controles.LlenarCheckBoxList(ref checkboxlist, pr.ProductosSelectActivos(), "Descripcion", "IdProducto");
        }



    }
}
