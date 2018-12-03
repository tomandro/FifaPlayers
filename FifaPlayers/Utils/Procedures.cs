using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FifaPlayers.Utils
{
    public class Procedures : IDisposable
    {
        private IConfiguration config;
        private SqlConnection conn;
        public Procedures(IConfiguration config)
        {
            this.config = config;
            conn = new SqlConnection(config["connectionString"]);
            conn.Open();
        }

        public void ExectuteStoredProcedure(String storedProcedureName, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
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
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed on procedure " + storedProcedureName);
                throw ex;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
