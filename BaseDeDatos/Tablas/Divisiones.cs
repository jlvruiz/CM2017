using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaseDeDatos.Tablas
{
    public class DivisionesEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class Divisiones : BaseDeDatos
    {
        public DataTable DivisionesSelect()
        {
            CreateTextCommand("select * from Divisiones");
            return Select();
        }
        public DataTable DivisionesActivoSelect()
        {
            CreateTextCommand("select * from Divisiones where Visible=1");
            return Select();
        }
        public DataTable DivisionesSelectById(DivisionesEntity item)
        {
            CreateTextCommand("select * from Divisiones where IdDivision=?");
            AddParameter("?", item.Id.ToString());
            return Select();
        }
        public int DivisionDesactivar(DivisionesEntity item)
        {
            CreateTextCommand("update Divisiones set Visible=? where IdDivision=? ");
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
        public int DivisionUpdate(DivisionesEntity item)
        {
            CreateTextCommand("update Divisiones set Descripcion=?, Visible=? where IdDivision=? ");
            AddParameter("?", item.Descripcion);
            AddParameter("?", item.Activo.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }


    }
}
