using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;
using Entities;

namespace CNaval
{
    public partial class FRM_EditarPersona : Form
    {
        private int _idPersona;

        public FRM_EditarPersona(int idPersona)
        {
            InitializeComponent();
            _idPersona = idPersona;
        }

        private async void FRM_EditarPersona_Load(object sender, EventArgs e)
        {
            if (cmbCargo.Items.Count == 0)
            {
                cmbCargo.Items.Add("Capitán");
                cmbCargo.Items.Add("Tripulante");
            }
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                VOPersona persona = await BLLPersona.ConsultarPorIdAsync(_idPersona);
                txtNombre.Text = persona.Nombre;
                txtTelefono.Text = persona.Telefono;
                txtDireccion.Text = persona.Direccion;
                txtCorreo.Text = persona.Correo;
                cmbCargo.SelectedIndex = (persona.Cargo ?? 1) - 1;
                chkDisponibilidad.Checked = persona.Disponibilidad ?? true;
                txtUrlFoto.Text = persona.UrlFoto;

                if (!string.IsNullOrWhiteSpace(persona.UrlFoto))
                {
                    try
                    {
                        using (System.Net.WebClient cliente = new System.Net.WebClient())
                        {
                            byte[] datos = cliente.DownloadData(persona.UrlFoto);
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
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor llena todos los campos.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VOPersona persona = new VOPersona(
                    _idPersona,
                    txtNombre.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    cmbCargo.SelectedIndex + 1,
                    chkDisponibilidad.Checked,
                    txtUrlFoto.Text.Trim()
                );

                btnGuardar.Enabled = false;
                await BLLPersona.ActualizarAsync(persona);

                MessageBox.Show("Persona actualizada correctamente.",
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