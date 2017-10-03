using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class AreaTerapeuticaEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class AreaTerapeutica
    {
        public string _cadena = string.Empty;

        public AreaTerapeutica(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public string DataText = "Descripcion";
        public string DataValue = "IdAT";

        public DataTable AreaTerapeuticaSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from AreaTerapeutica");
            return db.Select();
        }
        public DataTable AreaTerapeuticaActivoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from AreaTerapeutica where Visible=1");
            return db.Select();
        }
        public DataTable AreaTerapeuticaSelectById(AreaTerapeuticaEntity entidad)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from AreaTerapeutica where IdAT=?");
            db.AddParameter("?", entidad.Id.ToString());
            return db.Select();
        }
        public int AreaTerapeuticaDesactivar(AreaTerapeuticaEntity entidad)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update AreaTerapeutica set Visible=? where IdAT=? ");
            db.AddParameter("?", entidad.Activo.ToString());
            db.AddParameter("?", entidad.Id.ToString());
            return db.Update();
        }
        public int AreaTerapeuticaUpdate(AreaTerapeuticaEntity entidad)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update AreaTerapeutica set Descripcion=?, Visible=? where IdAT=? ");
            db.AddParameter("?", entidad.Descripcion);
            db.AddParameter("?", entidad.Activo.ToString());
            db.AddParameter("?", entidad.Id.ToString());
            return db.Update();
        }
    }
}
