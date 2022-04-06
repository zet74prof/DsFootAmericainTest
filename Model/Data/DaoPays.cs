using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

using Model.Business;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Model.Data
{
    public class DaoPays
    {
        private Dbal thedbal;

        public DaoPays(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Pays thePays)
        {
            string query = "Pays (id, nom) VALUES (" + thePays.Id + ",'" + thePays.Nom.Replace("'", "''") + "')";
            this.thedbal.Insert(query);
        }

        public List<Pays> SelectAll()
        {
            List<Pays> listPays = new List<Pays>();
            DataTable myTable = this.thedbal.SelectAll("Pays");

            foreach (DataRow r in myTable.Rows)
            {
                listPays.Add(new Pays((int)r["id"], (string)r["nom"]));
            }

            return listPays;
        }

        public Pays SelectByName(string namePays)
        {
            DataTable result = new DataTable();
            result = this.thedbal.SelectByField("Pays", "nom = '" + namePays.Replace("'","''") + "'");
            Pays foundPays = new Pays((int)result.Rows[0]["id"],(string)result.Rows[0]["nom"]);
            return foundPays;

        }

        public Pays SelectById(int idPays)
        {
            DataRow result = this.thedbal.SelectById("Pays", idPays);
            return new Pays((int)result["id"], (string)result["nom"]);

        }
    }
}
