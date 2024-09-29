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
using System.IO;

namespace Oefening_ReadWrite_Namen
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

        private void BtnLeesBestand_Click(object sender, RoutedEventArgs e)
        {
            string pad = "namen.txt";
            FileInfo fi = new FileInfo(pad);

            if (fi.Exists)
            {
                using (StreamReader sr = fi.OpenText())
                {
                    while (!sr.EndOfStream)
                    {
                        string lijn = sr.ReadLine();
                        
                        LbVoornaam.Items.Add(lijn.Split(',')[0].Trim());
                        LbAchternaam.Items.Add(lijn.Split(',')[1].Trim());
                    }
                }
            }
        }

        private void BtnOpslaanBestand_Click(object sender, RoutedEventArgs e)
        {
            string pad = "namen.txt";
            FileInfo fi = new FileInfo(pad);

            if (!fi.Exists) // controleer of bestand nog niet bestaat
            {
                // maak StreamWriter en maak bestand aan
                using (StreamWriter sw = fi.CreateText())
                {

                    // schrijf tekst naar bestand
                    for (int i = 0; i < LbVoornaam.Items.Count; i++)
                    {
                        sw.WriteLine($"{LbVoornaam.Items[i]},{LbAchternaam.Items[i]};");
                    }
                }
            }
        }

        private void BtnVoegToe_Click(object sender, RoutedEventArgs e)
        {
            if ((TxtVoornaam != null) || (TxtAchternaam != null))
            {
                LbVoornaam.Items.Add(TxtVoornaam.Text);
                LbAchternaam.Items.Add(TxtAchternaam.Text);
                TxtVoornaam.Text = "";
                TxtAchternaam.Text = "";
            }
        }
    }
}

