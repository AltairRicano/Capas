namespace ClubNaval
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.Button btnBarcos;
        private System.Windows.Forms.Button btnSalidas;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnPersonas = new System.Windows.Forms.Button();
            this.btnBarcos = new System.Windows.Forms.Button();
            this.btnSalidas = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("SimSun-ExtB", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(80, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(430, 33);
            this.lblTitulo.Text = "Club Naval - Menú Principal";
            
            System.Drawing.Font btnFont = new System.Drawing.Font("SimSun-ExtB", 16F);
            
            this.btnPersonas.Font = btnFont;
            this.btnPersonas.Location = new System.Drawing.Point(150, 120);
            this.btnPersonas.Size = new System.Drawing.Size(300, 50);
            this.btnPersonas.Text = "Gestión de Personas";
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            
            this.btnBarcos.Font = btnFont;
            this.btnBarcos.Location = new System.Drawing.Point(150, 190);
            this.btnBarcos.Size = new System.Drawing.Size(300, 50);
            this.btnBarcos.Text = "Gestión de Barcos";
            this.btnBarcos.Click += new System.EventHandler(this.btnBarcos_Click);
            
            this.btnSalidas.Font = btnFont;
            this.btnSalidas.Location = new System.Drawing.Point(150, 260);
            this.btnSalidas.Size = new System.Drawing.Size(300, 50);
            this.btnSalidas.Text = "Gestión de Salidas";
            this.btnSalidas.Click += new System.EventHandler(this.btnSalidas_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.btnBarcos);
            this.Controls.Add(this.btnSalidas);
            this.Name = "frmPrincipal";
            this.Text = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
