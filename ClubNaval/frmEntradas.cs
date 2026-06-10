using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace ClubNaval
{
    public partial class frmEntradas : Form
    {
        private string rutaFotoSeleccionada = "";

        public frmEntradas()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
            ConfigurarComboBox();
        }

        private void ConfigurarComboBox()
        {
            var opcionesCargo = new List<dynamic>
            {
                new { Id = 1, Texto = "Capitán" },
                new { Id = 2, Texto = "Dueño / Socio" },
                new { Id = 3, Texto = "Pasajero" }
            };

            cmbCargo.DataSource = opcionesCargo;
            cmbCargo.DisplayMember = "Texto";
            cmbCargo.ValueMember = "Id";
        }

        private void btnExaminarFoto_Click(object sender, EventArgs e)
        {
            ofdFoto.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdFoto.Title = "Selecciona una foto para la persona";

            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                CargarImagen(ofdFoto.FileName);
            }
        }

        private void picFoto_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string extension = Path.GetExtension(files[0]).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp")
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void picFoto_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            CargarImagen(files[0]);
        }

        private void CargarImagen(string ruta)
        {
            try
            {
                // ImageLocation es más seguro y no bloquea el archivo original
                picFoto.ImageLocation = ruta;
                rutaFotoSeleccionada = ruta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Por favor, llena al menos el nombre.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string telefono = txtTelefono.Text;
                string direccion = txtDireccion.Text;
                string nombre = txtNombre.Text;
                string correo = txtCorreo.Text;
                int idCargo = (int)cmbCargo.SelectedValue;
                bool disponible = true;

                // Construimos la entidad usando la ruta de la foto que esté en memoria
                VOPersona nuevaPersona = new VOPersona(0, telefono, direccion, nombre, correo, idCargo, disponible, rutaFotoSeleccionada);

                BLLPersona.Insertar(nuevaPersona);
                
                MessageBox.Show("¡Persona guardada con éxito en la base de datos!", "�?xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtNombre.Clear();
                txtTelefono.Clear();
                txtDireccion.Clear();
                txtCorreo.Clear();
                rutaFotoSeleccionada = "";
                picFoto.ImageLocation = null;
                picFoto.Image = null;
                cmbCargo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


