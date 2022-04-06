using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class Pays
    {
        private int id;
        private string nom;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public Pays(int id = 0, string nom="")
        {
            this.Id = id;
            this.Nom = nom;
        }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
