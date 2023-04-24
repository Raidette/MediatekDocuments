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
    public class DocumentTests
    {
        private static readonly string id = "12345"; 
        private static readonly string titre = "Le titre";
        private static readonly string image = "L'image"; 
        private static readonly string idGenre = "00001";
        private static readonly string genre = "Policier"; 
        private static readonly string idPublic = "00001";
        private static readonly string lePublic = "Jeunesse"; 
        private static readonly string idRayon = "00001";
        private static readonly string rayon = "Tous publics";

        private static readonly Document document = new Document(id,titre,image,idGenre,genre,idPublic,lePublic,idRayon,rayon);

        [TestMethod()]
        public void DocumentTest()
        {
            Assert.AreEqual(id, document.Id);
            Assert.AreEqual(titre, document.Titre);
            Assert.AreEqual(image, document.Image);
            Assert.AreEqual(idGenre, document.IdGenre);
            Assert.AreEqual(genre, document.Genre);
            Assert.AreEqual(idPublic, document.IdPublic);
            Assert.AreEqual(lePublic, document.Public);
            Assert.AreEqual(idRayon, document.IdRayon);
            Assert.AreEqual(rayon, document.Rayon);
        }
    }
}