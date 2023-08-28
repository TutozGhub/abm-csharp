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
    public static class CN_abm
    {
        private static CD_Consultas consultas = new CD_Consultas();
        public static void alta(int tipo, string nombre, int talle, int marca, double precioCompra, double precioVenta, int stock)
        {

            string query =
                "INSERT INTO " + "productos (id_tipo, nombre, id_talle, id_marca, precio_compra, precio_venta, stock, activo)\n" +
                "VALUES " + $"({tipo}, '{nombre}', {talle}, {marca}, {precioCompra}, {precioVenta}, {stock}, {true});";

            consultas.insert(query);
        }
        public static void baja(int? id, bool estado)
        {
            if (id == null || id == -1) return;

            string query =
                "UPDATE productos\n" +
                $"SET activo = {!estado}\n" + 
                $"WHERE id_producto = {id};";

            consultas.insert(query);
        }
        public static void modificacion(int id, int tipo, string nombre, int talle, int marca, double precioCompra, double precioVenta, int stock)
        {
            string query =
                "UPDATE productos\n" +
                $"SET  id_tipo = {tipo}, nombre = '{nombre}', id_talle = {talle}, id_marca = {marca}, precio_compra = {precioCompra}, precio_venta = {precioVenta}, stock = {stock}\n" +
                "WHERE " + $"id_producto = {id} and activo = True;";

            consultas.insert(query);
        }
        public static DataTable productosCarga(bool activo, string nombre = null, int? stock = null, int? tipo = null, int? talle = null)
        {
            string query =
                "SELECT id_producto, nombre as Nombre, tipo as Tipo, talle as Talle, marca as Marca, precio_compra as [Precio de compra], precio_venta as [Precio de Venta], stock as Stock\n" +
                "FROM ((productos p INNER JOIN talle ta ON p.id_talle = ta.id_talle)\n" +
                "LEFT JOIN tipo ti ON p.id_tipo = ti.id_tipo)\n" +
                "LEFT JOIN marca ma ON p.id_marca = ma.id_marca\n" +
                "WHERE " + $"activo = {activo}";
            
            if (nombre != null)
            {
                query += $" and p.nombre like '%{nombre}%'";
            }
            if (stock != null)
            {
                query += $" and p.stock = {stock}";
            }
            if (tipo != null)
            {
                query += $" and p.id_tipo = {tipo}";
            }
            if (talle != null)
            {
                query += $" and p.id_talle = {talle}";
            }
            query += ";";
            return consultas.select(query);
        }
        public static DataTable comboCarga(string tabla)
        {
            string query =
                "SELECT " + "* " +
                "FROM " + tabla + ";";

            return consultas.select(query);
        }
        public static DataTable comboCarga(string tabla, string extra)
        {
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
