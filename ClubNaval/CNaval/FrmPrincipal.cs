using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CNaval
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ListaPersonas frm = new FRM_ListaPersonas();
            frm.ShowDialog();
        }

        private void barcosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ListaBarcos frm = new FRM_ListaBarcos();
            frm.ShowDialog();
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ListaSalidas frm = new FRM_ListaSalidas();
            frm.ShowDialog();
        }
    }
}