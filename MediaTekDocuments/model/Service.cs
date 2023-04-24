using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Service (contient les propriétés Id, Nom)
    /// Permet de lier un service à un utilisateur.
    /// </summary>
    public class Service
    {
        public string Id { get; }
        public string Nom { get; }

        public Service(string idService, string nomService)
        {
            this.Id = idService;
            this.Nom = nomService;
        }

    }
}
