using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmConnexion
    /// </summary>
    class FrmConnexionController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmConnexionController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Fonction de connexion à l'application.
        /// </summary>
        /// <param name="nomUtilisateur"></param>
        /// <param name="mdp"></param>
        /// <returns></returns>
        public List<Utilisateur> LoginUtilisateur(string nomUtilisateur,string mdp)
        {

            return access.LoginUtilisateur(nomUtilisateur,mdp);
        }

        /// <summary>
        /// Récupération de la liste des services.
        /// </summary>
        /// <returns>Liste des services</returns>
        public List<Service> GetAllServices()
        {
            return access.GetAllServices();
        }
    }
}
