using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace ClubNaval
{
    public partial class frmBarcos : Form
    {
        private string rutaFotoSeleccionada = "";

        public frmBarcos()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
            this.Load += FrmBarcos_Load;
        }

        private void FrmBarcos_Load(object sender, EventArgs e)
        {
            CargarDueños();
        }

        private void CargarDueños()
        {
            try
            {
                // Consultamos solo a las personas con Cargo 2 (Dueño / Socio) que estén disponibles
                List<VOPersona> dueños = BLLPersona.ConsultarPersonasPorCargo("2", true);
                
                if(dueños.Count == 0)
                {
                    MessageBox.Show("Advertencia: No hay dueños registrados. Por favor registra un Dueño/Socio en Personas antes de agregar un barco.", "Sin dueños", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                cmbDueño.DataSource = dueños;
                cmbDueño.DisplayMember = "Nombre";
                cmbDueño.ValueMember = "IdPersona";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de dueños: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExaminarFoto_Click(object sender, EventArgs e)
        {
            ofdFoto.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdFoto.Title = "Selecciona una foto para el barco";

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
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtMatricula.Text))
                {
                    MessageBox.Show("Por favor, llena al menos la matrícula y el nombre.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbDueño.SelectedValue == null)
                {
                    MessageBox.Show("Debes seleccionar un dueño para el barco.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string matricula = txtMatricula.Text;
                string noAmarre = txtNoAmarre.Text;
                string nombre = txtNombre.Text;
                
                double? cuota = null;
                if (!string.IsNullOrWhiteSpace(txtCuota.Text))
                {
                    if (double.TryParse(txtCuota.Text, out double c))
                        cuota = c;
                    else
                    {
                        MessageBox.Show("La cuota debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int idDueño = (int)cmbDueño.SelectedValue;
                bool disponible = true;

                VOBarco nuevoBarco = new VOBarco(0, matricula, noAmarre, nombre, cuota, idDueño, rutaFotoSeleccionada, disponible);

                if (BLLBarco.Insertar(nuevoBarco))
                {
                    MessageBox.Show("¡Barco guardado con éxito en la base de datos!", "�?xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtMatricula.Clear();
                    txtNombre.Clear();
                    txtNoAmarre.Clear();
                    txtCuota.Clear();
                    rutaFotoSeleccionada = "";
                    picFoto.ImageLocation = null;
                    picFoto.Image = null;
                    if (cmbDueño.Items.Count > 0) cmbDueño.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


