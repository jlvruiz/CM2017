using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaseDeDatos.Tablas
{
    public class EventosEntity
    {
        public int Id { get; set; } 
        public string NombreEvento { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaInicioEvento { get; set; }
        public DateTime FechaFinEvento { get; set; }
        public int TipoEvento { get; set; }
        public int FlujoAutorizacion { get; set; }
        public int GteProducto { get; set; }
        public string Producto { get; set; }
        public int TipoAudiencia { get; set; }
        public int Invitados { get; set; }
        public string Objetivo { get; set; }
        public int Locacion1 { get; set; }
        public int Locacion2 { get; set; }
        public string Agenda { get; set; }
        public int Division { get; set; }
        public int AreaTerapeutica { get; set; }
        public int TeamLeader { get; set; }
    }
    public class Eventos : BaseDeDatos
    {
        public DataTable EventosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], "
            + "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], "
            + " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], "
            + " SWITCH (a.Estatus = True, 'Activo', a.Estatus = False, 'Inactivo') AS Estatus "
            + " FROM Eventos a, TipoEvento b, Gerentes c "
            + " WHERE b.IdTipEve = a.TipoEvento "
            + " AND c.IdGerente = a.GteProducto "
            + " AND a.Estatus = True ";
            CreateTextCommand(consulta);
            return Select();
        }
        public DataTable EventosDesactivadosSelect()
        {
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], "
            + "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], "
            + " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], "
            + " SWITCH (a.Estatus = True, 'Activo', a.Estatus = False, 'Inactivo') AS Estatus "
            + " FROM Eventos a, TipoEvento b, Gerentes c "
            + " WHERE b.IdTipEve = a.TipoEvento "
            + " AND c.IdGerente = a.GteProducto "
            + " AND a.Estatus = False ";
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
            string consulta = "SELECT a.flujoautorizacion AS [Flujo Autorizacion], a.producto as Producto, c.descripcion AS Audiencia, "
                + " a.invitados AS invitados, a.objetivo AS Objetivo, "
                + " a.locacion1 AS [Locación 1], d.nombre AS [Locación 2], "
                + " a.agenda AS Agenda, "
                + " e.descripcion AS División, "
                + " f.descripcion AS [Area Terapéutica], "
                + " g.nombre AS [Team Leader] "
                + " FROM eventos a, audiencia c, localizacion d, divisiones e, areaterapeutica f, teamleaders g "
                + " WHERE Id=? "
                + " AND c.idaudiencia = a.tipoaudiencia "
                + " AND d.idloc = a.locacion2 "
                + " ANd e.iddivision = a.division "
                + " AND f.idAT  = a.areaterapeutica "
                + " AND g.idtl = a.teamleader ";
            CreateTextCommand(consulta);
            AddParameter("?", id);
            return Select();
        }
        public string EventoInsert(EventosEntity item)
        {
            string consulta = "insert into eventos (NombreEvento,FechaSolicitud,FechaInicioEvento,FechaFinEvento,TipoEvento,"
                + "FlujoAutorizacion,GteProducto,Producto,TipoAudiencia,Invitados,Objetivo,Locacion1,Locacion2,Agenda,Division,"
                + "AreaTerapeutica,TeamLeader) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            CreateTextCommand(consulta);
            AddParameter("?",item.NombreEvento);
            AddParameter("?",item.FechaSolicitud.ToString());
            AddParameter("?",item.FechaInicioEvento.ToString());
            AddParameter("?",item.FechaFinEvento.ToString());
            AddParameter("?",item.TipoEvento.ToString());
            AddParameter("?",item.FlujoAutorizacion.ToString());
            AddParameter("?",item.GteProducto.ToString());
            AddParameter("?",item.Producto.ToString());
            AddParameter("?",item.TipoAudiencia.ToString());
            AddParameter("?",item.Invitados.ToString());
            AddParameter("?",item.Objetivo);
            AddParameter("?",item.Locacion1.ToString());
            AddParameter("?",item.Locacion2.ToString());
            AddParameter("?",item.Agenda);
            AddParameter("?",item.Division.ToString());
            AddParameter("?",item.AreaTerapeutica.ToString());
            AddParameter("?",item.TeamLeader.ToString());
            return Insert();
        }
        public int EventoUpdate(EventosEntity item)
        {
            string consulta = "update eventos set NombreEvento=?,FechaSolicitud=?,FechaInicioEvento=?,FechaFinEvento=?,"
                + "TipoEvento=?,FlujoAutorizacion=?,GteProducto=?,Producto=?,TipoAudiencia=?,Invitados=?,Objetivo=?,Locacion1=?,"
                + "Locacion2=?,Agenda=?,Division=?,AreaTerapeutica=?,TeamLeader=? where Id=?";
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
            string consulta = "UPDATE eventos SET Estatus=1 WHERE Id=?";
            CreateTextCommand(consulta);
            AddParameter("?", id.ToString());
            Update();
        }


    }
}
