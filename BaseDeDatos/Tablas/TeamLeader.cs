using System.Data;
using System.Data.OleDb;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class GerenteTL : BaseDeDatos
    {
        /// <summary>
        /// TL-01
        /// </summary>
        /// <returns></returns>
        public DataTable GerentesTLSelect()
        {
            CreateTextCommand("SELECT IdTL, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Activo FROM TeamLeaders");
            return Select();
        }

        /// <summary>
        /// TL-02
        /// </summary>
        /// <returns></returns>
        public DataTable GerentesTLActivoSelect()
        {
            CreateTextCommand("SELECT IdTL, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Activo FROM TeamLeaders WHERE Activo=1");
            return Select();
        }

        /// <summary>
        /// TL-03
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable GerenteTLSelectById(prop.TeamLeader item)
        {
            CreateTextCommand("SELECT IdTL, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Activo FROM TeamLeaders WHERE IdTL=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }

        /// <summary>
        /// TL-31
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GerenteTLInsert(prop.TeamLeader item)
        {
            CreateTextCommand("INSERT INTO TeamLeaders (Nombre, Correo, Activo) VALUES (?,?,?)");
            AddParameter("?", item.Nombre, OleDbType.VarChar);
            AddParameter("?", item.Correo, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            return Insert();
        }

        /// <summary>
        /// TL-41
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GerenteTLDesactivar(prop.TeamLeader item)
        {
            CreateTextCommand("UPDATE TeamLeaders SET Activo=? WHERE IdTL=?");
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        /// <summary>
        /// TL-42
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GerenteTLUpdate(prop.TeamLeader item)
        {
            CreateTextCommand("UPDATE TeamLeaders SET Nombre=?, Correo=?, Activo=? WHERE IdTL=?");
            AddParameter("?", item.Nombre, OleDbType.VarChar);
            AddParameter("?", item.Correo, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }




    }
}
