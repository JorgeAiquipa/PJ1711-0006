using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGAP
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new UserControls.frm_tooltip());
            Application.Run(new comercial.frm_01());
            //Application.Run(new comercial.Form1());
            //Application.Run(new comercial.frm_01_2_01());
            //Application.Run(new comercial.lienzo_prueba_dos());
        }
    }
}
