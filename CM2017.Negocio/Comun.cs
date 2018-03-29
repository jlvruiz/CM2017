namespace CM2017.Negocio
{
    public class Comun
    {
        public BaseDeDatos.Tablas.AreaTerapeutica at;
        public BaseDeDatos.Tablas.ClienteInterno ci;
        public BaseDeDatos.Tablas.Divisiones di;
        public BaseDeDatos.Tablas.Eventos ev;
        public BaseDeDatos.Tablas.Gerentes gr;
        public BaseDeDatos.Tablas.Localizacion lo;
        public BaseDeDatos.Tablas.Productos pr;
        public BaseDeDatos.Tablas.GerenteTL tl;
        public BaseDeDatos.Tablas.TipoAudiencia ta;
        public BaseDeDatos.Tablas.TipoEvento te;
        public BaseDeDatos.Tablas.UDN un;
        public BaseDeDatos.Tablas.Usuarios us;

        public Comun()
        {
            at = new BaseDeDatos.Tablas.AreaTerapeutica();
            ci = new BaseDeDatos.Tablas.ClienteInterno();
            di = new BaseDeDatos.Tablas.Divisiones();
            ev = new BaseDeDatos.Tablas.Eventos();
            gr = new BaseDeDatos.Tablas.Gerentes();
            lo = new BaseDeDatos.Tablas.Localizacion();
            pr = new BaseDeDatos.Tablas.Productos();
            tl = new BaseDeDatos.Tablas.GerenteTL();
            ta = new BaseDeDatos.Tablas.TipoAudiencia();
            te = new BaseDeDatos.Tablas.TipoEvento();
            un = new BaseDeDatos.Tablas.UDN();
            us = new BaseDeDatos.Tablas.Usuarios();
        }
    }
}
