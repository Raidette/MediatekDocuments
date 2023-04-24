using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model.Tests
{
    [TestClass()]
    public class CommandeDocumentTests
    {
        private static readonly string id = "12345"; 
        private static readonly DateTime date = DateTime.Now; 
        private static readonly double montant = 200d;
        private static readonly int nombreExemplaires = 200;
        private static readonly string idDocument = "00017";
        private static readonly string statut = "Réglée";

        private readonly CommandeDocument commande = new CommandeDocument(id,date,montant,nombreExemplaires,idDocument,statut);
        [TestMethod()]
        public void CommandeDocumentTest()
        {
            Assert.AreEqual(id, commande.Id);
            Assert.AreEqual(date, commande.DateCommande);
            Assert.AreEqual(montant, commande.Montant);
            Assert.AreEqual(nombreExemplaires, commande.NbExemplaire);
            Assert.AreEqual(idDocument, commande.IdLivreDvd);
            Assert.AreEqual(statut, commande.Statut);
        }
    }
}