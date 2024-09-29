using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Toepassing28_DbMedewerkersClassLib;

namespace Toepassing28_DbMedewerker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Medewerker md;
        string connectionString = Toepassing28_DbMedewerker.Properties.Settings.Default.CNstr;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnZoekenClick(object sender, RoutedEventArgs e)
        {
            md = DBMedewerkers.ZoekMnr(int.Parse(TxtMnr.Text), connectionString);
            if (md == null)
            {
                MessageBox.Show("Medewerker niet gevonden");
            }
            else
            {
                //TxtMnr.Text = md.MnrID.ToString();
                TxtNaam.Text = md.Naam;
                TxtVoornaam.Text = md.Voornaam;
                TxtFucntie.Text = md.Functie;
                TxtChef.Text = md.Chef.ToString();
                TxtGebDatum.Text = md.GbDatum.ToString();
                TxtMaandsal.Text = md.Maandsalaris.ToString();
                TxtComm.Text = md.Comm.ToString();
                TxtAfdeling.Text = md.Afdeling.ToString();
            }
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (DBMedewerkers.ToevoegenMedewerker(MaakNieuweMedewerker(), connectionString) > 0)
            {
                MessageBox.Show("Mdw is toegevoegd");
            }
            else
            {
                MessageBox.Show("Fout in toevoegen medewerker, bel dan IT...");
            }
        }

        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {

            if (DBMedewerkers.UpdateMedewerker(md, MaakNieuweMedewerker(), connectionString))
            {
                MessageBox.Show("Medewerker is aangepast");
            }
            else
            {
                MessageBox.Show("nope");
            }

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private Medewerker MaakNieuweMedewerker()
        {
            Medewerker nieuweMdw = new Medewerker();
            nieuweMdw.Chef = int.Parse(TxtChef.Text);
            nieuweMdw.MnrID = int.Parse(TxtMnr.Text);
            nieuweMdw.Voornaam = TxtVoornaam.Text;
            nieuweMdw.Naam = TxtNaam.Text;
            //if (nieuweMdw.Comm = null) && (nieuweMdw.Functie = "VERKOPER")

            nieuweMdw.Comm = string.IsNullOrEmpty(TxtComm.Text) ? 0 : float.Parse(TxtComm.Text);
            nieuweMdw.Functie = TxtFucntie.Text;
            nieuweMdw.Maandsalaris = float.Parse(TxtMaandsal.Text);
            nieuweMdw.Afdeling = int.Parse(TxtAfdeling.Text);
            nieuweMdw.GbDatum = DateTime.Parse(TxtGebDatum.Text);

            return nieuweMdw;
        }

        private void BtnVerwijderen_Click(object sender, EventArgs e)
        {
            if (DBMedewerkers.VerwijderMedewerker(new Medewerker() { MnrID = int.Parse(TxtMnr.Text) }, connectionString))
            {
                MessageBox.Show("Medewerker is verwijderd");
            }
            else
            {
                MessageBox.Show("Fout bij het verwijderen");
            }
        }
    }
}

