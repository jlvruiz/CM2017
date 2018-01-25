using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Eventos : BaseDeDatos
    {
        public DataTable EventosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], "
            + "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], "
            + " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], "
            + " SWITCH (a.Estatus = 1, 'Activo', a.Estatus = 0, 'Inactivo', a.Estatus=2, 'Terminado') AS Estatus "
            + " FROM Eventos a, TipoEvento b, Gerentes c "
            + " WHERE b.IdTipEve = a.TipoEvento "
            + " AND c.IdGerente = a.GteProducto "
            + " AND a.Estatus = 1 ";
            CreateTextCommand(consulta);
            return Select();
        }
        public DataTable EventosDesactivadosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], "
            + "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], "
            + " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], "
            + " SWITCH (a.Estatus = 1, 'Activo', a.Estatus = 0, 'Inactivo', a.Estatus=2, 'Terminado') AS Estatus "
            + " FROM Eventos a, TipoEvento b, Gerentes c "
            + " WHERE b.IdTipEve = a.TipoEvento "
            + " AND c.IdGerente = a.GteProducto "
            + " AND a.Estatus = 0 ";
            CreateTextCommand(consulta);
            return Select();
        }
        public DataTable EventosTerminadosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], "
            + "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], "
            + " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], "
            + " SWITCH (a.Estatus = 1, 'Activo', a.Estatus = 0, 'Inactivo', a.Estatus=2, 'Terminado') AS Estatus "
            + " FROM Eventos a, TipoEvento b, Gerentes c "
            + " WHERE b.IdTipEve = a.TipoEvento "
            + " AND c.IdGerente = a.GteProducto "
            + " AND a.Estatus = 2 ";
            CreateTextCommand(consulta);
            return Select();
        }

        public DataTable EventosSelectById(string id)
        {
            CreateTextCommand("SELECT * FROM Eventos WHERE Id=?");
            AddParameter("?", id);
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
            AddParameter("?", id);
            return Select();
        }
        public bool validarAreaTerapeutica(object idareaterapeutica)
        {
            string obtenido = "0";
            string consulta = "SELECT areaterapeutica FROM eventos WHERE areaterapeutica=? AND estatus=1";
            CreateTextCommand(consulta);
            AddParameter("areaterapeutica", idareaterapeutica);
            if (Select().Rows.Count > 0)
                obtenido = Select().Rows[0][0].ToString();
            if (obtenido == idareaterapeutica.ToString())
                return false;
            else
                return true;
        }

        public bool validarTipoEvento(object idtipoevento)
        {
            string obtenido = "0";
            string consulta = "SELECT tipoevento FROM eventos WHERE tipoevento=? AND estatus=1";
            CreateTextCommand(consulta);
            AddParameter("tipoevento", idtipoevento);
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
            AddParameter("tipoaudiencia", idtipoaudiencia);
            if (Select().Rows.Count > 0)
                obtenido = Select().Rows[0][0].ToString();
            if (obtenido == idtipoaudiencia.ToString())
                return false;
            else
                return true;
        }

        public string EventoInsert(prop.Eventos item)
        {
            string consulta = "INSERT into eventos (NombreEvento,FechaSolicitud,FechaInicioEvento,FechaFinEvento,TipoEvento,"
                + "FlujoAutorizacion,GteProducto,Producto,TipoAudiencia,Invitados,Objetivo,Locacion1,Locacion2,Agenda,Division,"
                + "AreaTerapeutica,TeamLeader) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            CreateTextCommand(consulta);
            AddParameter("?",item.NombreEvento);
            AddParameter("?",item.FechaSolicitud);
            AddParameter("?",item.FechaInicioEvento);
            AddParameter("?",item.FechaFinEvento);
            AddParameter("?",item.TipoEvento);
            AddParameter("?",item.FlujoAutorizacion);
            AddParameter("?",item.GteProducto);
            AddParameter("?",item.Producto);
            AddParameter("?",item.TipoAudiencia);
            AddParameter("?",item.Invitados);
            AddParameter("?",item.Objetivo);
            AddParameter("?",item.Locacion1);
            AddParameter("?",item.Locacion2);
            AddParameter("?",item.Agenda);
            AddParameter("?",item.Division);
            AddParameter("?",item.AreaTerapeutica);
            AddParameter("?",item.TeamLeader);
            return Insert();
        }

        public int EventoUpdate(prop.Eventos item)
        {
            string consulta = "UPDATE eventos set NombreEvento=?,FechaSolicitud=?,FechaInicioEvento=?,FechaFinEvento=?,"
                + "TipoEvento=?,FlujoAutorizacion=?,GteProducto=?,Producto=?,TipoAudiencia=?,Invitados=?,Objetivo=?,Locacion1=?,"
                + "Locacion2=?,Agenda=?,Division=?,AreaTerapeutica=?,TeamLeader=? WHERE Id=?";
            CreateTextCommand(consulta);
            AddParameter("?", item.NombreEvento);
            AddParameter("?", item.FechaSolicitud.ToString());
            AddParameter("?", item.FechaInicioEvento.ToString());
            AddParameter("?", item.FechaFinEvento.ToString());
            AddParameter("?", item.TipoEvento.ToString());
            AddParameter("?", item.FlujoAutorizacion.ToString());
            AddParameter("?", item.GteProducto.ToString());
            AddParameter("?", item.Producto.ToString());
            AddParameter("?", item.TipoAudiencia.ToString());
            AddParameter("?", item.Invitados.ToString());
            AddParameter("?", item.Objetivo);
            AddParameter("?", item.Locacion1.ToString());
            AddParameter("?", item.Locacion2.ToString());
            AddParameter("?", item.Agenda);
            AddParameter("?", item.Division.ToString());
            AddParameter("?", item.AreaTerapeutica.ToString());
            AddParameter("?", item.TeamLeader.ToString());
            AddParameter("?", item.Id.ToString());
            return Update();
        }
        public void EventoDesactivar(string id)
        {
            string consulta = "UPDATE eventos SET Estatus=0 WHERE Id=?";
            CreateTextCommand(consulta);
            AddParameter("?", id.ToString());
            Update();
        }
        public void EventoReactivar(string id)
        {
            string consulta = "UPDATE eventos SET Estatus=1 WHERE Id=? ";
            CreateTextCommand(consulta);
            AddParameter("?", id.ToString());
            Update();
        }
        public void EventoTerminado(object id)
        {
            string consulta = "UPDATE eventos SET Estatus=2 WHERE Id=?";
            CreateTextCommand(consulta);
            AddParameter("?", id.ToString());
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
