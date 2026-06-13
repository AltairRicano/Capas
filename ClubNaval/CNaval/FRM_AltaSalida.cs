using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;
using Entities;

namespace CNaval
{
    public partial class FRM_AltaSalida : Form
    {
        public FRM_AltaSalida()
        {
            InitializeComponent();
        }

        private async void FRM_AltaSalida_Load(object sender, EventArgs e)
        {
            await Task.WhenAll(CargarBarcosAsync(), CargarCapitanesAsync());
        }

        private async Task CargarBarcosAsync()
        {
            try
            {
                var barcos = await BLLBarco.ConsultarTodosAsync(true);
                cmbBarco.DataSource = barcos;
                cmbBarco.DisplayMember = "Nombre";
                cmbBarco.ValueMember = "IdBarco";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar barcos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarCapitanesAsync()
        {
            try
            {
                var capitanes = await BLLPersona.ConsultarPorCargoAsync(1, true);
                cmbCapitan.DataSource = capitanes;
                cmbCapitan.DisplayMember = "Nombre";
                cmbCapitan.ValueMember = "IdPersona";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar capitanes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDestino.Text))
                {
                    MessageBox.Show("Escribe un destino.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbBarco.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un barco.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbCapitan.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un capitán.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VOSalida salida = new VOSalida(
                    dtpFecha.Value,
                    txtDestino.Text.Trim(),
                    "En Viaje",
                    (int)cmbBarco.SelectedValue,
                    (int)cmbCapitan.SelectedValue
                );

                btnGuardar.Enabled = false;
                await BLLSalida.InsertarAsync(salida);

                MessageBox.Show("Salida registrada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}