using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;

namespace CNaval
{
    public partial class FRM_ListaSalidas : Form
    {
        public FRM_ListaSalidas()
        {
            InitializeComponent();
        }

        private async void FRM_ListaSalidas_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async Task CargarTablaAsync()
        {
            try
            {
                var lista = await BLLSalida.ConsultarPorEstadoAsync("En Viaje");
                dgvSalidas.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salidas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNueva_Click(object sender, EventArgs e)
        {
            FRM_AltaSalida frm = new FRM_AltaSalida();
            frm.ShowDialog();
            await CargarTablaAsync();
        }

        private async void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una salida de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Confirmas que esta salida ha finalizado?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    int idSalida = (int)dgvSalidas.SelectedRows[0].Cells["IdSalida"].Value;
                    await BLLSalida.FinalizarAsync(idSalida);
                    MessageBox.Show("Salida finalizada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarTablaAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al finalizar: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una salida de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de eliminar esta salida?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    int idSalida = (int)dgvSalidas.SelectedRows[0].Cells["IdSalida"].Value;
                    await BLLSalida.EliminarAsync(idSalida);
                    MessageBox.Show("Salida eliminada correctamente.",
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