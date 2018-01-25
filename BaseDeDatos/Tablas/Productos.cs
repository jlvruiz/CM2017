using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Productos : BaseDeDatos
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla
        /// </summary>
        /// <returns></returns>
        public DataTable ProductosSelect()
        {
            CreateTextCommand("SELECT * FROM Productos ORDER BY Descripcion");
            return Select();
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla que estén activos
        /// </summary>
        /// <returns></returns>
        public DataTable ProductosSelectActivos()
        {
            CreateTextCommand("SELECT * FROM Productos WHERE Visible=1");
            return Select();
        }

        /// <summary>
        /// Obtiene un registro de la tabla por su Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable ProductosSelectById(prop.Productos item)
        {
            CreateTextCommand("SELECT * FROM Productos WHERE IdProducto=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        /// <summary>
        /// Agrega un nuevo registro a la tabla
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ProductoInsert(prop.Productos item)
        {
            CreateTextCommand("INSERT INTO Productos (Descripcion, Visible) VALUES (?,?)");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            return Insert();
        }

        /// <summary>
        /// Cambia el estatus del registro a activo/inactivo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ProductosDesactivar(prop.Productos item)
        {
            CreateTextCommand("UPDATE Productos SET Visible=? WHERE IdProducto=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        /// <summary>
        /// Actualiza/Modifica un registro de la tabla por su Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ProductoUpdate(prop.Productos item)
        {
            CreateTextCommand("UPDATE Productos SET Descripcion=?, Visible=? WHERE IdProducto=? ");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

    }
}
