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
    public class Gerentes : BaseDeDatos
    {
        public DataTable GerentesSelect()
        {
            CreateTextCommand("SELECT IdGerente, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Activo FROM Gerentes ORDER BY Nombre");
            return Select();
        }
        public DataTable GerentesActivoSelect()
        {
            CreateTextCommand("SELECT IdGerente, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Activo FROM Gerentes WHERE Activo=1");
            return Select();
        }
        public DataTable GerentesSelectById(prop.Gerentes item)
        {
            CreateTextCommand("SELECT IdGerente, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Activo FROM Gerentes WHERE IdGerente=?");
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }
        public int GerenteDesactivar(prop.Gerentes item)
        {
            CreateTextCommand("UPDATE Gerentes SET Activo=? WHERE IdGerente=?");
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }
        public string GerenteInsert(prop.Gerentes item)
        {
            CreateTextCommand("INSERT INTO Gerentes (Nombre, Correo, Activo) VALUES (?,?,?)");
            AddParameter("?", item.Nombre, OleDbType.VarChar, 255);
            AddParameter("?", item.Correo, OleDbType.VarChar, 255);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            return Insert();
        }
        public int GerenteUpdate(prop.Gerentes item)
        {
            CreateTextCommand("UPDATE Gerentes SET Nombre=?, Correo=?, Activo=? WHERE IdGerente=?");
            AddParameter("?", item.Nombre, OleDbType.VarChar, 255);
            AddParameter("?", item.Correo, OleDbType.VarChar, 255);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }


    }
}
