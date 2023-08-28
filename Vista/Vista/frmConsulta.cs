using Comun;
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
    public partial class frmConsulta : Form
    {
        UtilidadesForm u = new UtilidadesForm();
        public frmConsulta()
        {
            InitializeComponent();
            dtgProductos.MultiSelect = false;
            dtgProductos.ReadOnly = true;
            dtgProductos.RowHeadersVisible = false;
            dtgProductos.AllowUserToAddRows = false;
            dtgProductos.AllowUserToResizeRows = false;
            dtgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            u.refreshDtg(dtgProductos);
            u.cargarCombo(cmbTalle, "talle", "id_talle", "talle");
            u.cargarCombo(cmbTipo, "tipo", "id_tipo", "tipo");
        }

        private void rdbActivos_CheckedChanged(object sender, EventArgs e)
        {

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

        private void frmConsulta_Enter(object sender, EventArgs e)
        {
            u.refreshDtg(dtgProductos);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
        }

        private void frmConsulta_Validated(object sender, EventArgs e)
        {
            u.refreshDtg(dtgProductos);
        }
    }
}
