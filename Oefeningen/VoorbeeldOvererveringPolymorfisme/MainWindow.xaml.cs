using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VoorbeeldOvererveringPolymorfisme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStudent_Click(object sender, RoutedEventArgs e)
        {
            List<Studenten> studentData = Bestandsbewerking.LeesStudenten();
            StringBuilder sb = new StringBuilder();

            foreach(Studenten student in studentData)
            {


                sb.AppendLine(student.VolledigeNaam() + " " + student.ToString());
            }

            
            TxtResultaat.Text = sb.ToString();
        }

        private void BtnLector_Click(object sender, RoutedEventArgs e)
        {
            List<Lector> lectoren = Bestandsbewerking.LeesLectoren();
            StringBuilder sb = new StringBuilder();

            foreach (Lector lector in lectoren)
            {

                //omdat we dit als 1 object mee geven moeten we dit als string doorgevn
                sb.AppendLine(lector.ToString());
            }


            TxtResultaat.Text = sb.ToString();

        }

        private void BtnPersoon_Click(object sender, RoutedEventArgs e)
        {
            if ((Validator.IsPresent(TxtEmail) == false) || (Validator.IsValidEmail(TxtEmail) == false))
            {
                if (Validator.IsPresent(TxtEmail) == false)
                {
                    MessageBox.Show("Email moet ingevuld worden");
                }
                else if (Validator.IsValidEmail(TxtEmail) == false)
                {
                    MessageBox.Show("Email moet een geldig emailadres zijn!");
                }

            }
            else
            {
                //eigen gegevens
                //Naam voornaam 

            }
        }
    }
}









//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.IO;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace VoorbeeldOvererveringPolymorfisme
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        private void BtnStudent_Click(object sender, RoutedEventArgs e)
//        {
//            Studenten studenten = new Studenten();
//            List<string> studentData = Bestandsbewerking.LeesStudenten();
//            StringBuilder sb = new StringBuilder();

//            sb.Clear();

//            for (int i = 0; i < studentData.Count; i++)
//            {
//                string[] data = studentData[i].Split(';');
//                studenten.Naam = data[0];
//                studenten.Voornaam = data[1];
//                studenten.Straat = data[2];
//                studenten.Postcode = data[3];
//                studenten.Betaald = data[4];
//                studenten.Opleiding = data[5];
//                studenten.TypeStudent = data[6];
//                if (data[7] != "")
//                {
//                    studenten.Studiepunten = Convert.ToInt32(data[7]);
//                }

//                sb.AppendLine($"{studenten.VolledigeNaam()} {studenten}");
//            }


//            TxtResultaat.Text = sb.ToString();
//        }

//        private void BtnLector_Click(object sender, RoutedEventArgs e)
//        {
//            Lector lector = new Lector();
//            List<string> lectorData = Bestandsbewerking.LeesLectoren();
//            StringBuilder sb = new StringBuilder();

//            sb.Clear();


//            for (int i = 0; i < lectorData.Count; i++)
//            {
//                string[] data = lectorData[i].Split(';');
//                lector.Naam = data[0];
//                lector.Voornaam = data[1];
//                lector.GeboorteDatum = Convert.ToDateTime(data[2]);
//                lector.Straat = data[3];
//                lector.Postcode = data[4];
//                lector.Statuut = data[5];
//                lector.Afdeling = data[6];
//                lector.Indienst = Convert.ToDateTime(data[7]);

//                sb.AppendLine($"{lector.VolledigeNaam()}  -  {lector.Statuut}  -  {lector.Afdelingsnaam(lector.Afdeling)}");
//            }


//            TxtResultaat.Text = sb.ToString();
//        }

//        private void BtnPersoon_Click(object sender, RoutedEventArgs e)
//        {
//            if ((Validator.IsPresent(TxtEmail) == false) || (Validator.IsValidEmail(TxtEmail) == false))
//            {
//                if (Validator.IsPresent(TxtEmail) == false)
//                {
//                    MessageBox.Show("Email moet ingevuld worden");
//                }
//                else if (Validator.IsValidEmail(TxtEmail) == false)
//                {
//                    MessageBox.Show("Email moet een geldig emailadres zijn!");
//                }

//            }
//            else
//            {
//                //eigen gegevens
//                //Naam voornaam 

//            }
//        }
//    }
//}
