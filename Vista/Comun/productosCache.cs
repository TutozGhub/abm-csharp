using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class Producto
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }
        public string talle { get; set; }
        public string marca { get; set; }
        public double precioCompra { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }

    }
    public class ProductosCache
    {
        public static DataTable productos;
        public static List<Producto> lista = new List<Producto>();
    }
}
