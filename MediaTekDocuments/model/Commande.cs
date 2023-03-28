using System;

namespace MediaTekDocuments.model
{

    /// <summary>
    /// Classe métier suivi (intègre les propriétés id, statut)
    /// </summary>
    public class Commande
    {

        public string Id { get; set; }

        public DateTime DateCommande { get; set; }

        public double Montant { get; set; }

        public int NbExemplaire { get; set; }

        public string IdLivreDvd { get; set; }

        public string Statut { get; set; }

        public Commande(string id, DateTime date, double montant, int nombreExemplaires, string idDocument, string statut) 
        {
            this.Id = id;

            this.DateCommande = date;

            this.Montant = montant;

            this.NbExemplaire = nombreExemplaires;

            this.IdLivreDvd = idDocument;

            this.Statut = statut;
        }

    }
}
