using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class CN_abm
    {
        public static void alta(int tipo, string nombre, int talle, int marca, double precioCompra, double precioVenta, int stock)
        {
            CD_Consultas consultas = new CD_Consultas();

            string query =
                "INSERT INTO " + "productos (id_tipo, nombre, id_talle, id_marca, precio_compra, precio_venta, stock, activo)\n" +
                "VALUES " + $"({tipo}, '{nombre}', {talle}, {marca}, {precioCompra}, {precioVenta}, {stock}, {true});";

            consultas.insert(query);
        }
        public static DataTable productosCarga()
        {
            CD_Consultas consultas = new CD_Consultas();

            string query =
                "SELECT tipo as Tipo, nombre as Nombre, talle as Talle, marca as Marca, precio_compra as [Precio de compra], precio_venta as [Precio de Venta], stock as Stock\n" +
                "FROM ((productos p INNER JOIN talle ta ON p.id_talle = ta.id_talle)\n" +
                "LEFT JOIN tipo ti ON p.id_tipo = ti.id_tipo)\n" +
                "LEFT JOIN marca ma ON p.id_marca = ma.id_marca\n" +
                "WHERE " + "activo = true;";

            return consultas.select(query);
        }
        public static DataTable comboCarga(string tabla)
        {
            CD_Consultas consultas = new CD_Consultas();

            string query =
                "SELECT " + "* " +
                "FROM " + tabla + ";";

            return consultas.select(query);
        }
        public static DataTable comboCarga(string tabla, string extra)
        {
            CD_Consultas consultas = new CD_Consultas();

            string query =
                "SELECT " + "* " +
                "FROM " + tabla + ";";
            DataTable dt = consultas.select(query);
            DataRow dr = dt.NewRow();
            dt.Rows.Add(new Object[] { -1, extra });
            return dt;
        }
    }
}
