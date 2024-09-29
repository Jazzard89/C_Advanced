using System;
using System.Collections.Generic;
using System.IO;
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

namespace Toepassing04_Zonnepanelen
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

        private void MenuRead_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("Zonnepanelen.txt"))
            {
                StringBuilder sb = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    sb.AppendLine(sr.ReadLine());


                }
                TxtResult.Text = sb.ToString();
            }
        }

        private void MenuDetails_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("Zonnepanelen.txt"))
            {
                StringBuilder sb = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    string originalString = sr.ReadLine();
                    string[] splitString = originalString.Split('-', ',');

                    string date = splitString[0].Trim();
                    string firstNumber = splitString[1].Trim();
                    string secondNumber = splitString[2].Trim();

                    DateTime parsedDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                    string monthName = parsedDate.ToString("MMMM");

                    sb.AppendLine($"{monthName} - Aantal metingen: {firstNumber} - Gemiddelde Productie: {secondNumber}");


                }
                TxtResult.Text = sb.ToString();
            }


        }
    }
}
