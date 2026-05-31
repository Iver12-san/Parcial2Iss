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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCanal_Click(object sender, EventArgs e)
        {
            new FrmCanal().ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnProgramas_Click(object sender, EventArgs e)
        {
            new FrmPrograma().ShowDialog();
        }

        private void btlCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
