using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM2017.Propiedades
{
    public class Eventos
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
}
