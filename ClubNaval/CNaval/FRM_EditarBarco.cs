using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;
using Entities;

namespace CNaval
{
    public partial class FRM_EditarBarco : Form
    {
        private int _idBarco;

        public FRM_EditarBarco(int idBarco)
        {
            InitializeComponent();
            _idBarco = idBarco;
        }

        private async void FRM_EditarBarco_Load(object sender, EventArgs e)
        {
            await CargarOwnersAsync();
            await CargarDatosAsync();
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

        private async Task CargarDatosAsync()
        {
            try
            {
                VOBarco barco = await BLLBarco.ConsultarPorIdAsync(_idBarco);
                txtMatricula.Text = barco.Matricula;
                txtNoAmarre.Text = barco.NoAmarre;
                txtNombre.Text = barco.Nombre;
                txtCuota.Text = barco.Cuota.ToString();
                cmbOwner.SelectedValue = barco.IdPersona;
                chkDisponibilidad.Checked = barco.Disponibilidad ?? true;
                txtUrlFoto.Text = barco.UrlFoto;

                if (!string.IsNullOrWhiteSpace(barco.UrlFoto))
                {
                    try
                    {
                        using (System.Net.WebClient cliente = new System.Net.WebClient())
                        {
                            byte[] datos = cliente.DownloadData(barco.UrlFoto);
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(datos))
                            {
                                picFoto.Image = System.Drawing.Image.FromStream(ms);
                            }
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message,
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

                VOBarco barco = new VOBarco(
                    _idBarco,
                    txtMatricula.Text.Trim(),
                    txtNoAmarre.Text.Trim(),
                    txtNombre.Text.Trim(),
                    double.Parse(txtCuota.Text),
                    (int)cmbOwner.SelectedValue,
                    txtUrlFoto.Text.Trim(),
                    chkDisponibilidad.Checked
                );

                btnGuardar.Enabled = false;
                await BLLBarco.ActualizarAsync(barco);

                MessageBox.Show("Barco actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = true;
            }
        }
    }
}