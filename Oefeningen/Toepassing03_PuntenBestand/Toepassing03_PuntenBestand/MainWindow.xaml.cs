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

namespace Toepassing03_PuntenBestand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] namen;

        double score;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnInlezen_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("Punten.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] readenLine = line.Split(',');

                    if (readenLine[0] != "")
                    {
                        LBResultaat.Items.Add($"{readenLine[0],-40}");
                        //als we deze aligned willen hebben gebruiken we consolas als font, gezien hier
                        //elk character even lang is
                    }

                }
            }
            BtnVerwerken.Visibility = Visibility.Visible;
            BtnNalezen.Visibility = Visibility.Visible;
        }

        private void Btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.I)
            {
                BtnInlezen_Click(sender, e);
            }

            if (e.Key == Key.V)
            {
                BtnVerwerken_Click(sender, e);
            }

            if (e.Key == Key.N)
            {
                BtnNalezen_Click(sender, e);
            }

            if (e.Key == Key.S)
            {
                BtnSluiten_Click(sender, e);
            }
        }

        private void BtnVerwerken_Click(object sender, RoutedEventArgs e)
        {
            /*
            //maak 2D array
            // define the dimensions of the array
            int numLines = LBResultaat.Items.Count;
            int numWords = 5;
   
            allTheItems = new string[numLines, numWords];

            //hier gaan we de hele lijst mee af
            for (int i = 0; i < LBResultaat.Items.Count; i++)
            {
                string[] words = LBResultaat.Items[i].ToString().Split(' ');

                int q = 0;
                //hier gaan we de hele lijn mee af voor woorden
                for (int j = 0; j < words.Length; j++)
                {
                    if (!string.IsNullOrWhiteSpace(words[j]))
                    {
                        allTheItems[i, q] = words[j];
                        q++;
                        //MessageBox.Show(words[j]);
                    }
                }
            }

            

            int i = 0;
            StreamReader sr = new StreamReader("Punten.txt");
            while (!sr.EndOfStream)
            {
                string[] waarden = sr.ReadLine().Split(' ');

                if (waarden[0] != "")
                {
                    namen[i] = ($"{waarden[0].Trim('"')}" + "" $"{waarden[1].Trim('"')}");

                }
                i += 1;
            }
            sr.Close();
            //foreach (var item in dicGeg)
            //{
            //    TxtResultaat.Text += ($"{item.Key}: {item.Value}\n");
            //}
            */

            using (StreamWriter sw = new StreamWriter("PuntenVerwerkt.txt"))
            {

                // Process each line in the ListBox
                for (int i = 0; i < LBResultaat.Items.Count; i++)
                {
                    int nummer = 1;
                    string passFail;



                    string line = LBResultaat.Items[i].ToString();
                    // Split the line into separate fields
                    string[] fields = line.Split(' ');

                    // Extract the name, score, and pass/fail status
                    string name = $"{fields[0]}" + " " + $"{fields[1]}";
                    //if null
                    if (fields[fields.Length - nummer] == "")
                    {
                        nummer += 1;
                    }
                    else
                    {
                        string result1 = fields[fields.Length - nummer].Substring(0, 3);
                        string result2 = fields[fields.Length - nummer].Substring(3, 3);
                        score = (double.Parse(result1) / double.Parse(result2)) * 100;
                    }



                    passFail = (score >= 85) ? "geslaagd" : "niet geslaagd";



                    // Write the fixed-length record to the output file
                    sw.Write(name.PadRight(40));
                    sw.WriteLine($"{score}% {passFail}".PadLeft(3));

                }
            }

            // Display a message box indicating that the file has been written
            MessageBox.Show("Het bestand is verwerkt en weggeschreven.");


        }

        private void BtnNalezen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
