using MediaTekDocuments.model;
using MediaTekDocuments.view;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MediaTekDocuments
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger logger = new Logger();

            logger.startLog();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += (obj, args) => { logger.endLog(); };

            Application.Run(new FrmConnexion());

        }
    }
}
