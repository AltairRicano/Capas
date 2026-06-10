using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace ClubNaval
{
    public partial class frmSalidas : Form
    {
        public frmSalidas()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
            this.Load += FrmSalidas_Load;
        }

        private void FrmSalidas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                // 1. Cargar Barcos Disponibles
                List<VOBarco> barcos = BLLBarco.ConsultarBarcos(true);
                if (barcos.Count == 0)
                {
                    MessageBox.Show("No hay barcos disponibles en la marina para zarpar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmbBarco.DataSource = barcos;
                cmbBarco.DisplayMember = "Nombre"; // Asumiendo que la entidad tiene propiedad Nombre
                cmbBarco.ValueMember = "IdBarco";  // Asumiendo que la entidad tiene propiedad IdBarco

                // 2. Cargar Capitanes Disponibles (Cargo 1 = Capitán, Disponibilidad = true)
                List<VOPersona> capitanes = BLLPersona.ConsultarPersonasPorCargo("1", true);
                if (capitanes.Count == 0)
                {
                    MessageBox.Show("No hay capitanes disponibles para asignar a una salida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmbCapitan.DataSource = capitanes;
                cmbCapitan.DisplayMember = "Nombre";
                cmbCapitan.ValueMember = "IdPersona";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZarpar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBarco.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un barco.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (cmbCapitan.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un capitán.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDestino.Text))
                {
                    MessageBox.Show("Debe escribir un destino.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idBarco = (int)cmbBarco.SelectedValue;
                int idCapitan = (int)cmbCapitan.SelectedValue;
                string destino = txtDestino.Text;
                DateTime fechaSalida = dtpFecha.Value;
                string estado = "En Curso"; // Por defecto al zarpar

                VOSalida nuevaSalida = new VOSalida(fechaSalida, destino, estado, idBarco, idCapitan);

                if (BLLSalida.InsertarSalida(nuevaSalida))
                {
                    MessageBox.Show("¡Salida registrada con éxito! Buen viaje.", "¡Zarpando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Recargar los combos porque el barco y el capitan ya no deberían estar disponibles
                    txtDestino.Clear();
                    dtpFecha.Value = DateTime.Now;
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar la salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


