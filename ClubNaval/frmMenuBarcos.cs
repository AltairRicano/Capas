using System;
using System.Windows.Forms;

namespace ClubNaval
{
    public partial class frmMenuBarcos : Form
    {
        public frmMenuBarcos()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            new frmBarcos().ShowDialog();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            new frmListarBarcos().ShowDialog();
        }
    }
}


