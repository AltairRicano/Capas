using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;

namespace CNaval
{
    public partial class FRM_ListaBarcos : Form
    {
        public FRM_ListaBarcos()
        {
            InitializeComponent();
        }

        private async void FRM_ListaBarcos_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async Task CargarTablaAsync()
        {
            try
            {
                var lista = await BLLBarco.ConsultarTodosAsync(true);
                dgvBarcos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar barcos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            FRM_AltaBarco frm = new FRM_AltaBarco();
            frm.ShowDialog();
            await CargarTablaAsync();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvBarcos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un barco de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idBarco = (int)dgvBarcos.SelectedRows[0].Cells["IdBarco"].Value;
            FRM_EditarBarco frm = new FRM_EditarBarco(idBarco);
            frm.ShowDialog();
            await CargarTablaAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBarcos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un barco de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de eliminar este barco?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    int idBarco = (int)dgvBarcos.SelectedRows[0].Cells["IdBarco"].Value;
                    await BLLBarco.EliminarAsync(idBarco);
                    MessageBox.Show("Barco eliminado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarTablaAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}