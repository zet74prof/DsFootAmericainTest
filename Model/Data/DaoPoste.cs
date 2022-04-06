﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoPoste
    {
        private Dbal thedbal;

        public DaoPoste(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Poste thePoste)
        {
            string query = "Poste (id, nom, escouade) VALUES (" + thePoste.Id + ",'" + thePoste.Nom.Replace("'", "''") + ",'" + thePoste.Escouade + "')";
            this.thedbal.Insert(query);
        }

        public List<Poste> SelectAll()
        {
            List<Poste> listPoste = new List<Poste>();
            DataTable myTable = this.thedbal.SelectAll("Poste");

            foreach (DataRow r in myTable.Rows)
            {
                listPoste.Add(new Poste((int)r["id"], (string)r["nom"], (int)r["escouade"]));
            }

            return listPoste;
        }

        public Poste SelectByName(string namePoste)
        {
            DataTable result = new DataTable();
            result = this.thedbal.SelectByField("Poste", "nom = '" + namePoste.Replace("'", "''") + "'");
            Poste foundPoste = new Poste((int)result.Rows[0]["id"], (string)result.Rows[0]["nom"], (int)result.Rows[0]["escouade"]);
            return foundPoste;

        }

        public Poste SelectById(int idPoste)
        {
            DataRow result = this.thedbal.SelectById("Poste", idPoste);
            return new Poste((int)result["id"], (string)result["nom"], (int)result["escouade"]);

        }
    }
}
