using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class ProductosEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class Productos
    {
        public string _cadena = string.Empty;

        public Productos(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        /// <summary>
        /// Selecciona todos los registros de la tabla
        /// </summary>
        /// <returns></returns>
        public DataTable ProductosSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Productos order by Descripcion");
            return db.Select();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla que estén activos
        /// </summary>
        /// <returns></returns>
        public DataTable ProductosSelectActivos()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Productos where Visible=1");
            return db.Select();
        }
        /// <summary>
        /// Obtiene un registro de la tabla por su Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable ProductosSelectById(ProductosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Productos where IdProducto=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }
        /// <summary>
        /// Cambia el estatus del registro a activo/inactivo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ProductosDesactivar(ProductosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Productos set Visible=? where IdProducto=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
        /// <summary>
        /// Agrega un nuevo registro a la tabla
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ProductoInsert(ProductosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("insert into Productos (Descripcion, Visible) values (?,?)");
            db.AddParameter("?", item.Descripcion);
            db.AddParameter("?", item.Activo.ToString());
            return db.Insert();
        }
        /// <summary>
        /// Actualiza/Modifica un registro de la tabla por su Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ProductoUpdate(ProductosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Productos set Descripcion=?, Visible=? where IdProducto=? ");
            db.AddParameter("?", item.Descripcion);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

    }
}
