using System;
using System.Windows.Forms;

namespace ClubNaval
{
    public partial class frmMenuPersonas : Form
    {
        public frmMenuPersonas()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            new frmEntradas().ShowDialog();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            new frmListarPersonas().ShowDialog();
        }
    }
}


