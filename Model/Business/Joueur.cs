using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Joueur
    {
        private int id;
        private string nom;
        private DateTime dateEntree;
        private DateTime dateNaissance;
        private Pays thePays;
        private Poste thePoste;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DateEntree { get => dateEntree; set => dateEntree = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public Pays ThePays { get => thePays; set => thePays = value; }
        public Poste ThePoste { get => thePoste; set => thePoste = value; }
        public Joueur (int id, string nom, DateTime dateEntree, DateTime dateNaissance, Pays unPays, Poste unPoste)
        {
            Id = id;
            Nom = nom;
            DateEntree = dateEntree;
            DateNaissance = dateNaissance;
            if (unPays == null) { ThePays = new Pays(); }
            else ThePays = unPays;
            if (unPoste == null) { ThePoste = new Poste(); }
            else ThePoste = unPoste;
        }

        public override string ToString()
        {
            return Nom;
        }

    }
}
