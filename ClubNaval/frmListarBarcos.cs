using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace ClubNaval
{
    public partial class frmListarBarcos : Form
    {
        private string rutaFotoActual = "";
        private int paginaActual = 1;
        private int tamañoPagina = 25;
        private List<VOBarco> listaCompleta = new List<VOBarco>();
        private List<VOBarco> listaFiltrada = new List<VOBarco>();

        public frmListarBarcos()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
            this.Load += FrmListarBarcos_Load;
        }

        private void FrmListarBarcos_Load(object sender, EventArgs e)
        {
            cmbFiltroDisp.Items.AddRange(new string[] { "Todos", "Disponibles (En Marina)", "Ocupados (En Viaje)" });
            cmbFiltroDisp.SelectedIndex = 0;
            
            CargarDueños();
            CargarDatos();
        }

        private void CargarDueños()
        {
            try
            {
                var dueños = BLLPersona.ConsultarPersonasPorCargo("2", null);
                cmbDueño.DataSource = dueños;
                cmbDueño.DisplayMember = "Nombre";
                cmbDueño.ValueMember = "IdPersona";
            }
            catch { }
        }

        private void CargarDatos()
        {
            try
            {
                listaCompleta = BLLBarco.ConsultarBarcos(null);
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar barcos: " + ex.Message);
            }
        }

        private void AplicarFiltros()
        {
            string busqueda = txtBuscar.Text.ToLower();
            string filtroDisp = cmbFiltroDisp.SelectedItem?.ToString() ?? "Todos";

            var temp = listaCompleta.AsEnumerable();

            if (filtroDisp == "Disponibles (En Marina)")
                temp = temp.Where(b => b.Disponibilidad == true);
            else if (filtroDisp == "Ocupados (En Viaje)")
                temp = temp.Where(b => b.Disponibilidad == false);

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                temp = temp.Where(b => 
                    (b.Nombre != null && b.Nombre.ToLower().Contains(busqueda)) ||
                    (b.Matricula != null && b.Matricula.ToLower().Contains(busqueda)) ||
                    (b.NoAmarre != null && b.NoAmarre.ToLower().Contains(busqueda))
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

            dgvBarcos.DataSource = null;
            dgvBarcos.DataSource = paginaDatos;
            if (dgvBarcos.Columns["UrlFoto"] != null) dgvBarcos.Columns["UrlFoto"].Visible = false;

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

        private void dgvBarcos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelEdicion.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBarcos.Rows[e.RowIndex];
                txtId.Text = row.Cells["IdBarco"].Value?.ToString();
                txtMatricula.Text = row.Cells["Matricula"].Value?.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtNoAmarre.Text = row.Cells["NoAmarre"].Value?.ToString();
                txtCuota.Text = row.Cells["Cuota"].Value?.ToString();
                if (row.Cells["IdPersona"].Value != null) cmbDueño.SelectedValue = Convert.ToInt32(row.Cells["IdPersona"].Value);
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
                int idBarco = int.Parse(txtId.Text);
                double? cuota = string.IsNullOrWhiteSpace(txtCuota.Text) ? null : double.Parse(txtCuota.Text);
                VOBarco barcoEditado = new VOBarco(idBarco, txtMatricula.Text, txtNoAmarre.Text, txtNombre.Text, cuota, (int)cmbDueño.SelectedValue, rutaFotoActual, chkDisponible.Checked);

                BLLBarco.Actualizar(barcoEditado);
                MessageBox.Show("Barco actualizado.", "�?xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}


