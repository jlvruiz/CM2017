using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace BaseDeDatos
{
    public class BaseDeDatosSQL
    {
        private string sConectionString { get; set; }
        //public string CadenaConexion
        //{
        //    get { return _cadenaConexion; }
        //    set { _cadenaConexion = value ; }
        //}
        protected SqlConnection DBConnection = null;
        //private String sConectionString = string.Empty;

        private SqlCommand cmd = new SqlCommand();

        public BaseDeDatosSQL()
        {
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
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombre;
            param.Value = valor;
            this.cmd.Parameters.Add(param);
        }
        public void AddParameterWithReturnValue(string name)
        {
            SqlParameter param = new SqlParameter(name, SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            this.cmd.Parameters.Add(param);
        }
        protected void OpenConecction()
        {
            DBConnection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=CM2017;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
