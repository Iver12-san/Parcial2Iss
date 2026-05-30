using ClnParcial2iss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpParcial2iss
{
    public partial class FrmCanal : Form
    {
        public FrmCanal()
        {
            InitializeComponent();
        }

        private void FrmCanal_Load(object sender, EventArgs e)
        {
            dgvLeer.DataSource = CanalCln.Leerpa("");
        }
    }
}
