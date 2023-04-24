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
    public class AbonnementTests
    {
        private readonly static string idAbo = "12345";

        private readonly static DateTime date = DateTime.Now;

        private readonly static double montant = 200d;

        private readonly static DateTime datePlusTard = date + TimeSpan.FromDays(1);

        private readonly static string idRevue = "10001";

        private readonly static Abonnement abo = new Abonnement(idAbo,date,montant,datePlusTard,idRevue);

        private readonly static Abonnement aboIncorrect = new Abonnement(idAbo, datePlusTard, montant, date, idRevue);


        [TestMethod()]
        public void AbonnementTest()
        {
            Assert.AreEqual(idAbo, abo.Id);
            Assert.AreEqual(date, abo.DateCommande);
            Assert.AreEqual(montant, abo.Montant);
            Assert.AreEqual(datePlusTard, abo.DateFinAbonnement);
            Assert.AreEqual(idRevue, abo.IdRevue);
        }
    }
}