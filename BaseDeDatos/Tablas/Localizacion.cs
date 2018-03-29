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
    public class Localizacion : BaseDeDatos
    {
        public DataTable LocalizacionesSelect()
        {
            CreateTextCommand("SELECT IdLoc, Nombre, Tipo, Motivo, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Localizacion ORDER BY Nombre");
            return Select();
        }
        public DataTable LocalizacionesActivoSelect()
        {
            CreateTextCommand("SELECT IdLoc, Nombre, Tipo, Motivo, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Localizacion WHERE Visible=1");
            return Select();
        }
        public DataTable LocalizacionSelectById(prop.Localizacion item)
        {
            CreateTextCommand("SELECT IdLoc, Nombre, Tipo, Motivo, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Localizacion WHERE IdLoc=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }

        public string LocalizacionInsert(prop.Localizacion item)
        {
            CreateTextCommand("INSERT INTO Localizacion (Nombre,Tipo,Motivo,Visible) VALUES (?,?,?,?)");
            AddParameter("?", item.Nombre, OleDbType.VarChar);
            AddParameter("?", item.Tipo, OleDbType.Numeric);
            AddParameter("?", item.Motivo, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            return Insert();
        }

        public int LocalizacionDesactivar(prop.Localizacion item)
        {
            CreateTextCommand("UPDATE Localizacion SET Visible=? WHERE IdLoc=? ");
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        public int LocalizacionUpdate(prop.Localizacion item)
        {
            CreateTextCommand("UPDATE Localizacion SET Nombre=?, Tipo=?, Motivo=?, Visible=? WHERE IdLoc=? ");
            AddParameter("?", item.Nombre, OleDbType.VarChar);
            AddParameter("?", item.Tipo, OleDbType.Numeric);
            AddParameter("?", item.Motivo, OleDbType.VarChar);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }
    }
}
