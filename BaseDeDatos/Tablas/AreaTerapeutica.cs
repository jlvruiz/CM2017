using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaseDeDatos.Tablas
{
    public class AreaTerapeuticaEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class AreaTerapeutica : BaseDeDatos
    {
        public string _cadena = string.Empty;
        public string DataText = "Descripcion";
        public string DataValue = "IdAT";

        public DataTable AreaTerapeuticaSelect()
        {
            CreateTextCommand("select * from AreaTerapeutica");
            return Select();
        }
        public DataTable AreaTerapeuticaActivoSelect()
        {
            CreateTextCommand("select * from AreaTerapeutica where Visible=1");
            return Select();
        }
        public DataTable AreaTerapeuticaSelectById(AreaTerapeuticaEntity entidad)
        {
            CreateTextCommand("select * from AreaTerapeutica where IdAT=?");
            AddParameter("?", entidad.Id.ToString());
            return Select();
        }
        public int AreaTerapeuticaDesactivar(AreaTerapeuticaEntity entidad)
        {
            CreateTextCommand("update AreaTerapeutica set Visible=? where IdAT=? ");
            AddParameter("?", entidad.Activo.ToString());
            AddParameter("?", entidad.Id.ToString());
            return Update();
        }
        public int AreaTerapeuticaUpdate(AreaTerapeuticaEntity entidad)
        {
            CreateTextCommand("update AreaTerapeutica set Descripcion=?, Visible=? where IdAT=? ");
            AddParameter("?", entidad.Descripcion);
            AddParameter("?", entidad.Activo.ToString());
            AddParameter("?", entidad.Id.ToString());
            return Update();
        }
    }
}
