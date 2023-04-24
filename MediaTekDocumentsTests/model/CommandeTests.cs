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
    public class CommandeTests
    {
        private readonly static string id = "12345";

        private readonly static DateTime date = DateTime.Now;

        private readonly static double montant = 200d;

        private readonly static Commande commande = new Commande(id, date,montant);

        [TestMethod()]
        public void CommandeTest()
        {
            Assert.AreEqual(id,commande.Id);

            Assert.AreEqual(date, commande.DateCommande);

            Assert.AreEqual(montant, commande.Montant);
        }
    }
}