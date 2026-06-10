namespace ClubNaval
{
    partial class frmListarBarcos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBarcos;
        private System.Windows.Forms.Panel panelEdicion;
        private System.Windows.Forms.Panel panelPaginacion;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPaginacion;

        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroDisp;
        private System.Windows.Forms.ComboBox cmbFiltroDisp;

        private System.Windows.Forms.Button btnCerrarEdicion;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNoAmarre;
        private System.Windows.Forms.TextBox txtNoAmarre;
        private System.Windows.Forms.Label lblCuota;
        private System.Windows.Forms.TextBox txtCuota;
        private System.Windows.Forms.Label lblDueÃ±o;
        private System.Windows.Forms.ComboBox cmbDueÃ±o;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnExaminarFoto;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.OpenFileDialog ofdFoto;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvBarcos = new System.Windows.Forms.DataGridView();
            this.panelEdicion = new System.Windows.Forms.Panel();
            this.panelPaginacion = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblPaginacion = new System.Windows.Forms.Label();

            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblFiltroDisp = new System.Windows.Forms.Label();
            this.cmbFiltroDisp = new System.Windows.Forms.ComboBox();

            this.btnCerrarEdicion = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label(); this.txtId = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label(); this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label(); this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNoAmarre = new System.Windows.Forms.Label(); this.txtNoAmarre = new System.Windows.Forms.TextBox();
            this.lblCuota = new System.Windows.Forms.Label(); this.txtCuota = new System.Windows.Forms.TextBox();
            this.lblDueÃ±o = new System.Windows.Forms.Label(); this.cmbDueÃ±o = new System.Windows.Forms.ComboBox();
            this.chkDisponible = new System.Windows.Forms.CheckBox(); this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnExaminarFoto = new System.Windows.Forms.Button(); this.btnActualizar = new System.Windows.Forms.Button();
            this.ofdFoto = new System.Windows.Forms.OpenFileDialog();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcos)).BeginInit(); this.panelEdicion.SuspendLayout(); this.panelPaginacion.SuspendLayout(); this.panelFiltros.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit(); this.SuspendLayout();

            System.Drawing.Font fontLabels = new System.Drawing.Font("SimSun-ExtB", 12F);

            // FILTROS
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top; this.panelFiltros.Height = 60;
            this.lblBuscar.Location = new System.Drawing.Point(20, 20); this.lblBuscar.AutoSize = true; this.lblBuscar.Font = fontLabels; this.lblBuscar.Text = "Buscar (Nombre, MatrÃ­cula, Amarre):";
            this.txtBuscar.Location = new System.Drawing.Point(320, 17); this.txtBuscar.Size = new System.Drawing.Size(200, 25); this.txtBuscar.Font = fontLabels; this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.lblFiltroDisp.Location = new System.Drawing.Point(540, 20); this.lblFiltroDisp.AutoSize = true; this.lblFiltroDisp.Font = fontLabels; this.lblFiltroDisp.Text = "Estado:";
            this.cmbFiltroDisp.Location = new System.Drawing.Point(620, 17); this.cmbFiltroDisp.Size = new System.Drawing.Size(200, 25); this.cmbFiltroDisp.Font = fontLabels; this.cmbFiltroDisp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbFiltroDisp.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroDisp_SelectedIndexChanged);
            this.panelFiltros.Controls.Add(this.lblBuscar); this.panelFiltros.Controls.Add(this.txtBuscar); this.panelFiltros.Controls.Add(this.lblFiltroDisp); this.panelFiltros.Controls.Add(this.cmbFiltroDisp);

            // PAGINACION
            this.panelPaginacion.Dock = System.Windows.Forms.DockStyle.Bottom; this.panelPaginacion.Height = 50;
            this.panelPaginacion.Controls.Add(this.btnAnterior); this.panelPaginacion.Controls.Add(this.lblPaginacion); this.panelPaginacion.Controls.Add(this.btnSiguiente);
            this.btnAnterior.Location = new System.Drawing.Point(20, 10); this.btnAnterior.Size = new System.Drawing.Size(100, 30); this.btnAnterior.Text = "< Anterior"; this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            this.btnSiguiente.Location = new System.Drawing.Point(220, 10); this.btnSiguiente.Size = new System.Drawing.Size(100, 30); this.btnSiguiente.Text = "Siguiente >"; this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            this.lblPaginacion.Location = new System.Drawing.Point(120, 15); this.lblPaginacion.Size = new System.Drawing.Size(100, 20); this.lblPaginacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.lblPaginacion.Text = "PÃ¡g 1 de 1";

            // EDICION
            this.panelEdicion.Dock = System.Windows.Forms.DockStyle.Right; this.panelEdicion.Size = new System.Drawing.Size(350, 600);
            this.panelEdicion.Visible = false; // Hidden by default

            this.btnCerrarEdicion.Location = new System.Drawing.Point(315, 5); this.btnCerrarEdicion.Size = new System.Drawing.Size(30, 30); this.btnCerrarEdicion.Text = "X"; this.btnCerrarEdicion.BackColor = System.Drawing.Color.IndianRed; this.btnCerrarEdicion.ForeColor = System.Drawing.Color.White; this.btnCerrarEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCerrarEdicion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold); this.btnCerrarEdicion.Click += new System.EventHandler(this.btnCerrarEdicion_Click);

            this.dgvBarcos.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvBarcos.ReadOnly = true; this.dgvBarcos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvBarcos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarcos_CellClick);

            this.lblId.Location = new System.Drawing.Point(20, 20); this.lblId.Text = "ID:"; this.lblId.Visible = false; this.txtId.Location = new System.Drawing.Point(120, 17); this.txtId.Size = new System.Drawing.Size(190, 25); this.txtId.ReadOnly = true; this.txtId.Visible = false;
            this.lblMatricula.Location = new System.Drawing.Point(20, 60); this.lblMatricula.Text = "MatrÃ­cula:"; this.txtMatricula.Location = new System.Drawing.Point(120, 57); this.txtMatricula.Size = new System.Drawing.Size(200, 25);
            this.lblNombre.Location = new System.Drawing.Point(20, 100); this.lblNombre.Text = "Nombre:"; this.txtNombre.Location = new System.Drawing.Point(120, 97); this.txtNombre.Size = new System.Drawing.Size(200, 25);
            this.lblNoAmarre.Location = new System.Drawing.Point(20, 140); this.lblNoAmarre.Text = "No Amarre:"; this.txtNoAmarre.Location = new System.Drawing.Point(120, 137); this.txtNoAmarre.Size = new System.Drawing.Size(200, 25);
            this.lblCuota.Location = new System.Drawing.Point(20, 180); this.lblCuota.Text = "Cuota:"; this.txtCuota.Location = new System.Drawing.Point(120, 177); this.txtCuota.Size = new System.Drawing.Size(200, 25);
            this.lblDueÃ±o.Location = new System.Drawing.Point(20, 220); this.lblDueÃ±o.Text = "DueÃ±o:"; this.cmbDueÃ±o.Location = new System.Drawing.Point(120, 217); this.cmbDueÃ±o.Size = new System.Drawing.Size(200, 24); this.cmbDueÃ±o.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chkDisponible.Location = new System.Drawing.Point(120, 260); this.chkDisponible.Text = "Disponible";
            this.picFoto.Location = new System.Drawing.Point(120, 300); this.picFoto.Size = new System.Drawing.Size(200, 150); this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnExaminarFoto.Location = new System.Drawing.Point(120, 460); this.btnExaminarFoto.Size = new System.Drawing.Size(200, 30); this.btnExaminarFoto.Text = "Cambiar Foto"; this.btnExaminarFoto.Click += new System.EventHandler(this.btnExaminarFoto_Click);
            this.btnActualizar.Location = new System.Drawing.Point(120, 500); this.btnActualizar.Size = new System.Drawing.Size(200, 40); this.btnActualizar.Text = "Actualizar"; this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.panelEdicion.Controls.Add(this.btnCerrarEdicion);
            this.panelEdicion.Controls.Add(this.btnActualizar); this.panelEdicion.Controls.Add(this.btnExaminarFoto); this.panelEdicion.Controls.Add(this.picFoto); this.panelEdicion.Controls.Add(this.chkDisponible); this.panelEdicion.Controls.Add(this.cmbDueÃ±o); this.panelEdicion.Controls.Add(this.lblDueÃ±o); this.panelEdicion.Controls.Add(this.txtCuota); this.panelEdicion.Controls.Add(this.lblCuota); this.panelEdicion.Controls.Add(this.txtNoAmarre); this.panelEdicion.Controls.Add(this.lblNoAmarre); this.panelEdicion.Controls.Add(this.txtNombre); this.panelEdicion.Controls.Add(this.lblNombre); this.panelEdicion.Controls.Add(this.txtMatricula); this.panelEdicion.Controls.Add(this.lblMatricula); this.panelEdicion.Controls.Add(this.txtId); this.panelEdicion.Controls.Add(this.lblId);

            this.Controls.Add(this.dgvBarcos);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelPaginacion);
            this.Controls.Add(this.panelEdicion);
            this.ClientSize = new System.Drawing.Size(1000, 600); this.Text = "Listado y Filtro de Barcos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcos)).EndInit(); this.panelEdicion.ResumeLayout(false); this.panelPaginacion.ResumeLayout(false); this.panelFiltros.ResumeLayout(false); this.panelFiltros.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit(); this.ResumeLayout(false);
        }
    }
}

