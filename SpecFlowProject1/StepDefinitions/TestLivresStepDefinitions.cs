using System;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using MediaTekDocuments.view;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTestsFonctionnels.StepDefinitions
{
    [Binding]
    public class TestLivresStepDefinitions
    {
        private static readonly FrmMediatek form = new FrmMediatek("prêts");

        private static readonly DataGridView dgvLivres = (DataGridView)form.Controls["tabControlFrmMediatek"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["dgvLivresListe"];


        [Given(@"Je saisis la valeur ""([^""]*)"" dans le champ de recherche de titre")]
        public void GivenJeSaisisLaValeurDansLeChampDeRechercheDeTitre(string guide)
        {
            TextBox txbLivresTitreRecherche = (TextBox)form.Controls["tabControlFrmMediatek"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["txbLivresTitreRecherche"];

            txbLivresTitreRecherche.Text = guide;
        }

        [When(@"Je clique sur le bouton de recherche")]
        public void WhenJeCliqueSurLeBoutonDeRecherche()
        {
            Button btnLivresRecherche = (Button)form.Controls["tabControlFrmMediatek"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["btnLivresNumRecherche"];

            btnLivresRecherche.PerformClick();
        }

        [Then(@"Le datagridview affiche des livres avec le nom contenant uniquement la valeur ""([^""]*)""")]
        public void ThenLeDatagridviewAfficheDesLivresAvecLeNomContenantUniquementLaValeur(string guide)
        {
            bool result = true;


            foreach (DataGridViewRow row in dgvLivres.Rows) 
            {
                Livre livre = (Livre)row.DataBoundItem;


                if (!livre.Titre.Contains(guide))
                {
                    result = false;
                    break;
                }

                result.Should().BeTrue();
            }
        }

        [Given(@"Je saisis la valeur ""([^""]*)"" dans le champ de recherche de l'id")]
        public void GivenJeSaisisLaValeurDansLeChampDeRechercheDeLid(string p0)
        {
            TextBox txbLivresNumRecherche = (TextBox)form.Controls["tabControlFrmMediatek"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["txbLivresNumRecherche"];

            txbLivresNumRecherche.Text = p0;

        }

        [Then(@"Le datagridview affiche le livre possédant l'id ""([^""]*)""")]
        public void ThenLeDatagridviewAfficheLeLivrePossedantLid(string p0)
        {
            bool result = true;

            foreach (DataGridViewRow row in dgvLivres.Rows)
            {
                Livre livre = (Livre)row.DataBoundItem;


                if (livre.Id != p0)
                {
                    result = false;
                    break;
                }

                result.Should().BeTrue();
            }
        }

        [Given(@"Je choisis l'option ""([^""]*)"" dans le combobox de recherche par genre")]
        public void GivenJeChoisisLoptionDansLeComboboxDeRechercheParGenre(string voyages)
        {
            ComboBox cbxLivresGenres = (ComboBox)form.Controls["tabControlFrmMediatek"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["cbxLivresGenres"];

            cbxLivresGenres.SelectedText = voyages;
        }

        [Then(@"Tous les livres auront ""([^""]*)"" comme genre")]
        public void ThenTousLesLivresAurontCommeGenre(string voyages)
        {
            bool result = true;

            foreach (DataGridViewRow row in dgvLivres.Rows)
            {
                Livre livre = (Livre)row.DataBoundItem;

                if (livre.Genre != voyages)
                {
                    result = false;
                    break;
                }

                result.Should().BeTrue();
            }
        }

        [Given(@"Je choisis l'option ""([^""]*)"" dans le combobox de recherche par public")]
        public void GivenJeChoisisLoptionDansLeComboboxDeRechercheParPublic(string p0)
        {
            ComboBox cbxLivresPublic = (ComboBox)form.Controls["tabControlFrmMediatek"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["cbxLivresGenres"];

            cbxLivresPublic.SelectedText = p0;
        }

        [Then(@"Tous les livres auront ""([^""]*)"" comme public")]
        public void ThenTousLesLivresAurontCommePublic(string p0)
        {
            bool result = true;


            foreach (DataGridViewRow row in dgvLivres.Rows)
            {
                Livre livre = (Livre)row.DataBoundItem;

                if (livre.Public != p0)
                {
                    result = false;
                    break;
                }

                result.Should().BeTrue();
            }

        }

        [Given(@"Je choisis l'option ""([^""]*)"" dans le combobox de recherche par rayon")]
        public void GivenJeChoisisLoptionDansLeComboboxDeRechercheParRayon(string voyages)
        {
            ComboBox cbxLivresRayons = (ComboBox)form.Controls["tabControlFrmMediatek"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["cbxLivresRayons"];

            cbxLivresRayons.SelectedText = voyages;

        }

        [Then(@"Tous les livres seront dans le rayon ""([^""]*)""")]
        public void ThenTousLesLivresSerontDansLeRayon(string voyages)
        {
            bool result = true;

            foreach (DataGridViewRow row in dgvLivres.Rows)
            {
                Livre livre = (Livre)row.DataBoundItem;

                if (livre.Rayon != voyages)
                {
                    result = false;
                    break;
                }

                result.Should().BeTrue();
            }
        }
    }
}
