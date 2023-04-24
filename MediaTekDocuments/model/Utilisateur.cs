
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier utilisateur : contient les informations d'un utilisateur (id,nom,mdp,idService)
    /// </summary>
    public class Utilisateur
    {
        public string Id { get; }

        public string Nom { get; }
        public string Mdp { get; }
        public string IdService { get; }

        public Utilisateur(string id, string nom, string mdp, string idService)
        {
            this.Id = id;
            this.Nom = nom;
            this.Mdp = mdp;
            this.IdService = idService;
        }
    }
}
