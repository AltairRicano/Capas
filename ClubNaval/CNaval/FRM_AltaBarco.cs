using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;
using Entities;

namespace CNaval
{
    public partial class FRM_AltaBarco : Form
    {
        public FRM_AltaBarco()
        {
            InitializeComponent();
        }

        private async void FRM_AltaBarco_Load(object sender, EventArgs e)
        {
            await CargarOwnersAsync();
        }

        private async Task CargarOwnersAsync()
        {
            try
            {
                var personas = await BLLPersona.ConsultarTodasAsync(null);
                cmbOwner.DataSource = personas;
                cmbOwner.DisplayMember = "Nombre";
                cmbOwner.ValueMember = "IdPersona";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                using (System.Net.WebClient cliente = new System.Net.WebClient())
                {
                    byte[] datos = cliente.DownloadData(txtUrlFoto.Text.Trim());
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(datos))
                    {
                        picFoto.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
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
                if (string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                    string.IsNullOrWhiteSpace(txtNoAmarre.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCuota.Text))
                {
                    MessageBox.Show("Por favor llena todos los campos.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbOwner.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un dueño.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VOBarco barco = new VOBarco(
                    txtMatricula.Text.Trim(),
                    txtNoAmarre.Text.Trim(),
                    txtNombre.Text.Trim(),
                    double.Parse(txtCuota.Text),
                    (int)cmbOwner.SelectedValue,
                    txtUrlFoto.Text.Trim(),
                    true
                );

                btnGuardar.Enabled = false;
                await BLLBarco.InsertarAsync(barco);

                MessageBox.Show("Barco guardado correctamente.",
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