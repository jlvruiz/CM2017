﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CM2017.Negocio
{
    public class GerenteTLEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Activo { get; set; }
    }
    public class GerenteTL
    {
        public string _cadena = string.Empty;

        public GerenteTL(string cadena)
        {
            _cadena = cadena;
        }

        BaseDeDatos.BaseDeDatos db;

        public DataTable GerentesTLSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from TeamLeaders");
            return db.Select();
        }
        public DataTable GerentesTLActivoSelect()
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from TeamLeaders where Activo=1");
            return db.Select();
        }
        public DataTable GerenteTLSelectById(GerenteTLEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("select * from TeamLeaders where IdTL=?");
            db.AddParameter("?", item.Id.ToString());
            return db.Select();
        }
        public int GerenteTLDesactivar(GerenteTLEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update TeamLeaders set Activo=? where IdTL=?");
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
        public string GerenteTLInsert(GerenteTLEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("insert into TeamLeaders (Nombre, Correo, Activo) values (?,?,?)");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Correo);
            db.AddParameter("?", item.Activo.ToString());
            return db.Insert();
        }
        public int GerenteTLUpdate(GerenteTLEntity item)
        {
            db = new BaseDeDatos.BaseDeDatos(_cadena);
            db.CreateTextCommand("update TeamLeaders set Nombre=?, Correo=?, Activo=? where IdTL=?");
            db.AddParameter("?", item.Nombre);
            db.AddParameter("?", item.Correo);
            db.AddParameter("?", item.Activo.ToString());
            db.AddParameter("?", item.Id.ToString());
            return db.Update();
        }
    }
}
