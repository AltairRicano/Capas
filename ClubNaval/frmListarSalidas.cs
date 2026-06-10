using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace ClubNaval
{
    public partial class frmListarSalidas : Form
    {
        private int paginaActual = 1;
        private int tamañoPagina = 25;
        private List<VOSalidaExtendida> listaCompleta = new List<VOSalidaExtendida>();
        private List<VOSalidaExtendida> listaFiltrada = new List<VOSalidaExtendida>();

        public frmListarSalidas()
        {
            InitializeComponent();
            TemaNaval.Aplicar(this);
            this.Load += FrmListarSalidas_Load;
        }

        private void FrmListarSalidas_Load(object sender, EventArgs e)
        {
            cmbFiltroEstado.Items.AddRange(new string[] { "Todos", "Activas (En Curso)", "Terminadas (FINALIZADA)" });
            cmbFiltroEstado.SelectedIndex = 0;

            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                listaCompleta = BLLSalida.ConsultarSalidaPorEstadoExtendida(null);
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salidas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            string busqueda = txtBuscar.Text.ToLower();
            string filtroEstado = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";

            var temp = listaCompleta.AsEnumerable();

            // Filtro por Estado
            if (filtroEstado == "Activas (En Curso)")
                temp = temp.Where(s => s.Estado == "En Curso");
            else if (filtroEstado == "Terminadas (FINALIZADA)")
                temp = temp.Where(s => s.Estado == "FINALIZADA");

            // Filtro por Búsqueda (Destino, Barco, Capitán)
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                temp = temp.Where(s => 
                    (s.Destino != null && s.Destino.ToLower().Contains(busqueda)) ||
                    (s.NombreBarco != null && s.NombreBarco.ToLower().Contains(busqueda)) ||
                    (s.NombreCapitan != null && s.NombreCapitan.ToLower().Contains(busqueda))
                );
            }

            // Filtro por Fecha (FechaHoraSalida)
            if (chkFiltrarFecha.Checked)
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1); // Hasta el final del día
                temp = temp.Where(s => s.FechaHoraSalida >= desde && s.FechaHoraSalida <= hasta);
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

            dgvSalidas.DataSource = null;
            dgvSalidas.DataSource = paginaDatos;

            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) { AplicarFiltros(); }
        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) { AplicarFiltros(); }
        private void chkFiltrarFecha_CheckedChanged(object sender, EventArgs e) { 
            dtpDesde.Enabled = chkFiltrarFecha.Checked;
            dtpHasta.Enabled = chkFiltrarFecha.Checked;
            AplicarFiltros(); 
        }
        private void dtpDesde_ValueChanged(object sender, EventArgs e) { if (chkFiltrarFecha.Checked) AplicarFiltros(); }
        private void dtpHasta_ValueChanged(object sender, EventArgs e) { if (chkFiltrarFecha.Checked) AplicarFiltros(); }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1) { paginaActual--; MostrarPagina(); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = (int)Math.Ceiling((double)listaFiltrada.Count / tamañoPagina);
            if (paginaActual < totalPaginas) { paginaActual++; MostrarPagina(); }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.SelectedRows.Count == 0) return;
            try
            {
                DataGridViewRow row = dgvSalidas.SelectedRows[0];
                string estado = row.Cells["Estado"].Value?.ToString();

                if (estado != "En Curso")
                {
                    MessageBox.Show("Solo puedes finalizar salidas que están 'En Curso'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string idSalida = row.Cells["IdSalida"].Value.ToString();
                
                if (MessageBox.Show("¿Estás seguro de que quieres finalizar esta salida y marcar el barco como disponible?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (BLLSalida.FinalizarSalida(idSalida))
                    {
                        MessageBox.Show("Salida finalizada. ¡El barco ha vuelto!", "�?xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar: " + ex.Message);
            }
        }
    }
}


