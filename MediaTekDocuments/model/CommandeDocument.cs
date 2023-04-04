using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediaTekDocuments.model
{
    public class CommandeDocument : Commande
    {

        public int NbExemplaire { get; set; }

        public string IdLivreDvd { get; set; }

        public string Statut { get; set; }

        public CommandeDocument(string id, DateTime date, double montant, int nombreExemplaires, string idDocument, string statut) : base(id,date,montant)
        {
            this.NbExemplaire = nombreExemplaires;

            this.IdLivreDvd = idDocument;

            this.Statut = statut;
        }
    }
}
