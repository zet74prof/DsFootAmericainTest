using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Model.Data;

namespace DsFootAmericainTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal thedbal;
        private DaoPays thedaopays;
        private DaoPoste thedaoposte;
        private DaoEquipe thedaoequipe;
        private DaoJoueur thedaojoueur;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            thedbal = new Dbal("dsfootamericain");
            thedaopays = new DaoPays(thedbal);
            thedaoposte = new DaoPoste(thedbal);
            thedaoequipe = new DaoEquipe(thedbal);
            thedaojoueur = new DaoJoueur(thedbal, thedaopays, thedaoposte, thedaoequipe);


            // Create the startup window
            MainWindow wnd = new MainWindow(thedaopays, thedaoposte, thedaoequipe, thedaojoueur);
            wnd.Show();

        }
    }
}
