using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Eventos : BaseDeDatos
    {
        public DataTable EventosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], " +
            "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], " +
            " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], " +
            " SWITCH (a.Estatus = 1, 'Activo', a.Estatus = 0, 'Inactivo', a.Estatus=2, 'Terminado') AS Estatus " +
            " FROM Eventos a, TipoEvento b, Gerentes c " +
            " WHERE b.IdTipEve = a.TipoEvento " +
            " AND c.IdGerente = a.GteProducto " +
            " AND a.Estatus = 1";
            CreateTextCommand(consulta);
            return Select();
        }
        public prop.Eventos EventosSeleccionId()
        {
            prop.Eventos eventos = new prop.Eventos();
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], " +
            "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], " +
            " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], " +
            " SWITCH (a.Estatus = 1, 'Activo', a.Estatus = 0, 'Inactivo', a.Estatu s=2, 'Terminado') AS Estatus " +
            " FROM Eventos a, TipoEvento b, Gerentes c " +
            " WHERE b.IdTipEve = a.TipoEvento " +
            " AND c.IdGerente = a.GteProducto " +
            " AND a.Estatus = 1";
            CreateTextCommand(consulta);
            if (Select().Rows.Count > 0)
            {
                for (int i = 0; i < Select().Rows.Count; i++)
                {
                    eventos.Id = int.Parse(Select().Rows[i]["Id"].ToString());
                }
            }
            return eventos;
        }

        public DataTable EventosDesactivadosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], " +
            "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], " +
            " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], " +
            " SWITCH (a.Estatus = 1, 'Activo', a.Estatus = 0, 'Inactivo', a.Estatus=2, 'Terminado') AS Estatus " +
            " FROM Eventos a, TipoEvento b, Gerentes c " +
            " WHERE b.IdTipEve = a.TipoEvento " +
            " AND c.IdGerente = a.GteProducto " +
            " AND a.Estatus = 0 ";
            CreateTextCommand(consulta);
            return Select();
        }

        public DataTable EventosTerminadosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], " +
            "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], " +
            " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], " +
            " SWITCH (a.Estatus = 1, 'Activo', a.Estatus = 0, 'Inactivo', a.Estatus=2, 'Terminado') AS Estatus " +
            " FROM Eventos a, TipoEvento b, Gerentes c " +
            " WHERE b.IdTipEve = a.TipoEvento " +
            " AND c.IdGerente = a.GteProducto " +
            " AND a.Estatus = 2 ";
            CreateTextCommand(consulta);
            return Select();
        }

        public DataTable EventosSelectById(string id)
        {
            CreateTextCommand("SELECT * FROM Eventos WHERE Id=?");
            AddParameter("?", id, OleDbType.Numeric);
            return Select();
        }

        public DataTable EventosDetalleSelect(string id)
        {
            string consulta = "SELECT a.flujoautorizacion AS [Flujo Autorizacion], " +
             "a.producto as Producto,  c.descripcion AS Audiencia, " +
             "a.invitados AS invitados, a.objetivo AS Objetivo, " +
             "a.locacion1 AS [Locación 1], d.nombre AS [Locación 2], " +
             "a.agenda AS Agenda, " +
             "e.descripcion AS División, " +
             "f.descripcion AS [Area Terapéutica], " +
             "g.nombre AS [Team Leader] " +
             "FROM eventos a, audiencia c, localizacion d, divisiones e, areaterapeutica f, teamleaders g " +
             "WHERE Id=? " +
             "AND c.idaudiencia = a.tipoaudiencia " +
             "AND d.idloc = a.locacion2 " +
             "AND e.iddivision = a.division " +
             "AND f.idAT  = a.areaterapeutica " +
             "AND g.idtl = a.teamleader ";
            CreateTextCommand(consulta);
            AddParameter("?", id, OleDbType.Numeric);
            return Select();
        }

        public DataTable validarAreaTerapeutica(object idareaterapeutica)
        {            
            string consulta = "SELECT areaterapeutica, nombreevento FROM eventos WHERE areaterapeutica=? AND estatus=1";
            CreateTextCommand(consulta);
            AddParameter("areaterapeutica", idareaterapeutica, OleDbType.Numeric);
            return Select();
        }

        public bool validarTipoEvento(object idtipoevento)
        {
            string obtenido = "0";
            string consulta = "SELECT tipoevento FROM eventos WHERE tipoevento=? AND estatus=1";
            CreateTextCommand(consulta);
            AddParameter("tipoevento", idtipoevento, OleDbType.Numeric);
            if (Select().Rows.Count > 0)
                obtenido = Select().Rows[0][0].ToString();
            if (obtenido == idtipoevento.ToString())
                return false;
            else
                return true;
        }

        public bool validarAudiencia(object idtipoaudiencia)
        {
            string obtenido = "0";
            string consulta = "SELECT tipoaudiencia FROM eventos WHERE tipoaudiencia=? AND estatus=1";
            CreateTextCommand(consulta);
            AddParameter("tipoaudiencia", idtipoaudiencia, OleDbType.Numeric);
            if (Select().Rows.Count > 0)
                obtenido = Select().Rows[0][0].ToString();
            if (obtenido == idtipoaudiencia.ToString())
                return false;
            else
                return true;
        }

        public DataTable EventosEstadisticas()
        {
            string consulta = "SELECT SWITCH(eventos.estatus=0, 'Inactivos', eventos.estatus=1,'Activos', " +
            "eventos.estatus=2,'Terminados') AS Estatus, Count(eventos.estatus) AS Totales_Por_Estatus " +
            "FROM eventos " +
            "WHERE(((eventos.[estatus]) = 0) OR((eventos.[estatus]) = 1) OR((eventos.[estatus]) = 2)) " +
            "GROUP BY eventos.estatus " +
            "HAVING(((Count(eventos.[estatus])) <> false)); ";
            CreateTextCommand(consulta);
            return Select();
        }

        public string EventoInsert(prop.Eventos item)
        {
            string consulta = "INSERT into eventos (NombreEvento,FechaSolicitud,FechaInicioEvento,FechaFinEvento,TipoEvento," +
            "FlujoAutorizacion,GteProducto,Producto,TipoAudiencia,Invitados,Objetivo,Locacion1,Locacion2,Agenda,Division," +
            "AreaTerapeutica,TeamLeader) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            CreateTextCommand(consulta);
            AddParameter("?",item.NombreEvento, OleDbType.VarChar);
            AddParameter("?",item.FechaSolicitud, OleDbType.Date);
            AddParameter("?",item.FechaInicioEvento, OleDbType.Date);
            AddParameter("?",item.FechaFinEvento, OleDbType.Date);
            AddParameter("?",item.TipoEvento, OleDbType.Numeric);
            AddParameter("?",item.FlujoAutorizacion, OleDbType.Numeric);
            AddParameter("?",item.GteProducto, OleDbType.Numeric);
            AddParameter("?",item.Producto, OleDbType.VarChar);
            AddParameter("?",item.TipoAudiencia, OleDbType.Numeric);
            AddParameter("?",item.Invitados, OleDbType.Numeric);
            AddParameter("?",item.Objetivo, OleDbType.VarChar);
            AddParameter("?",item.Locacion1, OleDbType.Numeric);
            AddParameter("?",item.Locacion2, OleDbType.Numeric);
            AddParameter("?",item.Agenda, OleDbType.VarChar);
            AddParameter("?",item.Division, OleDbType.Numeric);
            AddParameter("?",item.AreaTerapeutica, OleDbType.Numeric);
            AddParameter("?",item.TeamLeader, OleDbType.Numeric);
            return Insert();
        }

        public int EventoUpdate(prop.Eventos item)
        {
            string consulta = "UPDATE eventos set NombreEvento=?,FechaSolicitud=?,FechaInicioEvento=?,FechaFinEvento=?," +
            "TipoEvento=?,FlujoAutorizacion=?,GteProducto=?,Producto=?,TipoAudiencia=?,Invitados=?,Objetivo=?,Locacion1=?," +
            "Locacion2=?,Agenda=?,Division=?,AreaTerapeutica=?,TeamLeader=? WHERE Id=?";
            CreateTextCommand(consulta);
            AddParameter("?", item.NombreEvento, OleDbType.VarChar);
            AddParameter("?", item.FechaSolicitud, OleDbType.Date);
            AddParameter("?", item.FechaInicioEvento, OleDbType.Date);
            AddParameter("?", item.FechaFinEvento, OleDbType.Date);
            AddParameter("?", item.TipoEvento, OleDbType.Numeric);
            AddParameter("?", item.FlujoAutorizacion, OleDbType.Numeric);
            AddParameter("?", item.GteProducto, OleDbType.Numeric);
            AddParameter("?", item.Producto, OleDbType.VarChar);
            AddParameter("?", item.TipoAudiencia, OleDbType.Numeric);
            AddParameter("?", item.Invitados, OleDbType.Numeric);
            AddParameter("?", item.Objetivo, OleDbType.VarChar);
            AddParameter("?", item.Locacion1, OleDbType.Numeric);
            AddParameter("?", item.Locacion2, OleDbType.Numeric);
            AddParameter("?", item.Agenda, OleDbType.VarChar);
            AddParameter("?", item.Division, OleDbType.Numeric);
            AddParameter("?", item.AreaTerapeutica, OleDbType.Numeric);
            AddParameter("?", item.TeamLeader, OleDbType.Numeric);
            AddParameter("?", item.Id, OleDbType.Numeric);
            return Update();
        }

        public void EventoDesactivar(string id)
        {
            string consulta = "UPDATE eventos SET Estatus=0 WHERE Id=?";
            CreateTextCommand(consulta);
            AddParameter("?", id, OleDbType.Numeric);
            Update();
        }

        public void EventoReactivar(string id)
        {
            string consulta = "UPDATE eventos SET Estatus=1 WHERE Id=? ";
            CreateTextCommand(consulta);
            AddParameter("?", id, OleDbType.Numeric);
            Update();
        }

        public void EventoTerminado(object id)
        {
            string consulta = "UPDATE eventos SET Estatus=2 WHERE Id=?";
            CreateTextCommand(consulta);
            AddParameter("?", id, OleDbType.Numeric);
            Update();
        }

        public void TerminarEvento()
        {
            string consulta = "UPDATE eventos SET estatus=2 WHERE format([fechafinevento], 'dd/mm/yyyy')< date() and estatus=1";
            CreateTextCommand(consulta);
            Update();
        }


    }
}
