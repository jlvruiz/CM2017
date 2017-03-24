using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace BaseDeDatos
{
    public class BaseDeDatos
    {
        private string sConectionString { get; set; }
        //public string CadenaConexion
        //{
        //    get { return _cadenaConexion; }
        //    set { _cadenaConexion = value ; }
        //}
        protected OleDbConnection DBConnection = null;
        //private String sConectionString = string.Empty;

        private OleDbCommand cmd = new OleDbCommand();

        public BaseDeDatos(string cadena)
        {
            sConectionString = cadena;
        }

        public void CreateTextCommand(string consulta)
        {
            this.cmd.CommandText = consulta;
            this.cmd.CommandType = CommandType.Text;
        }
        public void CreateProcedureCommand(string procedimiento)
        {
            this.cmd.CommandText = procedimiento;
            this.cmd.CommandType = CommandType.StoredProcedure;
        }
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            OpenConecction();
            cmd.Connection = DBConnection;
            dt.Load(cmd.ExecuteReader());
            CloseConnection();
            return dt;
        }
        public int Update()
        {
            int obt = 0;

            OpenConecction();
            cmd.Connection = DBConnection;
            obt = this.cmd.ExecuteNonQuery();
            CloseConnection();
            return obt;

        }
        public string Insert()
        {
            try
            {
                OpenConecction();
                cmd.Connection = DBConnection;
                return (string)this.cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la ejecución. " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }
        public int InsertWithReturnValue()
        {
            int returned = 0;
            try
            {
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
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la ejecución. " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return returned;
        }
        public int Delete()
        {
            try
            {
                OpenConecction();
                cmd.Connection = DBConnection;
                return this.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la ejecución. " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void AddParameter(string nombre, string valor)
        {
            OleDbParameter param = new OleDbParameter();
            param.ParameterName = nombre;
            param.Value = valor;
            this.cmd.Parameters.Add(param);
        }
        public void AddParameterWithReturnValue(string name)
        {
            OleDbParameter param = new OleDbParameter(name, SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            this.cmd.Parameters.Add(param);
        }
        protected void OpenConecction()
        {
            DBConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\users\joseluis\documents\visual studio 2015\Projects\CM2017\CM2017\DB\CM.mdb;");
            DBConnection.Open();
        }
        protected void CloseConnection()
        {
            if (DBConnection != null && DBConnection.State == ConnectionState.Open)
            {
                DBConnection.Close();
            }
        }
    }
}
