using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// Récupère la liste des abonnements.
        /// </summary>
        /// <returns>Liste des abonnements.</returns>
        public List<Abonnement> GetAllAbonnements()
        {
            return access.GetAllAbonnements();
        }


        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Récupère la liste des commandes liées à un document.
        /// </summary>
        /// <param name="idDocument"></param>
        /// <returns></returns>
        public List<CommandeDocument> GetCommandes(string idDocument)
        {
            return access.GetCommandes(idDocument);
        }

        /// <summary>
        /// Crée une commande de document.
        /// </summary>
        /// <param name="commande">Commande de document.</param>
        /// <returns></returns>
        public bool CreerCommande(CommandeDocument commande)
        {
            return access.CreerCommande(commande);
        }

        /// <summary>
        /// Modifie le suivi d'une commande.
        /// </summary>
        /// <param name="suivi">Nouveau suivi</param>
        /// <param name="id">Id de la commande dont on veut modifier le suivi</param>
        /// <returns></returns>
        public bool UpdateSuivi(string suivi, string id)
        {
            return access.updateSuivi(suivi, id);
        }

        /// <summary>
        /// Supprime une commande non livrée.
        /// </summary>
        /// <param name="commande">Informations de la commande</param>
        /// <returns></returns>
        public bool DeleteCommande(Commande commande)
        {
            return access.DeleteCommande(commande);
        }

        /// <summary>
        /// Récupère la liste des commandes liées à une revue.
        /// </summary>
        /// <param name="idRevue">Id de la revue dont on veut récupérer les commandes</param>
        /// <returns></returns>
        public List<Abonnement> GetCommandesRevues(string idRevue)
        {
            return access.GetCommandesRevues(idRevue);
        }

        /// <summary>
        /// Crée un nouvel abonnement lié à une revue.
        /// </summary>
        /// <param name="abonnement">Infos de l'abonnement</param>
        /// <returns></returns>
        public bool CreerAbonnement(Abonnement abonnement)
        {
            return access.CreerAbonnement(abonnement);
        }

        /// <summary>
        /// Supprime un abonnement lié à une revue.
        /// </summary>
        /// <param name="abonnement">Infos de l'abonnement.</param>
        /// <returns></returns>
        public bool DeleteAbonnement(Abonnement abonnement)
        {
            return access.DeleteAbonnement(abonnement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }
    }
}
