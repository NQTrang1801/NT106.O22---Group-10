using FileSystemExplorer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowExplorerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Explorer.frmExplorer = new Explorer();
            Application.Run(Explorer.frmExplorer);
        }
    }
}