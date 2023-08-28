using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmAM : Form
    {
        UtilidadesForm u = new UtilidadesForm();

        string modo = "";

        int tipo, talle, marca, stock;
        string nombre;
        double precioCompra, precioVenta;
        DataGridView dtg;

        public frmAM(string _modo, ref DataGridView _dtg)
        {
            InitializeComponent();
            modo = _modo;
            dtg = _dtg;
            u.cargarCombo(cmbMarca, "marca", "id_marca", "marca");
            u.cargarCombo(cmbTalle, "talle", "id_talle", "talle");
            u.cargarCombo(cmbTipo, "tipo", "id_tipo", "tipo");
            if (_modo == "add")
            {
                this.Text = "Agregar producto";
            }
            else if (_modo == "mod")
            {
                this.Text = "Modificar producto";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            tipo = Convert.ToInt32(cmbTipo.SelectedValue);
            nombre = txtNombre.Text;
            talle = Convert.ToInt32(cmbTalle.SelectedValue);
            marca = Convert.ToInt32(cmbMarca.SelectedValue);
            precioCompra = Convert.ToDouble(txtPrecioCompra.Text);
            precioVenta = Convert.ToDouble(txtPrecioVenta.Text);
            stock = Convert.ToInt32(txtStock.Text);
            if (modo == "add")
            {
                CN_abm.alta(tipo, nombre, talle, marca, precioCompra, precioVenta, stock);
                u.refreshDtg(dtg);
                this.Dispose();
            }
            else if (modo == "mod")
            {

            }
        }
    }
}
