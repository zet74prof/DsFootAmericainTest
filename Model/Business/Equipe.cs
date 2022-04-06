using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Equipe
    {
        private int id;
        private DateTime dateCreation;
        private string nom;
        private List<Joueur> joueurs;

        public int Id { get => id; set => id = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string Nom { get => nom; set => nom = value; }
        public List<Joueur> Joueurs { get => joueurs; set => joueurs = value; }

        public Equipe(int unId, string unNom, DateTime uneDateCreation)
        {
            Id = unId;
            DateCreation = uneDateCreation;
            Nom = unNom;
            Joueurs = new List<Joueur>();
        }
    }
}
