using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    public partial class FrmConnexion : Form
    {
        private readonly FrmConnexionController controller;

        private readonly List<Service> services;

        private FrmMediatek FrmMediatek;

        public FrmConnexion()
        {
            InitializeComponent();
            this.controller = new FrmConnexionController();
            this.services = controller.GetAllServices();

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string nomUtilisateur = txbNomUtilisateur.Text;
            string mdpUtilisateur = txbMotDePasse.Text;

            List<Utilisateur> utilisateurs = controller.LoginUtilisateur(nomUtilisateur, mdpUtilisateur);

            if(utilisateurs.Count == 1)
            {
                Utilisateur utilisateur = utilisateurs[0];

                Service serviceUtilisateur = services.Find(x => x.Id.Equals(utilisateur.IdService));

                if(serviceUtilisateur.Nom == "culture")
                {
                    MessageBox.Show("Vous n'êtes pas autorisé.e à accéder à cette application.","Accès refusé !",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    this.Hide();
                    FrmMediatek = new FrmMediatek(serviceUtilisateur.Nom);
                    FrmMediatek.Show();
                    FrmMediatek.FormClosing += (obj, args) => { this.Close(); };
                }
            }

            else
            {
                MessageBox.Show("Le nom d'utilisateur.ice et/ou le mot de passe sont incorrects", "Échec de l'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
