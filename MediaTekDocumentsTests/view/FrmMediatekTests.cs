using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.view.Tests
{
    [TestClass()]
    public class FrmMediatekTests
    {

        private FrmMediatek form = new FrmMediatek("administrateur");

        static readonly DateTime now = DateTime.Now;
        static readonly DateTime later = now + TimeSpan.FromHours(1.0);
        static readonly DateTime laterer = now + TimeSpan.FromHours(8.0);


        [TestMethod()]
        public void commandeDansAbonnementTest()
        {
            Assert.AreEqual(false,form.commandeDansAbonnement(now,later,laterer)); // Commande : maintenant, FinAbo : + tard, DateParution : ++ tard

            Assert.AreEqual(false, form.commandeDansAbonnement(later, laterer, now)); // Commande : + tard, finabo : ++tard, parution : mtn 
             
            Assert.AreEqual(true,form.commandeDansAbonnement(now, laterer, later)); // Commande : mtn, FinAbo : ++tard, parution : + tard

            Assert.AreEqual(true,form.commandeDansAbonnement(now, later, now)); // Commande : mtn, finAbo : +tard, parution : mtn

        }
    }
}