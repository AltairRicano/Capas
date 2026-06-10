namespace ClubNaval
{
    partial class frmEntradas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            lblNombre = new System.Windows.Forms.Label();
            lblTelefono = new System.Windows.Forms.Label();
            lblDireccion = new System.Windows.Forms.Label();
            lblCorreo = new System.Windows.Forms.Label();
            lblCargo = new System.Windows.Forms.Label();
            
            txtNombre = new System.Windows.Forms.TextBox();
            txtTelefono = new System.Windows.Forms.TextBox();
            txtDireccion = new System.Windows.Forms.TextBox();
            txtCorreo = new System.Windows.Forms.TextBox();
            cmbCargo = new System.Windows.Forms.ComboBox();
            
            btnGuardar = new System.Windows.Forms.Button();
            
            picFoto = new System.Windows.Forms.PictureBox();
            btnExaminarFoto = new System.Windows.Forms.Button();
            ofdFoto = new System.Windows.Forms.OpenFileDialog();
            
            ((System.ComponentModel.ISupportInitialize)(picFoto)).BeginInit();
            SuspendLayout();
            
            // label1
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(57, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(205, 24);
            label1.TabIndex = 0;
            label1.Text = "Agregar Persona";
            
            System.Drawing.Font fontLabels = new System.Drawing.Font("SimSun-ExtB", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Font = fontLabels;
            lblNombre.Location = new System.Drawing.Point(57, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(76, 22);
            lblNombre.Text = "Nombre:";
            
            // txtNombre
            txtNombre.Font = fontLabels;
            txtNombre.Location = new System.Drawing.Point(200, 77);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(300, 29);
            
            // lblTelefono
            lblTelefono.AutoSize = true;
            lblTelefono.Font = fontLabels;
            lblTelefono.Location = new System.Drawing.Point(57, 130);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new System.Drawing.Size(98, 22);
            lblTelefono.Text = "Teléfono:";
            
            // txtTelefono
            txtTelefono.Font = fontLabels;
            txtTelefono.Location = new System.Drawing.Point(200, 127);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new System.Drawing.Size(300, 29);
            
            // lblDireccion
            lblDireccion.AutoSize = true;
            lblDireccion.Font = fontLabels;
            lblDireccion.Location = new System.Drawing.Point(57, 180);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new System.Drawing.Size(109, 22);
            lblDireccion.Text = "Dirección:";
            
            // txtDireccion
            txtDireccion.Font = fontLabels;
            txtDireccion.Location = new System.Drawing.Point(200, 177);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new System.Drawing.Size(300, 29);
            
            // lblCorreo
            lblCorreo.AutoSize = true;
            lblCorreo.Font = fontLabels;
            lblCorreo.Location = new System.Drawing.Point(57, 230);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new System.Drawing.Size(76, 22);
            lblCorreo.Text = "Correo:";
            
            // txtCorreo
            txtCorreo.Font = fontLabels;
            txtCorreo.Location = new System.Drawing.Point(200, 227);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new System.Drawing.Size(300, 29);
            
            // lblCargo
            lblCargo.AutoSize = true;
            lblCargo.Font = fontLabels;
            lblCargo.Location = new System.Drawing.Point(57, 280);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new System.Drawing.Size(65, 22);
            lblCargo.Text = "Cargo:";
            
            // cmbCargo
            cmbCargo.Font = fontLabels;
            cmbCargo.Location = new System.Drawing.Point(200, 277);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new System.Drawing.Size(300, 29);
            cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            // picFoto
            picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picFoto.Location = new System.Drawing.Point(530, 77);
            picFoto.Name = "picFoto";
            picFoto.Size = new System.Drawing.Size(200, 200);
            picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picFoto.AllowDrop = true;
            picFoto.DragEnter += new System.Windows.Forms.DragEventHandler(this.picFoto_DragEnter);
            picFoto.DragDrop += new System.Windows.Forms.DragEventHandler(this.picFoto_DragDrop);
            
            // btnExaminarFoto
            btnExaminarFoto.Font = fontLabels;
            btnExaminarFoto.Location = new System.Drawing.Point(530, 285);
            btnExaminarFoto.Name = "btnExaminarFoto";
            btnExaminarFoto.Size = new System.Drawing.Size(200, 35);
            btnExaminarFoto.Text = "Examinar Foto...";
            btnExaminarFoto.UseVisualStyleBackColor = true;
            btnExaminarFoto.Click += new System.EventHandler(this.btnExaminarFoto_Click);
            
            // btnGuardar
            btnGuardar.Font = fontLabels;
            btnGuardar.Location = new System.Drawing.Point(200, 340);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(300, 40);
            btnGuardar.Text = "Guardar Persona";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            
            // frmEntradas
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(780, 420);
            Controls.Add(picFoto);
            Controls.Add(btnExaminarFoto);
            Controls.Add(btnGuardar);
            Controls.Add(cmbCargo);
            Controls.Add(lblCargo);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(label1);
            Name = "frmEntradas";
            Text = "Gestión de Personas";
            ((System.ComponentModel.ISupportInitialize)(picFoto)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblCargo;
        
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.ComboBox cmbCargo;
        
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnExaminarFoto;
        private System.Windows.Forms.OpenFileDialog ofdFoto;
        
        private System.Windows.Forms.Button btnGuardar;
    }
}