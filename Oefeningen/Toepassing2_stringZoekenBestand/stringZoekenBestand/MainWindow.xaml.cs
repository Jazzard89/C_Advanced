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

namespace stringZoekenBestand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> allTheContent = new List<string>();

        OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
            FilterIndex = 2,
            Multiselect = true,
            InitialDirectory = Environment.CurrentDirectory
        };


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBladeren_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() == true)
            {
                // open the selected file
                using (StreamReader reader = new StreamReader(ofd.FileName))
                {
                    // read the contents of the file line by line
                    while (!reader.EndOfStream)
                    {
                        allTheContent.Add(reader.ReadLine());
                    }
                }
            }

            //toon geselecteerde map en bestand in txtbestand
            TxtBestand.Text = System.IO.Path.GetDirectoryName(ofd.FileName) + "\\" + System.IO.Path.GetFileName(ofd.FileName);
        }

        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Clear();

            if (ofd.FileName == "")
            {
                throw new ArgumentException("No file selected");
            }
            else
            {
                //zoek String
                string term = TxtString.Text;
                int nummer = 0;

                for (int i = 0; allTheContent.Count > i; i++)
                {
                    if (allTheContent[i].Contains(term))
                    {
                        TxtResultaat.Text += $"{System.IO.Path.GetFileName(ofd.FileName)} regel: {i + 1} - {allTheContent[i]}\n";
                        nummer += 1;
                    }
                }

                TxtResultaat.Text += $"\n{term} gevonden in {nummer} regels (totaal {allTheContent.Count} regels";
            }
        }
    }
}
