﻿using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Drawing;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {

        /// <summary>
        /// Chemin de l'url de l'api dans le fichier app.config
        /// </summary>
        private static readonly string appConfigUrlPath = "MediatekDocuments.Properties.Settings.RestUrl";

        /// <summary>
        /// Chemin du couple id:pwd dans le fichier app.config
        /// </summary>
        private static readonly string appConfigCredentialsPath = "MediatekDocuments.Properties.Settings.MediatekDocumentsConnectionString";

        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string DELETE = "DELETE";

        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String connectionString = null;
            String urlApi = null;
            try
            {
                connectionString = GetConnectionStringByName(appConfigCredentialsPath);
                urlApi = GetConnectionStringByName(appConfigUrlPath);
                api = ApiRest.GetInstance(urlApi,connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'accès à la bdd avec la connectionString suivante : " + connectionString + e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Récupération de la chaîne de connexion
        /// </summary>
        /// <param name="name">nom de l'information qu'on veut récupérer</param>
        /// <returns>Information de app.config lié au name</returns>
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre");
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon");
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public");
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre");
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd");
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue");
            return lesRevues;
        }

        /// <summary>
        /// Retourne tous les abonnements à partir de la BDD.
        /// </summary>
        /// <returns>Liste d'objets abonnement</returns>
        public List<Abonnement> GetAllAbonnements()
        {
            List<Abonnement> lesAbos = TraitementRecup<Abonnement>(GET, "abonnements");
            return lesAbos;
        }

        /// <summary>
        /// Retourne tous les services à partir de la BDD.
        /// </summary>
        /// <returns>Liste d'objets service.</returns>
        public List<Service> GetAllServices()
        {
            List<Service> lesServices = TraitementRecup<Service>(GET, "services");
            return lesServices;
        }


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + idDocument);
            return lesExemplaires;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire/" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false; 
        }

        /// <summary>
        /// Récupère la liste des commandes d'un document.
        /// </summary>
        /// <param name="idDocument"></param>
        /// <returns></returns>
        public List<CommandeDocument> GetCommandes(string idDocument)
        {
            List<CommandeDocument> lesCommandes = TraitementRecup<CommandeDocument>(GET, "commande/" + idDocument);
            return lesCommandes;
        }
        
        /// <summary>
        /// Crée une commande de document dans la BDD.
        /// </summary>
        /// <param name="commande">Infos de la commande.</param>
        /// <returns>Résultat de la création : réussite ou échec</returns>
        public bool CreerCommande(CommandeDocument commande)
        {
            String jsonCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());

            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "commande/" + jsonCommande);

                return (liste != null);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Mise à jour du suivi d'une commande.
        /// </summary>
        /// <param name="suivi">Nouveau suivi de la commande.</param>
        /// <param name="id">ID de la commande.</param>
        /// <returns>Résultat de l'insertion : réussite ou échec.</returns>
        public bool updateSuivi(string suivi, string id)
        {
            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(PUT, $"suivi/{id}/{{\"Statut\":\"{suivi}\"}}");

                return (liste != null);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Suppression d'une commande non livrée.
        /// </summary>
        /// <param name="commande">Informations de la commande.</param>
        /// <returns>Résultat de la suppression : réussite ou échec.</returns>
        public bool DeleteCommande(Commande commande)
        {
            IDictionary<string, string> dictCommande = new Dictionary<string, string>();
            dictCommande["Id"] = commande.Id;

            string jsonCommande = JsonConvert.SerializeObject(dictCommande);


            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, $"commande/" + jsonCommande);

                return (liste != null);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Obtenir la liste des commandes d'une revue à partir de la BDD.
        /// </summary>
        /// <param name="idRevue">ID de la revue.</param>
        /// <returns>Liste d'objets commande.</returns>
        public List<Abonnement> GetCommandesRevues(string idRevue)
        {
            List<Abonnement> lesCommandes = TraitementRecup<Abonnement >(GET, "commandeRevue/" + idRevue);
            return lesCommandes;
        }

        /// <summary>
        /// Création d'un abonnement dans la BDD.
        /// </summary>
        /// <param name="abonnement">Infos de l'abonnement.</param>
        /// <returns>Résultat de la création : réussite ou échec.</returns>
        public bool CreerAbonnement(Abonnement abonnement)
        {
            String jsonAbo = JsonConvert.SerializeObject(abonnement, new CustomDateTimeConverter());

            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "commandeRevue/" + jsonAbo);

                return (liste != null);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Suppression d'un abonnement à une revue dans la BDD.
        /// </summary>
        /// <param name="abonnement">Infos de l'abonnement</param>
        /// <returns></returns>
        public bool DeleteAbonnement(Abonnement abonnement)
        {
            IDictionary<string, string> dictAbo = new Dictionary<string, string>();
            dictAbo["Id"] = abonnement.Id;

            String jsonAbo = JsonConvert.SerializeObject(dictAbo, new CustomDateTimeConverter());

            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "abonnement/" + jsonAbo);

                return (liste != null);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Récupère la liste des utilisateurs après une connexion.
        /// </summary>
        /// <param name="nomUtilisateur">Nom de l'utilisateur</param>
        /// <param name="mdpUtilisateur">Mot de passe de l'utilisateur</param>
        /// <returns></returns>
        public List<Utilisateur> LoginUtilisateur(string nomUtilisateur, string mdpUtilisateur)
        {
            IDictionary<string, string> dictLogin = new Dictionary<string, string>();
            dictLogin["Nom"] = nomUtilisateur;
            dictLogin["Mdp"] = mdpUtilisateur;

            String jsonLogin = JsonConvert.SerializeObject(dictLogin, new CustomDateTimeConverter());

            List<Utilisateur> liste = TraitementRecup<Utilisateur>(GET, "utilisateur/" + jsonLogin);

            return liste;

        }

    /// <summary>
    /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
    /// <param name="message">information envoyée</param>
    /// <returns>liste d'objets récupérés (ou liste vide)</returns>
    private List<T> TraitementRecup<T> (String methode, String message)
        {
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message);
                // extraction du code retourné
                    String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Console.WriteLine("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Erreur lors de l'accès à l'API : "+e);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

    }
}
