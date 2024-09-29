using Microsoft.Win32;
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
using static System.Net.WebRequestMethods;

namespace T1_EmailBestand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StringBuilder sb = new StringBuilder();
        Dictionary<string, string> dicGeg;
        string naam;
        string email;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Inlezen_Click(object sender, RoutedEventArgs e)
        {
            InlezenBestand("Email.txt");
        }

        private void InlezenBestand(string bestandsnaam)
        {
            using (StreamReader sr = new StreamReader(bestandsnaam))
            {
                while (!sr.EndOfStream)
                {
                    string[] splitter = sr.ReadLine().Split(',');
                    if (splitter.Length > 1 && !string.IsNullOrEmpty(splitter[1]))
                    {
                        string word = splitter[0].ToString().Trim('\"') + (" : ");
                        sb.Append(word.PadRight(30 - 7));
                        sb.AppendLine(splitter[1].ToString().Trim('\"'));
                    }

                }
                TxtResultaat.Text = sb.ToString();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt ) | *.txt",
                FilterIndex = 2,
                Multiselect = false,
            };

            if (ofd.ShowDialog() == true)
            {
                string path = ofd.FileName;
                InlezenBestand(path);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("Email.txt"))
            {
                dicGeg = new Dictionary<string, string>();
                while (!sr.EndOfStream)
                {
                    string[] splitter = sr.ReadLine().Split(',');
                    if (splitter.Length > 1 && !string.IsNullOrEmpty(splitter[1]))
                    {
                        string word = splitter[0].ToString().Trim('\"') + (" : ");
                        string word2 = splitter[1].ToString().Trim('\"');
                        if (!(word == "")  || (word2 == ""))
                        {
                            dicGeg.Add(word, word2);
                        }

                    }

                }
                foreach(var value in  dicGeg)
                {
                    string joined = value.ToString().Split('[')[1].Split(']')[0];
                    string word1 = joined.Split(',')[0];
                    string word2 = joined.Split(',')[1];
                    TxtResultaat.Text += word1.PadRight(30 - 7) + word2 + Environment.NewLine;
                }
            };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dicGeg.Count == 0)
            {
                MessageBox.Show("Er is niets ingeladen");
            }
            else
            {
                using (StreamWriter sr = new StreamWriter("Adressen.txt"))
                {
                    foreach(var value in dicGeg)
                    {
                        string joined = value.ToString().Split('[')[1].Split(']')[0];
                        string word1 = joined.Split(',')[0];
                        string word2 = joined.Split(',')[1];
                        sr.WriteLine(word1.PadRight(30 - 7) + word2 + Environment.NewLine);
                    }
                }

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dicGeg != null)
            {
                dicGeg.Clear();
            }

            TxtResultaat.Text = string.Empty;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            naam = TxtNaam.Text;
            email = TxtEmail.Text;

            if (dicGeg != null)
            {
                dicGeg.Add(naam, email);
                TxtResultaat.Text += naam.PadRight(30 - 7) + email + Environment.NewLine;
            }
            else
            {
                TxtResultaat.Text += naam.PadRight(30 - 7) + email + Environment.NewLine;
            }
        }
    }
}
