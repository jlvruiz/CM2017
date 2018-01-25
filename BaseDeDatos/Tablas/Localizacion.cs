using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Localizacion : BaseDeDatos
    {
        public DataTable LocalizacionesSelect()
        {
            CreateTextCommand("SELECT * FROM Localizacion ORDER BY Nombre");
            return Select();
        }
        public DataTable LocalizacionesActivoSelect()
        {
            CreateTextCommand("SELECT * FROM Localizacion WHERE Visible=1");
            return Select();
        }
        public DataTable LocalizacionSelectById(prop.Localizacion item)
        {
            CreateTextCommand("SELECT * FROM Localizacion WHERE IdLoc=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        public string LocalizacionInsert(prop.Localizacion item)
        {
            CreateTextCommand("INSERT INTO Localizacion (Nombre,Tipo,Motivo,Visible) VALUES (?,?,?,?)");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Tipo.ToString());
            AddParameter("?", item.Motivo);
            AddParameter("?", item.Activo.ToString());
            return Insert();
        }

        public int LocalizacionDesactivar(prop.Localizacion item)
        {
            CreateTextCommand("UPDATE Localizacion SET Visible=? WHERE IdLoc=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        public int LocalizacionUpdate(prop.Localizacion item)
        {
            CreateTextCommand("UPDATE Localizacion SET Nombre=?, Tipo=?, Motivo=?, Visible=? WHERE IdLoc=? ");
            AddParameter("?", item.Nombre);
            AddParameter("?", item.Tipo.ToString());
            AddParameter("?", item.Motivo);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
    }
}
