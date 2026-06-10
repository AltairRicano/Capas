using System;
using System.Windows.Forms;

namespace ClubNaval
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            new frmMenuPersonas().ShowDialog();
        }

        private void btnBarcos_Click(object sender, EventArgs e)
        {
            new frmMenuBarcos().ShowDialog();
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            new frmMenuSalidas().ShowDialog();
        }
    }
}


