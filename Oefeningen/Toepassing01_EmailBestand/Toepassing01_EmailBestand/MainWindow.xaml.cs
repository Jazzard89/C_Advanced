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

namespace Toepassing01_EmailBestand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> dicGeg = new Dictionary<string, string>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void InlezenBestand(string path)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] waarden = sr.ReadLine().Split(',');

                    if (waarden[0] != "")
                    {
                        sb.AppendLine($"{waarden[0].Trim('"'),-20} : {waarden[1].Trim('"')} ");
                        //als we deze aligned willen hebben gebruiken we consolas als font, gezien hier
                        //elk character even lang is
                    }
                }
                TxtResultaat.Text = Convert.ToString(sb);
            };
        }

        private void Inlezen_Click(object sender, RoutedEventArgs e)
        {
            InlezenBestand("email.txt");
        }

        private void Inlezen_Dialoogvenster_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2, // index start vanaf 1, niet 0 hier! 2 wil zeggen hier filteren op.txt
                FileName = "email.txt",
                Multiselect = true, // je kan meerdere bestanden selecteren (true, anders false)
                InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) // start in My Documents
            };

            if (ofd.ShowDialog() == true)
            {
                // volledig pad en bestandsnaam opvragen
                string padEnBestandsnaam = ofd.FileName;

                InlezenBestand(padEnBestandsnaam.ToString());
            }



        }

        private void Inlezen_Dictionary_Click(object sender, RoutedEventArgs e)
        {
            dicGeg.Clear();
            StreamReader sr = new StreamReader("Email.txt");
            while (!sr.EndOfStream)
            {
                string[] waarden = sr.ReadLine().Split(',');

                if (waarden[0] != "")
                {
                    dicGeg.Add($"{waarden[0].Trim('"'),-20}", $"{waarden[1].Trim('"'),-20}");
                }

            }
            sr.Close();
            foreach (var item in dicGeg)
            {
                TxtResultaat.Text += ($"{item.Key}: {item.Value}\n");
            }
        }

        private void Wegschrijven_Dictionary_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("adressen.txt"))
            {
                foreach (var item in dicGeg)
                {
                    sw.WriteLine($"{item.Key} : {item.Value}");
                }
            }
        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string naam = TxtNaam.Text;
                string email = TxtEmail.Text;

                if (string.IsNullOrEmpty(naam) || string.IsNullOrEmpty(email))
                {
                    throw new Exception("Velden moeten ingevuld worden.");
                }

                if (!(email.Contains("@") && email.Contains(".")))
                {
                    throw new Exception("Email niet correct ingevuld.");
                }

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                    FilterIndex = 2,
                    FileName = "Email.txt",
                    Multiselect = false,
                    InitialDirectory = Environment.CurrentDirectory,
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    using (StreamWriter streamWriter = new StreamWriter(openFileDialog.FileName))
                    {
                        streamWriter.WriteLine($"\"{naam}\", : \"{email}\"");
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
