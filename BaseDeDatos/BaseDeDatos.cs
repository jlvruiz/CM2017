using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Collections;

namespace BaseDeDatos
{
    public class BaseDeDatos
    {
        private OleDbConnection DBConnection = null;
        private OleDbCommand cmd;

        protected void CreateTextCommand(string consulta)
        {
            this.cmd = new OleDbCommand();
            this.cmd.CommandText = consulta;
            this.cmd.Connection = DBConnection;
            this.cmd.CommandType = CommandType.Text;
        }
        protected void CreateProcedureCommand(string procedimiento)
        {
            this.cmd.CommandText = procedimiento;
            this.cmd.CommandType = CommandType.StoredProcedure;
        }
        protected DataTable Select()
        {
            DataTable dt = new DataTable();
            OpenConecction();
            cmd.Connection = DBConnection;
            dt.Load(cmd.ExecuteReader());
            CloseConnection();
            return dt;
        }
        protected int Update()
        {
            OpenConecction();
            cmd.Connection = DBConnection;
            int obtenido = this.cmd.ExecuteNonQuery();
            CloseConnection();
            return obtenido;
        }
        protected string Insert()
        {
            OpenConecction();
            cmd.Connection = DBConnection;
            string obtenido = (string)this.cmd.ExecuteScalar();
            CloseConnection();
            return obtenido;
        }
        protected int InsertWithReturnValue()
        {
            int returned = 0;
            OpenConecction();
            cmd.Connection = DBConnection;
            this.cmd.ExecuteScalar();
            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                if (cmd.Parameters[i].Direction == ParameterDirection.Output || cmd.Parameters[i].Direction == ParameterDirection.InputOutput || cmd.Parameters[i].Direction == ParameterDirection.ReturnValue)
                {
                    returned = (int)cmd.Parameters[i].Value;
                }
            }
            CloseConnection();
            return returned;
        }
        protected int Delete()
        {
            OpenConecction();
            cmd.Connection = DBConnection;
            int obtenido = this.cmd.ExecuteNonQuery();
            CloseConnection();
            return obtenido;
        }
        protected void AddParameter(string nombre, object valor, OleDbType tipo)
        {
            OleDbParameter param = new OleDbParameter();
            param.ParameterName = nombre;
            param.Value = valor;
            param.OleDbType = tipo;
            this.cmd.Parameters.Add(param);
        }
        protected void AddParameter(string nombre, object valor, OleDbType tipo, int tamaño)
        {
            OleDbParameter param = new OleDbParameter();
            param.ParameterName = nombre;
            param.Value = valor;
            param.OleDbType = tipo;
            param.Size = tamaño;
            this.cmd.Parameters.Add(param);
        }
        protected void AddParameterWithReturnValue(string name)
        {
            OleDbParameter param = new OleDbParameter(name, OleDbType.Numeric);
            param.Direction = ParameterDirection.Output;
            this.cmd.Parameters.Add(param);
        }
        private void OpenConecction()
        {
            DBConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConxnOleDb"].ConnectionString);
            DBConnection.Open();
        }
        private void CloseConnection()
        {
            if (DBConnection != null && DBConnection.State == ConnectionState.Open)
            {
                DBConnection.Close();
            }
        }

        protected void ConnectionClose()
        {
            CloseConnection();
        }

        protected OleDbDataReader ExecuteReader()
        {
            OpenConecction();
            cmd.Connection = DBConnection;
            var reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
