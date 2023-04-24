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
    public class LivreTests
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

        private static readonly string isbn = "123402304";
        private static readonly string auteur = "JP. Auteur";
        private static readonly string collection = "CollectionSympatoche";

        private static readonly Livre livre = new Livre(id, titre, image, isbn, auteur, collection, idGenre, genre, idPublic, lePublic, idRayon, rayon);
        [TestMethod()]
        public void LivreTest()
        {

            Assert.AreEqual(id, livre.Id);
            Assert.AreEqual(titre, livre.Titre);
            Assert.AreEqual(image, livre.Image);
            Assert.AreEqual(isbn, livre.Isbn);
            Assert.AreEqual(auteur, livre.Auteur);
            Assert.AreEqual(collection, livre.Collection);
            Assert.AreEqual(idGenre, livre.IdGenre);
            Assert.AreEqual(genre, livre.Genre);
            Assert.AreEqual(idPublic, livre.IdPublic);
            Assert.AreEqual(lePublic, livre.Public);
            Assert.AreEqual(idRayon, livre.IdRayon);
            Assert.AreEqual(rayon, livre.Rayon);




        }
    }
}