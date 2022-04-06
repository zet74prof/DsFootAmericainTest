using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Poste
    {
        private int id;
        private string nom;
        private int escouade;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Escouade { get => escouade; set => escouade = value; }

        public Poste(int id, string nom, int escouade)
        {
            Id = id;
            Nom = nom;
            Escouade = escouade;
        }

        public Poste()
        {

        }

        public override string ToString()
        {
            return Nom;
        }



    }
}
