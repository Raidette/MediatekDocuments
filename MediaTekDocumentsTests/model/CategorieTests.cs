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
    public class CategorieTests
    {

        private readonly static string libelle = "Horreur";
        private readonly static string id = "12345";

        private readonly static Categorie categorie = new Categorie(id,libelle);

        [TestMethod()]
        public void CategorieTest()
        {
            Assert.AreEqual(id,categorie.Id);
            Assert.AreEqual(libelle,categorie.Libelle);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle,categorie.ToString());
        }
    }
}