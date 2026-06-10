namespace ClubNaval
{
    partial class frmMenuPersonas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnListar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            System.Drawing.Font btnFont = new System.Drawing.Font("SimSun-ExtB", 16F);
            
            this.btnRegistrar.Font = btnFont;
            this.btnRegistrar.Location = new System.Drawing.Point(100, 80);
            this.btnRegistrar.Size = new System.Drawing.Size(200, 50);
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            
            this.btnListar.Font = btnFont;
            this.btnListar.Location = new System.Drawing.Point(100, 150);
            this.btnListar.Size = new System.Drawing.Size(200, 50);
            this.btnListar.Text = "Listar / Editar";
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnListar);
            this.Name = "frmMenuPersonas";
            this.Text = "Menú de Personas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }
    }
}
