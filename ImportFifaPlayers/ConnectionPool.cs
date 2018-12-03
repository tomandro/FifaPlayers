using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ImportFifaPlayers
{
    class ConnectionPool : IDisposable
    {
        private static ConnectionPool instance;
        private static object getLock = new object();

        public static ConnectionPool GetInstance()
        {
            lock(getLock)
            {
                if(instance == null)
                {
                    instance = new ConnectionPool();
                }
            }
            return instance;
        }

        private SqlConnection con;
        private object connLock;

        private ConnectionPool()
        {
            String connectionString= "Data Source=TOM-ACERV3;Initial Catalog=fifa;Integrated Security=True;Pooling=False;";
            connLock = new object();
            con = new SqlConnection(connectionString);
            con.Open();
        }

        public void ExectuteStoredProcedure(String storedProcedureName,Dictionary<string,object> parameters)
        {
            try
            { 
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var key in parameters.Keys)
                    {
                       cmd.Parameters.AddWithValue(key, parameters[key]);
                    }
                    int rowAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed on procedure " + storedProcedureName);
                throw ex;
            }
        }

        public DataTable ExectuteStoredProcedureForValues(String storedProcedureName, Dictionary<string, object> parameters)
        {
            try
            {
                DataTable dataTable = null;
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {
                    foreach (var key in parameters.Keys)
                    {
                        cmd.Parameters.AddWithValue(key, parameters[key]);
                    }
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.Fill(dataTable);
                    }
                }
                return dataTable;
            }catch(Exception ex)
            {
                Console.WriteLine("Failed on procedure " + storedProcedureName);
                throw ex;
            }
        }

        public void Dispose()
        {
            con.Close();
        }
    }

    class ProcedureParameters
    {
        
    }
}
