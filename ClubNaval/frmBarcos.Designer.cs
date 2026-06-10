namespace ClubNaval
{
    partial class frmBarcos
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNoAmarre = new System.Windows.Forms.Label();
            this.lblCuota = new System.Windows.Forms.Label();
            this.lblDueño = new System.Windows.Forms.Label();
            
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNoAmarre = new System.Windows.Forms.TextBox();
            this.txtCuota = new System.Windows.Forms.TextBox();
            this.cmbDueño = new System.Windows.Forms.ComboBox();
            
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnExaminarFoto = new System.Windows.Forms.Button();
            this.ofdFoto = new System.Windows.Forms.OpenFileDialog();
            
            this.btnGuardar = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label1.Location = new System.Drawing.Point(57, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 24);
            this.label1.Text = "Agregar Barco";
            
            System.Drawing.Font fontLabels = new System.Drawing.Font("SimSun-ExtB", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            // lblMatricula
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = fontLabels;
            this.lblMatricula.Location = new System.Drawing.Point(57, 80);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(120, 22);
            this.lblMatricula.Text = "Matrícula:";
            
            // txtMatricula
            this.txtMatricula.Font = fontLabels;
            this.txtMatricula.Location = new System.Drawing.Point(200, 77);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(300, 29);
            
            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = fontLabels;
            this.lblNombre.Location = new System.Drawing.Point(57, 130);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(87, 22);
            this.lblNombre.Text = "Nombre:";
            
            // txtNombre
            this.txtNombre.Font = fontLabels;
            this.txtNombre.Location = new System.Drawing.Point(200, 127);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 29);
            
            // lblNoAmarre
            this.lblNoAmarre.AutoSize = true;
            this.lblNoAmarre.Font = fontLabels;
            this.lblNoAmarre.Location = new System.Drawing.Point(57, 180);
            this.lblNoAmarre.Name = "lblNoAmarre";
            this.lblNoAmarre.Size = new System.Drawing.Size(131, 22);
            this.lblNoAmarre.Text = "No. Amarre:";
            
            // txtNoAmarre
            this.txtNoAmarre.Font = fontLabels;
            this.txtNoAmarre.Location = new System.Drawing.Point(200, 177);
            this.txtNoAmarre.Name = "txtNoAmarre";
            this.txtNoAmarre.Size = new System.Drawing.Size(300, 29);
            
            // lblCuota
            this.lblCuota.AutoSize = true;
            this.lblCuota.Font = fontLabels;
            this.lblCuota.Location = new System.Drawing.Point(57, 230);
            this.lblCuota.Name = "lblCuota";
            this.lblCuota.Size = new System.Drawing.Size(76, 22);
            this.lblCuota.Text = "Cuota:";
            
            // txtCuota
            this.txtCuota.Font = fontLabels;
            this.txtCuota.Location = new System.Drawing.Point(200, 227);
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.Size = new System.Drawing.Size(300, 29);
            
            // lblDueño
            this.lblDueño.AutoSize = true;
            this.lblDueño.Font = fontLabels;
            this.lblDueño.Location = new System.Drawing.Point(57, 280);
            this.lblDueño.Name = "lblDueño";
            this.lblDueño.Size = new System.Drawing.Size(76, 22);
            this.lblDueño.Text = "Dueño:";
            
            // cmbDueño
            this.cmbDueño.Font = fontLabels;
            this.cmbDueño.Location = new System.Drawing.Point(200, 277);
            this.cmbDueño.Name = "cmbDueño";
            this.cmbDueño.Size = new System.Drawing.Size(300, 29);
            this.cmbDueño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            // picFoto
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(530, 77);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(200, 200);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.AllowDrop = true;
            this.picFoto.DragEnter += new System.Windows.Forms.DragEventHandler(this.picFoto_DragEnter);
            this.picFoto.DragDrop += new System.Windows.Forms.DragEventHandler(this.picFoto_DragDrop);
            
            // btnExaminarFoto
            this.btnExaminarFoto.Font = fontLabels;
            this.btnExaminarFoto.Location = new System.Drawing.Point(530, 285);
            this.btnExaminarFoto.Name = "btnExaminarFoto";
            this.btnExaminarFoto.Size = new System.Drawing.Size(200, 35);
            this.btnExaminarFoto.Text = "Examinar Foto...";
            this.btnExaminarFoto.UseVisualStyleBackColor = true;
            this.btnExaminarFoto.Click += new System.EventHandler(this.btnExaminarFoto_Click);
            
            // btnGuardar
            this.btnGuardar.Font = fontLabels;
            this.btnGuardar.Location = new System.Drawing.Point(200, 340);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(300, 40);
            this.btnGuardar.Text = "Guardar Barco";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            
            // frmBarcos
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 420);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.btnExaminarFoto);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbDueño);
            this.Controls.Add(this.lblDueño);
            this.Controls.Add(this.txtCuota);
            this.Controls.Add(this.lblCuota);
            this.Controls.Add(this.txtNoAmarre);
            this.Controls.Add(this.lblNoAmarre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.label1);
            this.Name = "frmBarcos";
            this.Text = "Gestión de Barcos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNoAmarre;
        private System.Windows.Forms.Label lblCuota;
        private System.Windows.Forms.Label lblDueño;
        
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNoAmarre;
        private System.Windows.Forms.TextBox txtCuota;
        private System.Windows.Forms.ComboBox cmbDueño;
        
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnExaminarFoto;
        private System.Windows.Forms.OpenFileDialog ofdFoto;
        
        private System.Windows.Forms.Button btnGuardar;
    }
}
