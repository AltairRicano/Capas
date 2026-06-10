using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace ClubNaval
{
    public partial class frmListarPersonas : Form
    {
        private string rutaFotoActual = "";
        private int paginaActual = 1;
        private int tamañoPagina = 25;
        private List<VOPersona> listaCompleta = new List<VOPersona>();
        private List<VOPersona> listaFiltrada = new List<VOPersona>();

        public frmListarPersonas()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
            this.Load += FrmListarPersonas_Load;
        }

        private void FrmListarPersonas_Load(object sender, EventArgs e)
        {
            cmbFiltroDisp.Items.AddRange(new string[] { "Todos", "Disponibles", "Ocupados" });
            cmbFiltroDisp.SelectedIndex = 0;

            ConfigurarComboBox();
            CargarDatos();
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

        private void CargarDatos()
        {
            try
            {
                listaCompleta = BLLPersona.ConsultarPersonas(null);
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            string busqueda = txtBuscar.Text.ToLower();
            string filtroDisp = cmbFiltroDisp.SelectedItem?.ToString() ?? "Todos";

            var temp = listaCompleta.AsEnumerable();

            if (filtroDisp == "Disponibles")
                temp = temp.Where(p => p.Disponibilidad == true);
            else if (filtroDisp == "Ocupados")
                temp = temp.Where(p => p.Disponibilidad == false);

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                temp = temp.Where(p => 
                    (p.Nombre != null && p.Nombre.ToLower().Contains(busqueda)) ||
                    (p.Telefono != null && p.Telefono.ToLower().Contains(busqueda)) ||
                    (p.Correo != null && p.Correo.ToLower().Contains(busqueda))
                );
            }

            listaFiltrada = temp.ToList();
            paginaActual = 1;
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            int totalPaginas = (int)Math.Ceiling((double)listaFiltrada.Count / tamañoPagina);
            if (totalPaginas == 0) totalPaginas = 1;

            lblPaginacion.Text = $"Pág {paginaActual} de {totalPaginas}";

            var paginaDatos = listaFiltrada.Skip((paginaActual - 1) * tamañoPagina).Take(tamañoPagina).ToList();

            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = paginaDatos;

            if (dgvPersonas.Columns["UrlFoto"] != null)
                dgvPersonas.Columns["UrlFoto"].Visible = false;

            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) { AplicarFiltros(); }
        private void cmbFiltroDisp_SelectedIndexChanged(object sender, EventArgs e) { AplicarFiltros(); }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1) { paginaActual--; MostrarPagina(); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = (int)Math.Ceiling((double)listaFiltrada.Count / tamañoPagina);
            if (paginaActual < totalPaginas) { paginaActual++; MostrarPagina(); }
        }

        private void btnCerrarEdicion_Click(object sender, EventArgs e) { panelEdicion.Visible = false; }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelEdicion.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPersonas.Rows[e.RowIndex];
                
                txtId.Text = row.Cells["IdPersona"].Value?.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value?.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value?.ToString();
                int cargo = Convert.ToInt32(row.Cells["Cargo"].Value);
                cmbCargo.SelectedValue = cargo;
                chkDisponible.Checked = Convert.ToBoolean(row.Cells["Disponibilidad"].Value);
                rutaFotoActual = row.Cells["UrlFoto"].Value?.ToString() ?? "";
                picFoto.ImageLocation = string.IsNullOrEmpty(rutaFotoActual) ? null : rutaFotoActual;
            }
        }

        private void btnExaminarFoto_Click(object sender, EventArgs e)
        {
            ofdFoto.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                rutaFotoActual = ofdFoto.FileName;
                picFoto.ImageLocation = rutaFotoActual;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) return;
            try
            {
                int idPersona = int.Parse(txtId.Text);
                VOPersona personaEditada = new VOPersona(idPersona, txtTelefono.Text, txtDireccion.Text, txtNombre.Text, txtCorreo.Text, (int)cmbCargo.SelectedValue, chkDisponible.Checked, rutaFotoActual);

                BLLPersona.Actualizar(personaEditada);
                MessageBox.Show("Persona actualizada con éxito.", "�?xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }
    }
}


