using System;
using System.Collections.Generic;
using System.Data;
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

namespace Toepassing101_DeMolDisconnected
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //static verhinderd dat we meerdere klasses moeten maken



        public MainWindow()
        {
            InitializeComponent();
            //MaakTabellen mk = new MaakTabellen();
            //mk.MaakTabellenMethod();

            MaakTabellen.MaakTabellenMethod();
        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string naam = TxtNaam.Text;
            string wachtwoord = TxtWachtwoord.Text;

            foreach (DataRow dr in MaakTabellen.dtSpelers.Rows)
            {
                if ((naam == Convert.ToString(dr[2])) && (wachtwoord == Convert.ToString((dr[3]))))
                {
                    int spelerId = Convert.ToInt32(dr[0]);
                    //Window profileWindow = ProfileWindow();
                    ProfileWindow profileW = new ProfileWindow(spelerId);
                    profileW.Show();
                    return;
                }
                else
                {
                    //MessageBox.Show("inlog is niet correct");
                    //return;
                    //MessageBox.Show($"{Convert.ToString(dr[2])} {Convert.ToString(dr[3])}");
                }
            }


        }

        private void ZetKleur(string kleur)
        {
            //die de tekst in het
            //profielvenster van kleur verandert
        }

        private void GetSpel()
        {
            // die het spel van de speler ophaalt
            //uit de “database”.
        }

        private void BitmapVerander()
        {
            //bitmap image weizigen van image
        }
    }
}
