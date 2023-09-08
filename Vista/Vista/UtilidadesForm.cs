using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista;

namespace Vista
{
    public class UtilidadesForm
    {
        public void refreshDtg(DataGridView dtg, bool activo)
        {
            dtg.DataSource = "";
            dtg.DataSource = CN_abm.productosCarga(activo);
            dtg.Columns[0].Visible = false;
            dtg.Columns[8].Visible = false;
            dtg.Columns[9].Visible = false;
            dtg.Columns[10].Visible = false;
        }
        public void refreshDtg(DataGridView dtg, bool activo, string nombre, string stock, int tipo, int talle)
        {
            int? _stock = null, _tipo = tipo, _talle = talle;

            try { _stock = Convert.ToInt32(stock); }
            catch { }

            if (string.IsNullOrEmpty(nombre))
            {
                nombre = null;
            }
            if (_stock == -1)
            {
                _stock = null;
            }
            if (tipo == -1)
            {
                _tipo = null;
            }
            if (talle == -1)
            {
                _talle = null;
            }

            dtg.DataSource = "";
            dtg.DataSource = CN_abm.productosCarga(activo, nombre, _stock, _tipo, _talle);
            dtg.Columns[0].Visible = false;
            dtg.Columns[8].Visible = false;
            dtg.Columns[9].Visible = false;
            dtg.Columns[10].Visible = false;
        }
        public void cargarCombo(ComboBox cmb, string tabla, string campoId, string campoName, bool filtro = false)
        {
            if (filtro)
            {
                cmb.DataSource = CN_abm.comboCarga(tabla, "Ninguno");
            }
            else
            {
                cmb.DataSource = CN_abm.comboCarga(tabla);
            }
            cmb.DisplayMember = campoName;
            cmb.ValueMember = campoId;
            cmb.SelectedValue = -1;
        }
        public void limpiar(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox txt) txt.Text = "";
                if (c is ComboBox cmb) cmb.SelectedValue = -1;
                if (c is GroupBox grp) limpiar(grp);
            }
        }
    }
}
