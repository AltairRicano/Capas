using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;

namespace CNaval
{
    public partial class FRM_ListaPersonas : Form
    {
        public FRM_ListaPersonas()
        {
            InitializeComponent();
        }

        private async void FRM_ListaPersonas_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async Task CargarTablaAsync()
        {
            try
            {
                var lista = await BLLPersona.ConsultarTodasAsync(true);
                dgvPersonas.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            FRM_AltaPersona frm = new FRM_AltaPersona();
            frm.ShowDialog();
            await CargarTablaAsync();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una persona de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPersona = (int)dgvPersonas.SelectedRows[0].Cells["IdPersona"].Value;
            FRM_EditarPersona frm = new FRM_EditarPersona(idPersona);
            frm.ShowDialog();
            await CargarTablaAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una persona de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de eliminar esta persona?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    int idPersona = (int)dgvPersonas.SelectedRows[0].Cells["IdPersona"].Value;
                    await BLLPersona.EliminarAsync(idPersona);
                    MessageBox.Show("Persona eliminada correctamente.",
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