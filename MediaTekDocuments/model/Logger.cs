using System;
using System.IO;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier singleton Logger : Permet la création des logs de la sortie console de l'application dans un fichier.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Instance seule de la classe
        /// </summary>
        private static Logger instance = null;
        /// <summary>
        /// Chemin du fichier de la sortie normale
        /// </summary>
        private readonly String outPath = "StandardLog.txt";
        /// <summary>
        /// Chemin du fichier de la sortie d'erreur
        /// </summary>swError
        private readonly String errorPath = "ErrorLog.txt";

        /// <summary>
        /// StreamWriter de la sortie normale
        /// </summary>
        private StreamWriter swOut = null;

        /// <summary>
        /// StreamWriter de la sortie d'erreur
        /// </summary>
        private StreamWriter swErr = null;

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public Logger()
        {
        }

        /// <summary>
        /// Renvoie l'instance unique de la classe.
        /// </summary>
        /// <returns></returns>
        public static Logger getInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }

            return instance;
        }

        /// <summary>
        /// Démarre la journalisation dans le fichier de log. (appellé au lancement du programme.)
        /// </summary>
        public void startLog()
        {
            FileStream fsStandard = new FileStream(outPath, FileMode.Append, FileAccess.Write);
            swOut = new StreamWriter(fsStandard);

            FileStream fsErr = new FileStream(errorPath, FileMode.Append, FileAccess.Write);
            swErr = new StreamWriter(fsErr);

            Console.WriteLine("Logging started");

            Console.SetOut(swOut);
            Console.SetError(swErr);

            Console.WriteLine("\n\nLogging for this session started at : "+ DateTime.Now.ToString()+"\n");
            Console.Error.WriteLine("\n\nLogging for this session started at started at : " + DateTime.Now.ToString() + "\n");

        }

        /// <summary>
        /// Ferme la journalisation dans le fichier de logs. (appellé à la fermeture du programme.)
        /// </summary>
        public void endLog()
        {
            Console.WriteLine("Logging for this session ended at : " + DateTime.Now.ToString() + "\n");
            Console.Error.WriteLine("Logging for this session ended at : " + DateTime.Now.ToString() + "\n");

            swOut.Close();
            swErr.Close();
        }
    }
}