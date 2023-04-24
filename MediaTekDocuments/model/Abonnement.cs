using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier abonnement (intègre les propriétés DateFinAbonnement et IDRevue)
    /// Hérite de la classe métier commande.
    /// </summary>
    public class Abonnement : Commande
    {

        public DateTime DateFinAbonnement { get; set; }

        public string IdRevue { get; set; }

        public Abonnement(string id, DateTime date, double montant, DateTime dateFinAbo, string idRevue) : base(id,date,montant)
        {
            if(dateFinAbo >= date)
            {

                this.DateFinAbonnement = dateFinAbo;

                this.IdRevue = idRevue;

            }

        }

    }
}
