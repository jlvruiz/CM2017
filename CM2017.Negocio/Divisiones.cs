using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class DivisionesEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class Divisiones
    {
        BaseDeDatos.BaseDeDatos db = new BaseDeDatos.BaseDeDatos("");

        public DataTable DivisionesSelect()
        {
            db.CreateTextCommand("select * from Divisiones");
            return db.Select();
        }
        public DataTable DivisionesActivoSelect()
        {
            db.CreateTextCommand("select * from Divisiones where Visible=1");
            return db.Select();
        }
        public DataTable DivisionesSelectById(DivisionesEntity item)
        {
            db.CreateTextCommand("select * from Divisiones where IdDivision=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }
        public int DivisionDesactivar(DivisionesEntity item)
        {
            db.CreateTextCommand("update Divisiones set Visible=? where IdDivision=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
        public int DivisionUpdate(DivisionesEntity item)
        {
            db.CreateTextCommand("update Divisiones set Descripcion=?, Visible=? where IdDivision=? ");
            db.AddParameter("?", item.Descripcion);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }


    }
}
