using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClubNaval
{
    public static class TemaNaval
    {
        // Paleta de colores Navales y Modo Oscuro
        public static Color ColorFondoPrincipal = Color.FromArgb(10, 25, 47); // Azul marino oscuro (Deep Navy)
        public static Color ColorFondoPaneles = Color.FromArgb(17, 34, 64); // Azul marino ligeramente más claro
        public static Color ColorTextoPrincipal = Color.FromArgb(204, 214, 246); // Blanco azulado suave
        public static Color ColorAcento = Color.FromArgb(100, 255, 218); // Cian agua (Teal/Cyan)
        public static Color ColorTextoOscuro = Color.FromArgb(10, 25, 47); // Para texto en botones claros

        public static void Aplicar(Form form)
        {
            form.BackColor = ColorFondoPrincipal;
            form.ForeColor = ColorTextoPrincipal;

            // Ocultar bordes de ventana si se desea algo super moderno (opcional, lo dejamos normal por ahora)
            // form.FormBorderStyle = FormBorderStyle.Sizable;

            AplicarAControles(form.Controls);
        }

        private static void AplicarAControles(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is Panel || ctrl is GroupBox)
                {
                    // Solo pintamos de otro color los paneles principales
                    // Para que no parezca parche, algunos paneles pequeños pueden quedarse transparentes
                    if (ctrl.Dock == DockStyle.Left || ctrl.Dock == DockStyle.Right || ctrl.Dock == DockStyle.Top || ctrl.Dock == DockStyle.Bottom)
                    {
                        ctrl.BackColor = ColorFondoPaneles;
                    }
                    AplicarAControles(ctrl.Controls); // Recursivo
                }
                else if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    
                    // Excepciones (Botón cerrar de edición que es rojo)
                    if (btn.BackColor == Color.IndianRed || btn.BackColor == Color.Red)
                    {
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = ColorAcento;
                        btn.ForeColor = ColorTextoOscuro;
                        btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size, FontStyle.Bold);
                    }
                    btn.Cursor = Cursors.Hand;
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = ColorTextoPrincipal;
                    lbl.BackColor = Color.Transparent;
                }
                else if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(2, 12, 27);
                    txt.ForeColor = ColorTextoPrincipal;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = Color.FromArgb(2, 12, 27);
                    cmb.ForeColor = ColorTextoPrincipal;
                    cmb.FlatStyle = FlatStyle.Flat;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    // DateTimePicker no soporta muchos cambios de color nativos, lo dejamos normal
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.ForeColor = ColorTextoPrincipal;
                }
                else if (ctrl is DataGridView dgv)
                {
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BackgroundColor = ColorFondoPrincipal;
                    dgv.GridColor = Color.FromArgb(45, 55, 72);
                    dgv.BorderStyle = BorderStyle.None;
                    
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorAcento;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTextoOscuro;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                    
                    dgv.DefaultCellStyle.BackColor = Color.FromArgb(2, 12, 27);
                    dgv.DefaultCellStyle.ForeColor = ColorTextoPrincipal;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 55, 72);
                    dgv.DefaultCellStyle.SelectionForeColor = ColorAcento;
                    dgv.RowHeadersVisible = false;
                }
            }
        }
    }
}
