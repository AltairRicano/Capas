using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;
using Entities;

namespace CNaval
{
    public partial class FRM_AltaPersona : Form
    {
        public FRM_AltaPersona()
        {
            InitializeComponent();
        }

        private void FRM_AltaPersona_Load(object sender, EventArgs e)
        {
            if (cmbCargo.Items.Count == 0)
            {
                cmbCargo.Items.Add("Capitán");
                cmbCargo.Items.Add("Tripulante");
            }
            cmbCargo.SelectedIndex = 0;
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrlFoto.Text))
                {
                    MessageBox.Show("Escribe una URL primero.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                picFoto.Load(txtUrlFoto.Text);
            }
            catch
            {
                MessageBox.Show("No se pudo cargar la imagen. Verifica que la URL sea correcta.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor llena todos los campos.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cargo = cmbCargo.SelectedIndex + 1;

                VOPersona persona = new VOPersona(
                    txtNombre.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    cargo,
                    true,
                    txtUrlFoto.Text.Trim()
                );

                btnGuardar.Enabled = false;
                await BLLPersona.InsertarAsync(persona);

                MessageBox.Show("Persona guardada correctamente.",
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
    }
}