using System;
using System.Windows.Forms;

namespace ClubNaval
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmPrincipal());
        }
    }
}
