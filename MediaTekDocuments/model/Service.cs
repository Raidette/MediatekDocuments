using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
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
