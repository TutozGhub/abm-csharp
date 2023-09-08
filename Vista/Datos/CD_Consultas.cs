using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Consultas: CD_Querys
    {
        public DataTable select(string query)
        {
            DataTable resultado = EjecutarConsultas(query);
            return resultado;
        }
        public void insert(string query)
        {
            EjecutarConsultas(query, true);
        }
    }
}
