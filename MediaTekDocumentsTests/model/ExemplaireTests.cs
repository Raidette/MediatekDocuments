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
    public class ExemplaireTests
    {
        private static readonly int numero = 12345;
        private static readonly DateTime dateAchat = DateTime.Now;
        private static readonly string photo = "12345"; 
        private static readonly string idEtat = "00001";
        private static readonly string idDocument = "0000&";

        private static readonly Exemplaire exemplaire = new Exemplaire(numero, dateAchat, photo, idEtat, idDocument);
        [TestMethod()]
        public void ExemplaireTest()
        {
            Assert.AreEqual(numero, exemplaire.Numero);
            Assert.AreEqual(dateAchat, exemplaire.DateAchat);
            Assert.AreEqual(photo, exemplaire.Photo);
            Assert.AreEqual(idEtat, exemplaire.IdEtat);
            Assert.AreEqual(idDocument, exemplaire.Id);
        }
    }
}