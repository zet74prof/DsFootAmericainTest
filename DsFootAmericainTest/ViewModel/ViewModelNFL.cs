using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;
using Model.Business;

namespace DsFootAmericainTest.ViewModel
{
    public class ViewModelNFL
    {
        private DaoPays vmDaoPays;
        private DaoPoste vmDaoPoste;
        private DaoEquipe vmDaoEquipe;
        private DaoJoueur vmDaoJoueur;

        public ViewModelNFL(DaoPays thedaopays, DaoPoste thedaoposte, DaoEquipe thedaoequipe, DaoJoueur thedaojoueur)
        {
            vmDaoPays = thedaopays;
            vmDaoPoste = thedaoposte;
            vmDaoEquipe = thedaoequipe;
            vmDaoJoueur = thedaojoueur;
        }
    }
}
