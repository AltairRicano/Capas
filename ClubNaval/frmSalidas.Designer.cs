namespace ClubNaval
{
    partial class frmSalidas
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
            this.lblBarco = new System.Windows.Forms.Label();
            this.lblCapitan = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            
            this.cmbBarco = new System.Windows.Forms.ComboBox();
            this.cmbCapitan = new System.Windows.Forms.ComboBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            
            this.btnZarpar = new System.Windows.Forms.Button();
            
            this.SuspendLayout();
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label1.Location = new System.Drawing.Point(57, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 24);
            this.label1.Text = "Registrar Salida";
            
            System.Drawing.Font fontLabels = new System.Drawing.Font("SimSun-ExtB", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            // lblBarco
            this.lblBarco.AutoSize = true;
            this.lblBarco.Font = fontLabels;
            this.lblBarco.Location = new System.Drawing.Point(57, 80);
            this.lblBarco.Name = "lblBarco";
            this.lblBarco.Size = new System.Drawing.Size(186, 22);
            this.lblBarco.Text = "Barco (Disponible):";
            
            // cmbBarco
            this.cmbBarco.Font = fontLabels;
            this.cmbBarco.Location = new System.Drawing.Point(260, 77);
            this.cmbBarco.Name = "cmbBarco";
            this.cmbBarco.Size = new System.Drawing.Size(300, 29);
            this.cmbBarco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            // lblCapitan
            this.lblCapitan.AutoSize = true;
            this.lblCapitan.Font = fontLabels;
            this.lblCapitan.Location = new System.Drawing.Point(57, 130);
            this.lblCapitan.Name = "lblCapitan";
            this.lblCapitan.Size = new System.Drawing.Size(197, 22);
            this.lblCapitan.Text = "Capitán (Disponible):";
            
            // cmbCapitan
            this.cmbCapitan.Font = fontLabels;
            this.cmbCapitan.Location = new System.Drawing.Point(260, 127);
            this.cmbCapitan.Name = "cmbCapitan";
            this.cmbCapitan.Size = new System.Drawing.Size(300, 29);
            this.cmbCapitan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            // lblDestino
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = fontLabels;
            this.lblDestino.Location = new System.Drawing.Point(57, 180);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(87, 22);
            this.lblDestino.Text = "Destino:";
            
            // txtDestino
            this.txtDestino.Font = fontLabels;
            this.txtDestino.Location = new System.Drawing.Point(260, 177);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(300, 29);
            
            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = fontLabels;
            this.lblFecha.Location = new System.Drawing.Point(57, 230);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(142, 22);
            this.lblFecha.Text = "Fecha de Salida:";
            
            // dtpFecha
            this.dtpFecha.Font = fontLabels;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFecha.Location = new System.Drawing.Point(260, 227);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(300, 29);
            
            // btnZarpar
            this.btnZarpar.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.btnZarpar.Location = new System.Drawing.Point(260, 290);
            this.btnZarpar.Name = "btnZarpar";
            this.btnZarpar.Size = new System.Drawing.Size(300, 50);
            this.btnZarpar.Text = "Agregar salida";
            this.btnZarpar.UseVisualStyleBackColor = true;
            this.btnZarpar.Click += new System.EventHandler(this.btnZarpar_Click);
            
            // frmSalidas
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnZarpar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.cmbCapitan);
            this.Controls.Add(this.lblCapitan);
            this.Controls.Add(this.cmbBarco);
            this.Controls.Add(this.lblBarco);
            this.Controls.Add(this.label1);
            this.Name = "frmSalidas";
            this.Text = "Gestión de Salidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBarco;
        private System.Windows.Forms.Label lblCapitan;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblFecha;
        
        private System.Windows.Forms.ComboBox cmbBarco;
        private System.Windows.Forms.ComboBox cmbCapitan;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        
        private System.Windows.Forms.Button btnZarpar;
    }
}
