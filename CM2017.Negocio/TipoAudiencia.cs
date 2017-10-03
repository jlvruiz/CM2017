using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class TipoAudienciaEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
    public class TipoAudiencia
    {
        public string _cadena = string.Empty;

        public TipoAudiencia(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public DataTable TipoAudienciaSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Audiencia order by Descripcion");
            return db.Select();
        }
        public DataTable TipoAudienciaActivoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Audiencia where Visible=1");
            return db.Select();
        }
        public DataTable TipoAudienciaSelectById(TipoAudienciaEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from Audiencia where IdAudiencia=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }
        public int TipoAudienciaDesactivar(TipoAudienciaEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Audiencia set Visible=? where IdAudiencia=? ");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
        public int TipoAudienciaUpdate(TipoAudienciaEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update Audiencia set Descripcion=?, Visible=? where IdAudiencia=? ");
            db.AddParameter("?", item.Descripcion);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
    }
}
