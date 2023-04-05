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

        public List<Utilisateur> LoginUtilisateur(string nomUtilisateur,string mdp)
        {

            return access.LoginUtilisateur(nomUtilisateur,mdp);
        }

        public List<Service> GetAllServices()
        {
            return access.GetAllServices();
        }
    }
}
