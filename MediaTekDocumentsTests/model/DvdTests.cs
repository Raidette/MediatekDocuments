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
    public class DvdTests
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

        private static readonly int duree = 120;
        private static readonly string realisateur = "Spielberg";
        private static readonly string synopsis = "Un film assez moyen dans l'ensemble";

        private static readonly Dvd dvd = new Dvd(id, titre, image, duree, realisateur, synopsis, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod()]
        public void DvdTest()
        {
            Assert.AreEqual(id, dvd.Id);
            Assert.AreEqual(titre, dvd.Titre);
            Assert.AreEqual(image, dvd.Image);
            Assert.AreEqual(duree, dvd.Duree);
            Assert.AreEqual(realisateur, dvd.Realisateur);
            Assert.AreEqual(synopsis, dvd.Synopsis);
            Assert.AreEqual(idGenre, dvd.IdGenre);
            Assert.AreEqual(genre, dvd.Genre);
            Assert.AreEqual(idPublic, dvd.IdPublic);
            Assert.AreEqual(lePublic, dvd.Public);
            Assert.AreEqual(idRayon, dvd.IdRayon);
            Assert.AreEqual(rayon, dvd.Rayon);

        }
    }
}