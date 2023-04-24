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
    public class EtatTests
    {
        private static readonly string id = "00001";
        private static readonly string libelle = "Neuf";

        private static readonly Etat etat = new Etat(id, libelle);
        [TestMethod()]
        public void EtatTest()
        {
            Assert.AreEqual(id, etat.Id);
            Assert.AreEqual(libelle, etat.Libelle);
        }
    }
}