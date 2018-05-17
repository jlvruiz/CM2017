using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class TipoAudiencia: BaseDeDatos
    {
        public DataTable TipoAudienciaSelect()
        {
            string consulta = "SELECT IdAudiencia, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible, SWITCH (Bloqueado = 2, 'Bloqueado para no mostrarse más', Bloqueado = 0, '') AS Bloqueado FROM Audiencia ORDER BY Descripcion";
            CreateTextCommand(consulta);
            return Select();
        }

        public DataTable TipoAudienciaActivoSelect()
        {
            string consulta = "SELECT IdAudiencia, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible FROM Audiencia WHERE Visible=1";
            CreateTextCommand(consulta);
            return Select();
        }

        public DataTable TipoAudienciaSelectById(prop.TipoAudiencia item)
        {
            string consulta = "SELECT IdAudiencia, Descripcion, SWITCH (Visible = 1, 'Activo', Visible = 0, 'Inactivo') AS Visible, Bloqueado FROM Audiencia WHERE IdAudiencia=?";
            CreateTextCommand(consulta);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Select();
        }

        public string TipoAudienciaEstatus(object id)
        {
            string consulta = "SELECT visible FROM Audiencia WHERE IdAudiencia=? ";
            CreateTextCommand(consulta);
            AddParameter("?", id, OleDbType.Numeric);
            return Select().Rows[0][0].ToString();
        }

        public DataTable TipoAudienciaBajaUltimoEvento()
        {
            string consulta = "SELECT id from eventos WHERE estatus=2 and format([fechafinevento], 'dd/mm/yyyy') = date()";
            CreateTextCommand(consulta);
            return Select();
        }

        public DataTable TipoAudienciaValidarSiBajaUltimoEvento(object id)
        {
            string consulta = "SELECT bloqueado from Audiencia WHERE idAudiencia=?";
            CreateTextCommand(consulta);
            AddParameter("?", id, OleDbType.Numeric);
            return Select();
        }

        public int TipoAudienciaDesactivar(prop.TipoAudiencia item)
        {
            string consulta = "UPDATE Audiencia SET Visible=? WHERE IdAudiencia=? ";
            CreateTextCommand(consulta);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        public int TipoAudienciaUpdate(prop.TipoAudiencia item)
        {
            string consulta = "UPDATE Audiencia SET Descripcion=?, Visible=?, Bloqueado=? WHERE IdAudiencia=?";
            CreateTextCommand(consulta);
            AddParameter("?", item.Descripcion, OleDbType.VarChar, 255);
            AddParameter("?", item.Activo, OleDbType.Numeric);
            AddParameter("?", item.Bloqueado, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        public int TipoAudienciaBajaEnUltimoEvento(object item)
        {
            string consulta = "UPDATE Audiencia SET Visible=2 WHERE IdAudiencia=?";
            CreateTextCommand(consulta);
            AddParameter("?", item, OleDbType.Numeric);
            return Update();
        }




    }
}
