using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Datos
{
    public abstract class CD_Conexion
    {
        private readonly string connectionstring;
        public CD_Conexion()
        {
            connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|ProductosBD.accdb";
        }
        protected OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionstring);
        }
    }
}
