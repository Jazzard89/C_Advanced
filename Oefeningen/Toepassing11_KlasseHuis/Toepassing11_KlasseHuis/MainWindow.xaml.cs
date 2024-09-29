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
using Microsoft.VisualBasic;

namespace Toepassing11_KlasseHuis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //class variabelen moeten 'globaal' gedeclareerd worden
        private Huis woning1;
        private Huis woning2;
        public MainWindow()
        {
            InitializeComponent();
            woning1 = new Huis();
            woning2 = new Huis();
        }

        private void BtnCreatie1_Click(object sender, RoutedEventArgs e)
        {
            string LocatieInfo = TxtLocatie.Text;
            double LengteInfo = 0;
            double.TryParse(TxtLengte.Text, out LengteInfo);
            double BreedteInfo = 0;
            double.TryParse(TxtBreedte.Text, out BreedteInfo);
            int VerdiepInfo = 0;
            int.TryParse(TxtaantalVerdiepingen.Text, out VerdiepInfo);
            string TypeInfo = "O";
            if (radOpen.IsChecked == true)
            {
                TypeInfo = "O";
            }
            else if (radHalfopen.IsChecked == true)
            {
                TypeInfo = "H";
            }
            else if (radGesloten.IsChecked == true)
            {
                TypeInfo = "G";
            }
            if (((Button)sender).Name == BtnCreatie1.Name)
            {


                if (LocatieInfo == "" && LengteInfo == 0 && BreedteInfo == 0 && VerdiepInfo == 0 && TypeInfo == "O")
                {
                    woning1 = new Huis();
                }
                else
                {
                    woning1 = new Huis(LocatieInfo, LengteInfo, BreedteInfo, VerdiepInfo, TypeInfo);

                }

            }
            else if (((Button)sender).Name == BtnCreatie2.Name)
            {
                if (LocatieInfo == "" && LengteInfo == 0 && BreedteInfo == 0 && VerdiepInfo == 0 && TypeInfo == "O")
                {
                    woning2 = new Huis();
                }
                else
                {
                    woning2 = new Huis(LocatieInfo, LengteInfo, BreedteInfo, VerdiepInfo, TypeInfo);

                }
            }

            EnableKnoppen1(sender);


        }

        //method aanmaken die private is want we geven niets mee
        private void EnableKnoppen1(object dingeske)
        {
            if (((Button)dingeske).Name == BtnCreatie1.Name)
            {
                BtnMeerdereVerhogingen1.IsEnabled = true;
                BtnVerhogen1.IsEnabled = true;
                BtnVerlagen1.IsEnabled = true;
                BtnTonen1.IsEnabled = true;
            }
            else if (((Button)dingeske).Name == BtnCreatie2.Name)
            {
                BtnMeerdereVerhogingen2.IsEnabled = true;
                BtnVerhogen2.IsEnabled = true;
                BtnVerlagen2.IsEnabled = true;
                BtnTonen2.IsEnabled = true;
            }

        }

        private void BtnVerhogen1_Click(object sender, RoutedEventArgs e)
        {
            //sender casten naar button
            //als naam van sender gelijk is aan naam van button dan is dat eerste huis
            if (((Button)sender).Name == BtnVerhogen1.Name)
            {
                //Huis1 //indien niet word meegegeven gaat dit 1 omhoog omdat dit in de property staat
                woning1.VerhoogAantalVerdiepingen();
            }
            else if (((Button)sender).Name == BtnVerhogen2.Name)
            {
                woning2.VerhoogAantalVerdiepingen();
            }
        }

        private void BtnMeerdereVerhogingen1_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == BtnMeerdereVerhogingen1.Name)
            {
                //op reference klikken in de solution explorer dubbel klikken op references en voeg visual basic toe,
                //zet daarna deze in using vanboven
                string ingave = Interaction.InputBox("Geef aantal verdiepingen", "Gimme", "2"); //using Microsoft.VisualBasic; Add reference VisualBasics
                int ingaveint = int.Parse(ingave);
                if (ingaveint >= 0)
                {
                    woning1.VerhoogAantalVerdiepingen(ingaveint);
                }
                else
                {

                    woning1.VerlaagAantalVerdiepingen(-ingaveint);
                }


                /* int VerdiepUp = 0;
                 int.TryParse(TxtaantalVerdiepingen.Text, out VerdiepUp);
                 if (VerdiepUp >= 0)
                 {
                     woning1.VerhoogAantalVerdiepingen(VerdiepUp);
                 }
                 else
                 {

                     woning1.VerlaagAantalVerdiepingen(-VerdiepUp);
                 }*/
            }
            else if (((Button)sender).Name == BtnMeerdereVerhogingen2.Name)
            {

                string ingave = Interaction.InputBox("Geef aantal verdiepingen", "Gimme", "2");
                int ingaveint = int.Parse(ingave);
                if (ingaveint >= 0)
                {
                    woning2.VerhoogAantalVerdiepingen(ingaveint);
                }
                else
                {

                    woning2.VerlaagAantalVerdiepingen(-ingaveint);
                }




                /*int VerdiepUp = 0;
                int.TryParse(TxtaantalVerdiepingen.Text, out VerdiepUp);
                if (VerdiepUp >= 0)
                {
                    woning2.VerhoogAantalVerdiepingen(VerdiepUp);
                }
                else
                {

                    woning2.VerlaagAantalVerdiepingen(-VerdiepUp);
                }*/
            }
        }

        private void BtnVerlagen1_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == BtnVerlagen1.Name)
            {
                woning1.VerlaagAantalVerdiepingen();
            }
            else if (((Button)sender).Name == BtnVerlagen2.Name)
            {
                woning2.VerlaagAantalVerdiepingen();
            }
        }

        private void BtnTonen1_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == BtnTonen1.Name)
            {
                double oppervlakske = woning1.Oppervlakte();
                double Inhoudske = woning1.Inhoud();

                TxtResultaat.Text = $"{woning1.Locatie} {woning1.Lengte} {woning1.Breedte} {woning1.AantalVerdieping} {woning1.Type} {oppervlakske} {Inhoudske}";
            }

            else if (((Button)sender).Name == BtnTonen2.Name)
            {
                double oppervlakske = woning2.Oppervlakte();
                double Inhoudske = woning2.Inhoud();

                TxtResultaat.Text = $"{woning2.Locatie} {woning2.Lengte} {woning2.Breedte} {woning2.AantalVerdieping} {woning2.Type} {oppervlakske} {Inhoudske}";
            }
        }

        private void BtnBigButton_Click(object sender, RoutedEventArgs e)
        {
            PrachtigNieuweWindow beautifulNewRaampje = new PrachtigNieuweWindow();
            beautifulNewRaampje.ShowDialog();
        }
        //klasse variabelen is alitjd by ref,
        //met andere woorden gaat deze referenen aan de data locatie waar de klasse naar gebouwd is.
    }
}
