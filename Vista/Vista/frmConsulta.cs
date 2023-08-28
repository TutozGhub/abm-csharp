using Comun;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmConsulta : Form
    {
        UtilidadesForm u = new UtilidadesForm();
        public static bool activo = true;
        public static int? idProducto = null;
        public frmConsulta()
        {
            InitializeComponent();
            dtgProductos.MultiSelect = false;
            dtgProductos.ReadOnly = true;
            dtgProductos.RowHeadersVisible = false;
            dtgProductos.AllowUserToAddRows = false;
            dtgProductos.AllowUserToResizeRows = false;
            dtgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            u.refreshDtg(dtgProductos, activo);
            u.cargarCombo(cmbTalle, "talle", "id_talle", "talle", true);
            u.cargarCombo(cmbTipo, "tipo", "id_tipo", "tipo", true);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form frm = new frmAM("add", ref dtgProductos);
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Form frm = new frmAM("mod", ref dtgProductos);
            frm.ShowDialog();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            u.refreshDtg(dtgProductos, activo, txtNombre.Text, txtStock.Text, Convert.ToInt32(cmbTipo.SelectedValue), Convert.ToInt32(cmbTalle.SelectedValue));
            u.limpiar(this);
        }

        private void rdbActivos_CheckedChanged(object sender, EventArgs e)
        {
            activo = true;
            btnEliminar.Text = "Eliminar";
            btnAgregar.Enabled = true;
            btnModificar.Enabled = true;
            u.refreshDtg(dtgProductos, activo);
        }

        private void rdbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            activo = false;
            btnEliminar.Text = "Reactivar";
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            u.refreshDtg(dtgProductos, activo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CN_abm.baja(idProducto, activo);
            u.refreshDtg(dtgProductos, activo);
        }

        private void dtgProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idProducto = Convert.ToInt32(dtgProductos.Rows[e.RowIndex].Cells[0].Value);
        }
    }
}
