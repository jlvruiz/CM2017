using System.Data;
using System.Data.OleDb;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class AreaTerapeutica : BaseDeDatos
    {
        public string DataText = "Descripcion";
        public string DataValue = "IdAT";

        /// <summary>
        /// AT-01
        /// </summary>
        /// <returns></returns>
        public DataTable AreaTerapeuticaSelect()
        {
            CreateTextCommand("SELECT IdAT, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM AreaTerapeutica");
            return Select();
        }
        /// <summary>
        /// AT-02
        /// </summary>
        /// <returns></returns>
        public DataTable AreaTerapeuticaSelectActivo()
        {
            CreateTextCommand("SELECT IdAT, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM AreaTerapeutica WHERE Visible=1");
            return Select();
        }
        /// <summary>
        /// AT-03
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public DataTable AreaTerapeuticaSelectById(prop.AreaTerapeutica entidad)
        {
            CreateTextCommand("SELECT IdAT, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM AreaTerapeutica WHERE IdAT=?");
            AddParameter("?", entidad.Id, OleDbType.VarChar);
            return Select();
        }
        /// <summary>
        /// AT-04
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string AreaTerapeuticaSelectEstatus(object id)
        {
            CreateTextCommand("SELECT visible FROM AreaTerapeutica WHERE IdAT=? ");
            AddParameter("?", id, OleDbType.Numeric);
            return Select().Rows[0][0].ToString();
        }
        /// <summary>
        /// AT-40
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public int AreaTerapeuticaUpdateDesactivar(prop.AreaTerapeutica entidad)
        {
            CreateTextCommand("UPDATE AreaTerapeutica SET Visible=? WHERE IdAT=? ");
            AddParameter("?", entidad.Activo, OleDbType.VarChar);
            AddParameter("?", entidad.Id, OleDbType.Numeric);
            return Update();
        }
        /// <summary>
        /// AT-41
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public int AreaTerapeuticaUpdate(prop.AreaTerapeutica entidad)
        {
            CreateTextCommand("UPDATE AreaTerapeutica SET Descripcion=?, Visible=? WHERE IdAT=? ");
            AddParameter("?", entidad.Descripcion, OleDbType.VarChar);
            AddParameter("?", entidad.Activo, OleDbType.Numeric);
            AddParameter("?", entidad.Id, OleDbType.Numeric);
            return Update();
        }
    }
}
