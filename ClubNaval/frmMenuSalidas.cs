using System;
using System.Windows.Forms;

namespace ClubNaval
{
    public partial class frmMenuSalidas : Form
    {
        public frmMenuSalidas()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            new frmSalidas().ShowDialog();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            new frmListarSalidas().ShowDialog();
        }
    }
}


