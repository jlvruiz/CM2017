using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
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
    public class Eventos
    {
        public string _cadena = string.Empty;

        public Eventos(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;
        

        public DataTable EventosSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            string consulta = "SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado], "
            + "a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], "
            + " b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente] "
            + " FROM Eventos a, TipoEvento b, Gerentes c "
            + " WHERE b.IdTipEve = a.TipoEvento "
            + " AND c.IdGerente = a.GteProducto";
            db.CreateTextCommand(consulta);
            return db.Select();
        }
        public DataTable EventosSelectById(string id)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("SELECT * FROM Eventos WHERE Id=?");
            db.AddParameter("?", id);
            return db.Select();
        }
        public DataTable EventosDetalleSelect(string id)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
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
            db.CreateTextCommand(consulta);
            db.AddParameter("?", id);
            return db.Select();
        }
        public string EventoInsert(EventosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            string consulta = "insert into eventos (NombreEvento,FechaSolicitud,FechaInicioEvento,FechaFinEvento,TipoEvento,"
                + "FlujoAutorizacion,GteProducto,Producto,TipoAudiencia,Invitados,Objetivo,Locacion1,Locacion2,Agenda,Division,"
                + "AreaTerapeutica,TeamLeader) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            db.CreateTextCommand(consulta);
            db.AddParameter("?",item.NombreEvento);
            db.AddParameter("?",item.FechaSolicitud.ToString());
            db.AddParameter("?",item.FechaInicioEvento.ToString());
            db.AddParameter("?",item.FechaFinEvento.ToString());
            db.AddParameter("?",item.TipoEvento.ToString());
            db.AddParameter("?",item.FlujoAutorizacion.ToString());
            db.AddParameter("?",item.GteProducto.ToString());
            db.AddParameter("?",item.Producto.ToString());
            db.AddParameter("?",item.TipoAudiencia.ToString());
            db.AddParameter("?",item.Invitados.ToString());
            db.AddParameter("?",item.Objetivo);
            db.AddParameter("?",item.Locacion1.ToString());
            db.AddParameter("?",item.Locacion2.ToString());
            db.AddParameter("?",item.Agenda);
            db.AddParameter("?",item.Division.ToString());
            db.AddParameter("?",item.AreaTerapeutica.ToString());
            db.AddParameter("?",item.TeamLeader.ToString());
            return db.Insert();
        }
        public int EventoUpdate(EventosEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            string consulta = "update eventos set NombreEvento=?,FechaSolicitud=?,FechaInicioEvento=?,FechaFinEvento=?,"
                + "TipoEvento=?,FlujoAutorizacion=?,GteProducto=?,Producto=?,TipoAudiencia=?,Invitados=?,Objetivo=?,Locacion1=?,"
                + "Locacion2=?,Agenda=?,Division=?,AreaTerapeutica=?,TeamLeader=? where Id=?";
            db.CreateTextCommand(consulta);
            db.AddParameter("?", item.NombreEvento);
            db.AddParameter("?", item.FechaSolicitud.ToString());
            db.AddParameter("?", item.FechaInicioEvento.ToString());
            db.AddParameter("?", item.FechaFinEvento.ToString());
            db.AddParameter("?", item.TipoEvento.ToString());
            db.AddParameter("?", item.FlujoAutorizacion.ToString());
            db.AddParameter("?", item.GteProducto.ToString());
            db.AddParameter("?", item.Producto.ToString());
            db.AddParameter("?", item.TipoAudiencia.ToString());
            db.AddParameter("?", item.Invitados.ToString());
            db.AddParameter("?", item.Objetivo);
            db.AddParameter("?", item.Locacion1.ToString());
            db.AddParameter("?", item.Locacion2.ToString());
            db.AddParameter("?", item.Agenda);
            db.AddParameter("?", item.Division.ToString());
            db.AddParameter("?", item.AreaTerapeutica.ToString());
            db.AddParameter("?", item.TeamLeader.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }

    }
}
