using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaseDeDatos.Tablas
{
    public class ClienteInternoEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }

    public class ClienteInterno : BaseDeDatos
    {
        public DataTable ClienteInternoSelect()
        {
            CreateTextCommand("select * from ClienteInterno order by Descripcion");
            return Select();
        }

        public DataTable ClienteInternoSelectById(ClienteInternoEntity item)
        {
            CreateTextCommand("select * from ClienteInterno where IdCteInt=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }

        public int ClienteInternoDesactivar(ClienteInternoEntity item)
        {
            CreateTextCommand("update ClienteInterno set Visible=? where IdCteInt=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }

        public int ClienteInternoUpdate(ClienteInternoEntity item)
        {
            CreateTextCommand("update ClienteInterno set Descripcion=?, Visible=? where IdCteInt=? ");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }


    }
}
