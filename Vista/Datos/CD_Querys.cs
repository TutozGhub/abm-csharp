using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public abstract class CD_Querys : CD_Conexion
    {
        public DataTable EjecutarConsultas(string query, bool Directa = false)
        {
            DataTable DT = new DataTable();
            try
            {
                using (OleDbConnection CNN = GetConnection())
                {
                    CNN.Open();
                    using (OleDbCommand comando = new OleDbCommand(query, CNN))
                    {
                        comando.CommandType = CommandType.Text;
                        if (!Directa)
                        {
                            DT.Load(comando.ExecuteReader());
                        }
                        else
                        {
                            comando.ExecuteNonQuery();
                        }
                    }
                }
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
