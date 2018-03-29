using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            CreateTextCommand("SELECT IdProducto, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Productos ORDER BY Descripcion");
            return Select();
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla que estén activos
        /// </summary>
        /// <returns></returns>
        public DataTable ProductosSelectActivos()
        {
            CreateTextCommand("SELECT IdProducto, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Productos WHERE Visible=1");
            return Select();
        }

        /// <summary>
        /// Obtiene un registro de la tabla por su Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable ProductosSelectById(prop.Productos item)
        {
            CreateTextCommand("SELECT IdProducto, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Productos WHERE IdProducto=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
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
            AddParameter("?", item.Descripcion, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
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
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
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
            AddParameter("?", item.Descripcion, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

    }
}
