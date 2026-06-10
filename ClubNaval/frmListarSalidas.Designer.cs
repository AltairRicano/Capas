namespace ClubNaval
{
    partial class frmListarSalidas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSalidas;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Panel panelPaginacion;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPaginacion;
        private System.Windows.Forms.Button btnFinalizar;

        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.CheckBox chkFiltrarFecha;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvSalidas = new System.Windows.Forms.DataGridView();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.panelPaginacion = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblPaginacion = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();

            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.chkFiltrarFecha = new System.Windows.Forms.CheckBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).BeginInit(); this.panelAcciones.SuspendLayout(); this.panelPaginacion.SuspendLayout(); this.panelFiltros.SuspendLayout(); this.SuspendLayout();

            System.Drawing.Font fontLabels = new System.Drawing.Font("SimSun-ExtB", 12F);

            // FILTROS
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top; this.panelFiltros.Height = 100;
            
            this.lblBuscar.Location = new System.Drawing.Point(20, 20); this.lblBuscar.AutoSize = true; this.lblBuscar.Font = fontLabels; this.lblBuscar.Text = "Buscar (Destino, Barco, Capitán):";
            this.txtBuscar.Location = new System.Drawing.Point(320, 17); this.txtBuscar.Size = new System.Drawing.Size(200, 25); this.txtBuscar.Font = fontLabels; this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            
            this.lblFiltroEstado.Location = new System.Drawing.Point(540, 20); this.lblFiltroEstado.AutoSize = true; this.lblFiltroEstado.Font = fontLabels; this.lblFiltroEstado.Text = "Estado:";
            this.cmbFiltroEstado.Location = new System.Drawing.Point(620, 17); this.cmbFiltroEstado.Size = new System.Drawing.Size(200, 25); this.cmbFiltroEstado.Font = fontLabels; this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);
            
            this.chkFiltrarFecha.Location = new System.Drawing.Point(20, 60); this.chkFiltrarFecha.AutoSize = true; this.chkFiltrarFecha.Font = fontLabels; this.chkFiltrarFecha.Text = "Filtrar por Fecha (Salida)"; this.chkFiltrarFecha.CheckedChanged += new System.EventHandler(this.chkFiltrarFecha_CheckedChanged);
            
            this.lblDesde.Location = new System.Drawing.Point(320, 60); this.lblDesde.AutoSize = true; this.lblDesde.Font = fontLabels; this.lblDesde.Text = "Desde:";
            this.dtpDesde.Location = new System.Drawing.Point(380, 57); this.dtpDesde.Size = new System.Drawing.Size(140, 25); this.dtpDesde.Font = fontLabels; this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpDesde.Enabled = false; this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            
            this.lblHasta.Location = new System.Drawing.Point(540, 60); this.lblHasta.AutoSize = true; this.lblHasta.Font = fontLabels; this.lblHasta.Text = "Hasta:";
            this.dtpHasta.Location = new System.Drawing.Point(620, 57); this.dtpHasta.Size = new System.Drawing.Size(140, 25); this.dtpHasta.Font = fontLabels; this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpHasta.Enabled = false; this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);

            this.panelFiltros.Controls.Add(this.lblBuscar); this.panelFiltros.Controls.Add(this.txtBuscar); 
            this.panelFiltros.Controls.Add(this.lblFiltroEstado); this.panelFiltros.Controls.Add(this.cmbFiltroEstado);
            this.panelFiltros.Controls.Add(this.chkFiltrarFecha); this.panelFiltros.Controls.Add(this.lblDesde); 
            this.panelFiltros.Controls.Add(this.dtpDesde); this.panelFiltros.Controls.Add(this.lblHasta); this.panelFiltros.Controls.Add(this.dtpHasta);

            // PAGINACION
            this.panelPaginacion.Dock = System.Windows.Forms.DockStyle.Bottom; this.panelPaginacion.Height = 50;
            this.panelPaginacion.Controls.Add(this.btnAnterior); this.panelPaginacion.Controls.Add(this.lblPaginacion); this.panelPaginacion.Controls.Add(this.btnSiguiente);
            this.btnAnterior.Location = new System.Drawing.Point(20, 10); this.btnAnterior.Size = new System.Drawing.Size(100, 30); this.btnAnterior.Text = "< Anterior"; this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            this.btnSiguiente.Location = new System.Drawing.Point(220, 10); this.btnSiguiente.Size = new System.Drawing.Size(100, 30); this.btnSiguiente.Text = "Siguiente >"; this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            this.lblPaginacion.Location = new System.Drawing.Point(120, 15); this.lblPaginacion.Size = new System.Drawing.Size(100, 20); this.lblPaginacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.lblPaginacion.Text = "Pág 1 de 1";

            // ACCIONES
            this.panelAcciones.Dock = System.Windows.Forms.DockStyle.Bottom; this.panelAcciones.Height = 100;
            this.btnFinalizar.Location = new System.Drawing.Point(20, 20); this.btnFinalizar.Size = new System.Drawing.Size(300, 60); this.btnFinalizar.Text = "Finalizar Salida Seleccionada"; this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            this.panelAcciones.Controls.Add(this.btnFinalizar);

            // GRID
            this.dgvSalidas.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvSalidas.ReadOnly = true; this.dgvSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.Controls.Add(this.dgvSalidas);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelPaginacion);
            this.Controls.Add(this.panelAcciones);
            this.ClientSize = new System.Drawing.Size(900, 600); this.Text = "Listado y Filtro de Salidas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).EndInit(); this.panelAcciones.ResumeLayout(false); this.panelPaginacion.ResumeLayout(false); this.panelFiltros.ResumeLayout(false); this.panelFiltros.PerformLayout(); this.ResumeLayout(false);
        }
    }
}
