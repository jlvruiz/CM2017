using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class GerenteTL : BaseDeDatos
    {
        public DataTable GerentesTLSelect()
        {
            CreateTextCommand("SELECT * FROM TeamLeaders");
            return Select();
        }

        public DataTable GerentesTLActivoSelect()
        {
            CreateTextCommand("SELECT * FROM TeamLeaders WHERE Activo=1");
            return Select();
        }

        public DataTable GerenteTLSelectById(prop.TeamLeader item)
        {
            CreateTextCommand("SELECT * FROM TeamLeaders WHERE IdTL=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        public string GerenteTLInsert(prop.TeamLeader item)
        {
            CreateTextCommand("INSERT INTO TeamLeaders (Nombre, Correo, Activo) VALUES (?,?,?)");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Correo);
            AddParameter("?", item.Activo.ToString());
            return Insert();
        }

        public int GerenteTLDesactivar(prop.TeamLeader item)
        {
            CreateTextCommand("UPDATE TeamLeaders SET Activo=? WHERE IdTL=?");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        public int GerenteTLUpdate(prop.TeamLeader item)
        {
            CreateTextCommand("UPDATE TeamLeaders SET Nombre=?, Correo=?, Activo=? WHERE IdTL=?");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Correo);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
    }
}
