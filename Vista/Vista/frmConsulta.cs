﻿using Comun;
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

        }
    }
}
