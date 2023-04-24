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
    public class RevueTests
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

        private static readonly string periodicite = "MS";
        private static readonly int delaiMiseADispo = 2;

        private static readonly Revue revue = new Revue(id,titre,image,idGenre,genre,idPublic,lePublic,idRayon,rayon,periodicite,delaiMiseADispo);

        [TestMethod()]
        public void RevueTest()
        {
            Assert.AreEqual(id, revue.Id);
            Assert.AreEqual(titre, revue.Titre);
            Assert.AreEqual(image, revue.Image);
            Assert.AreEqual(idGenre, revue.IdGenre);
            Assert.AreEqual(genre, revue.Genre);
            Assert.AreEqual(idPublic, revue.IdPublic);
            Assert.AreEqual(lePublic, revue.Public);
            Assert.AreEqual(idRayon, revue.IdRayon);
            Assert.AreEqual(rayon, revue.Rayon);

            Assert.AreEqual(periodicite, revue.Periodicite);
            Assert.AreEqual(delaiMiseADispo, revue.DelaiMiseADispo);
        }
    }
}