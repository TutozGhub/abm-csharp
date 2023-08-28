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
        public void refreshDtg(DataGridView dtg)
        {
            dtg.DataSource = "";
            dtg.DataSource = CN_abm.productosCarga();
        }
        public void cargarCombo(ComboBox cmb, string tabla, string campoId, string campoName)
        {
            cmb.DataSource = CN_abm.comboCarga(tabla);
            cmb.DisplayMember = campoName;
            cmb.ValueMember = campoId;
        }
    }
}
