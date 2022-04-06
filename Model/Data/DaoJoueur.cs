using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoJoueur
    {
        private Dbal thedbal;
        private DaoPays theDaoPays;
        private DaoPoste theDaoPoste;
        private DaoEquipe theDaoEquipe;

        public DaoJoueur(Dbal mydbal, DaoPays myDaoPays, DaoPoste myDaoPoste, DaoEquipe myDaoEquipe)
        {
            this.thedbal = mydbal;
            this.theDaoPays = myDaoPays;
            this.theDaoPoste = myDaoPoste;
            this.theDaoEquipe = myDaoEquipe;
        }

        public void Insert(Joueur theJoueur, Equipe theEquipe)
        {
            string query = "Joueur (id, nom, dateEntree, dateNaissance, pays, poste, equipe) VALUES ("
                + theJoueur.Id + ","
                + theJoueur.Nom.Replace("'", "''") + ",'"
                + theJoueur.DateEntree.ToString("yyyy-MM-dd") + "','"
                + theJoueur.DateNaissance.ToString("yyyy-MM-dd") + "',"
                + theJoueur.ThePays.Id + ","
                + theJoueur.ThePoste.Id + ","
                + theEquipe.Id + ")";
            this.thedbal.Insert(query);
        }

        public void Update(Joueur myJoueur, Equipe myEquipe)
        {
            string query = "Joueur SET id = " + myJoueur.Id
                + ", nom = '" + myJoueur.Nom.Replace("'", "''")
                + "', dateEntree = " + myJoueur.DateEntree.ToString("yyyy-MM-dd")
                + "', dateEntree = " + myJoueur.DateEntree.ToString("yyyy-MM-dd")
                + "', pays = " + myJoueur.ThePays.Id
                + ", poste = " + myJoueur.ThePoste.Id
                + ", equipe = " + myEquipe.Id + " "
                + "WHERE id = " + myJoueur.Id;
            this.thedbal.Update(query);
        }

        public List<Joueur> SelectAll()
        {
            List<Joueur> listJoueur = new List<Joueur>();
            DataTable myTable = this.thedbal.SelectAll("Joueur");

            foreach (DataRow r in myTable.Rows)
            {
                Pays myPays = this.theDaoPays.SelectById((int)r["pays"]);
                Poste myPoste = this.theDaoPoste.SelectById((int)r["poste"]);
                Joueur myJoueur = new Joueur((int)r["id"], (string)r["nom"], (DateTime)r["dateEntree"], (DateTime)r["dateNaissance"], myPays, myPoste);
                listJoueur.Add(myJoueur);
            }

            return listJoueur;
        }

        public Joueur SelectById(int id)
        {
            DataRow rowJoueur = this.thedbal.SelectById("Joueur", id);
            Pays myPays = this.theDaoPays.SelectById((int)rowJoueur["pays"]);
            Poste myPoste = this.theDaoPoste.SelectById((int)rowJoueur["poste"]);
            return new Joueur((int)rowJoueur["id"], (string)rowJoueur["nom"], (DateTime)rowJoueur["dateEntree"], (DateTime)rowJoueur["dateNaissance"], myPays, myPoste);
        }


        public Joueur SelectByName(string name)
        {
            string search = "nom = '" + name + "'";
            DataTable tableJoueur = this.thedbal.SelectByField("Joueur", search);
            Pays myPays = this.theDaoPays.SelectById((int)tableJoueur.Rows[0]["pays"]);
            Poste myPoste = this.theDaoPoste.SelectById((int)tableJoueur.Rows[0]["poste"]);
            return new Joueur((int)tableJoueur.Rows[0]["id"], (string)tableJoueur.Rows[0]["nom"], (DateTime)tableJoueur.Rows[0]["dateEntree"], (DateTime)tableJoueur.Rows[0]["dateNaissance"], myPays, myPoste);
            
        }
    }
}

