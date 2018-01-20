using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;


namespace BaseDeDatos
{
    public class DBLocalOLE
    {
        protected OleDbConnection DBConnection = null;
        private OleDbCommand cmd = new OleDbCommand();

        protected void CreateTextCommand(string consulta)
        {
            this.cmd.CommandText = consulta;
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
            int obt = 0;

            OpenConecction();
            cmd.Connection = DBConnection;
            obt = this.cmd.ExecuteNonQuery();
            CloseConnection();
            return obt;

        }
        protected string Insert()
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
        protected int InsertWithReturnValue()
        {
            int returned = 0;
            try
            {
                OpenConecction();
                cmd.Connection = DBConnection;
                this.cmd.ExecuteScalar();
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    if (
                        cmd.Parameters[i].Direction == ParameterDirection.Output || 
                        cmd.Parameters[i].Direction == ParameterDirection.InputOutput || 
                        cmd.Parameters[i].Direction == ParameterDirection.ReturnValue
                        )
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
        protected int Delete()
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
        protected void AddParameter(string nombre, object valor)
        {
            OleDbParameter param = new OleDbParameter();
            param.ParameterName = nombre;
            param.Value = valor;
            this.cmd.Parameters.Add(param);
        }
        protected void AddParameterWithReturnValue(string name)
        {
            OleDbParameter param = new OleDbParameter(name, SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            this.cmd.Parameters.Add(param);
        }
        protected void OpenConecction()
        {
            DBConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConxnOleDb"].ConnectionString);
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
