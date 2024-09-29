using LeagueClassLibrary.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using LeagueClassLibrary.DataAccess;

namespace LeagueSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   public MainWindow()
        {
            InitializeComponent();
            ComboBoxPositions.Items.Add("sup");
            ComboBoxPositions.Items.Add("mid");
            ComboBoxPositions.Items.Add("bot");
            ComboBoxPositions.Items.Add("jung");
            ComboBoxPositions.Items.Add("top");
        }

        private void LaadChampionDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string csvFilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "csv", "leagueOfLegendsChampions.csv");
                ChampionData.LoadCSV(csvFilePath);
                CheckBoxLaadChamionData.IsChecked = true;
                EnableTabsEnDataGridAlsDataGeladen();

                DataGridChampions.ItemsSource = ChampionData.GetDataViewChampion();
            }
            catch
            {
                MessageBox.Show("incorrecte data");
            }
        }

        private void LaadAbilityDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.csv) |*.csv",
                    FilterIndex = 2, // index start vanaf 1, niet 0 hier! 2 wil zeggen hier filteren op.txt
                    FileName = "leagueOfLegendsAbilities.csv",
                    Multiselect = false, // je kan meerdere bestanden selecteren (true, anders false)
                    InitialDirectory =
                System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "csv") // start in My Documents
                };

                if (ofd.ShowDialog() == true)
                {
                    // volledig pad en bestandsnaam opvragen
                    string csvFilePath = ofd.FileName;

                    AbilityData.LoadCSV(csvFilePath.ToString());
                }









                //ChampionData.LoadCSV(@"\..\csv\leagueOfLegendsAbilities.csv");
                CheckBoxLaadAbilityData.IsChecked = true;
                EnableTabsEnDataGridAlsDataGeladen();


            }
            catch
            {
                MessageBox.Show("incorrecte data");
            }

        }


        private void ComboBoxPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BestToWorstButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DataGridChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void LaadChampion(int indexChampion, int team)
        {
            
        }

        private void ImageIconChampion1Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(0, 1);
        }

        private void ImageIconChampion2Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(1, 1);
        }

        private void ImageIconChampion3Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(2, 1);
        }

        private void ImageIconChampion4Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(3, 1);
        }

        private void ImageIconChampion5Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(4, 1);
        }

        private void ImageIconChampion1Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(0, 2);
        }

        private void ImageIconChampion2Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(1, 2);
        }

        private void ImageIconChampion3Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(2, 2);
        }

        private void ImageIconChampion4Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(3,2);
        }

        private void ImageIconChampion5Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(4, 2);
        }

        private void Genereer5v5Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Genereer3v3Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ExportToXMLButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BeslisWinnaarButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ClearSimulatieTab()
        {
        }

        private void EnableTabsEnDataGridAlsDataGeladen()
        {
            if ((CheckBoxLaadChamionData.IsChecked == true) && (CheckBoxLaadAbilityData.IsChecked == true))
            {
                MatchData.InitializeDataTableMatches();
                TabItemSimuleerMatch.IsEnabled = true;
                TabItemOverzichtMatches.IsEnabled = true;
            }
        }
    }
}
