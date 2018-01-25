using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Gerentes : BaseDeDatos
    {
        public DataTable GerentesSelect()
        {
            CreateTextCommand("SELECT * FROM Gerentes ORDER BY Nombre");
            return Select();
        }
        public DataTable GerentesActivoSelect()
        {
            CreateTextCommand("SELECT * FROM Gerentes WHERE Activo=1");
            return Select();
        }
        public DataTable GerentesSelectById(prop.Gerentes item)
        {
            CreateTextCommand("SELECT * FROM Gerentes WHERE IdGerente=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }
        public int GerenteDesactivar(prop.Gerentes item)
        {
            CreateTextCommand("UPDATE Gerentes SET Activo=? WHERE IdGerente=?");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
        public string GerenteInsert(prop.Gerentes item)
        {
            CreateTextCommand("INSERT INTO Gerentes (Nombre, Correo, Activo) VALUES (?,?,?)");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Correo);
            AddParameter("?", item.Activo.ToString());
            return Insert();
        }
        public int GerenteUpdate(prop.Gerentes item)
        {
            CreateTextCommand("UPDATE Gerentes SET Nombre=?, Correo=?, Activo=? WHERE IdGerente=?");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Correo);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }


    }
}
