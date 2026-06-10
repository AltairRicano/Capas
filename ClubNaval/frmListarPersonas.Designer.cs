namespace ClubNaval
{
    partial class frmListarPersonas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPersonas;
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
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnExaminarFoto;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.OpenFileDialog ofdFoto;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
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
            this.lblNombre = new System.Windows.Forms.Label(); this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label(); this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label(); this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label(); this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label(); this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.chkDisponible = new System.Windows.Forms.CheckBox(); this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnExaminarFoto = new System.Windows.Forms.Button(); this.btnActualizar = new System.Windows.Forms.Button();
            this.ofdFoto = new System.Windows.Forms.OpenFileDialog();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit(); this.panelEdicion.SuspendLayout(); this.panelPaginacion.SuspendLayout(); this.panelFiltros.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit(); this.SuspendLayout();

            System.Drawing.Font fontLabels = new System.Drawing.Font("SimSun-ExtB", 12F);

            // FILTROS
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top; this.panelFiltros.Height = 60;
            this.lblBuscar.Location = new System.Drawing.Point(20, 20); this.lblBuscar.AutoSize = true; this.lblBuscar.Font = fontLabels; this.lblBuscar.Text = "Buscar (Nombre, TelÃ©fono, Correo):";
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

            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvPersonas.ReadOnly = true; this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvPersonas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonas_CellClick);

            this.lblId.Location = new System.Drawing.Point(20, 20); this.lblId.Text = "ID:"; this.lblId.Visible = false; this.txtId.Location = new System.Drawing.Point(120, 17); this.txtId.Size = new System.Drawing.Size(190, 25); this.txtId.ReadOnly = true; this.txtId.Visible = false;
            this.lblNombre.Location = new System.Drawing.Point(20, 60); this.lblNombre.Text = "Nombre:"; this.txtNombre.Location = new System.Drawing.Point(120, 57); this.txtNombre.Size = new System.Drawing.Size(200, 25);
            this.lblTelefono.Location = new System.Drawing.Point(20, 100); this.lblTelefono.Text = "TelÃ©fono:"; this.txtTelefono.Location = new System.Drawing.Point(120, 97); this.txtTelefono.Size = new System.Drawing.Size(200, 25);
            this.lblDireccion.Location = new System.Drawing.Point(20, 140); this.lblDireccion.Text = "DirecciÃ³n:"; this.txtDireccion.Location = new System.Drawing.Point(120, 137); this.txtDireccion.Size = new System.Drawing.Size(200, 25);
            this.lblCorreo.Location = new System.Drawing.Point(20, 180); this.lblCorreo.Text = "Correo:"; this.txtCorreo.Location = new System.Drawing.Point(120, 177); this.txtCorreo.Size = new System.Drawing.Size(200, 25);
            this.lblCargo.Location = new System.Drawing.Point(20, 220); this.lblCargo.Text = "Cargo:"; this.cmbCargo.Location = new System.Drawing.Point(120, 217); this.cmbCargo.Size = new System.Drawing.Size(200, 24); this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chkDisponible.Location = new System.Drawing.Point(120, 260); this.chkDisponible.Text = "Disponible";
            this.picFoto.Location = new System.Drawing.Point(120, 300); this.picFoto.Size = new System.Drawing.Size(200, 150); this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnExaminarFoto.Location = new System.Drawing.Point(120, 460); this.btnExaminarFoto.Size = new System.Drawing.Size(200, 30); this.btnExaminarFoto.Text = "Cambiar Foto"; this.btnExaminarFoto.Click += new System.EventHandler(this.btnExaminarFoto_Click);
            this.btnActualizar.Location = new System.Drawing.Point(120, 500); this.btnActualizar.Size = new System.Drawing.Size(200, 40); this.btnActualizar.Text = "Actualizar"; this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.panelEdicion.Controls.Add(this.btnCerrarEdicion);
            this.panelEdicion.Controls.Add(this.btnActualizar); this.panelEdicion.Controls.Add(this.btnExaminarFoto); this.panelEdicion.Controls.Add(this.picFoto); this.panelEdicion.Controls.Add(this.chkDisponible); this.panelEdicion.Controls.Add(this.cmbCargo); this.panelEdicion.Controls.Add(this.lblCargo); this.panelEdicion.Controls.Add(this.txtCorreo); this.panelEdicion.Controls.Add(this.lblCorreo); this.panelEdicion.Controls.Add(this.txtDireccion); this.panelEdicion.Controls.Add(this.lblDireccion); this.panelEdicion.Controls.Add(this.txtTelefono); this.panelEdicion.Controls.Add(this.lblTelefono); this.panelEdicion.Controls.Add(this.txtNombre); this.panelEdicion.Controls.Add(this.lblNombre); this.panelEdicion.Controls.Add(this.txtId); this.panelEdicion.Controls.Add(this.lblId);

            this.Controls.Add(this.dgvPersonas);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelPaginacion);
            this.Controls.Add(this.panelEdicion);
            this.ClientSize = new System.Drawing.Size(1000, 600); this.Text = "Listado y Filtro de Personas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit(); this.panelEdicion.ResumeLayout(false); this.panelPaginacion.ResumeLayout(false); this.panelFiltros.ResumeLayout(false); this.panelFiltros.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit(); this.ResumeLayout(false);
        }
    }
}

