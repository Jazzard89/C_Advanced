using Pandapark_OrensJasper.Properties;
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
using ClassLibrary;
using ppSettings = Pandapark_OrensJasper.Properties.Settings;
using clSettings = ClassLibrary.Settings;
using System.IO;

namespace Pandapark_OrensJasper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string csvFile = clSettings.AnimalCSV(); //als static class kan deze geen instance aanmaken
        string[,] mammalArray = new string[18, 8];
        string[,] birdArray = new string[16, 10];
        string[,] animals = new string[34,10];

        public MainWindow()
        {
            InitializeComponent();
            ReadCSV();
        }

        private void AddBird_Click(object sender, RoutedEventArgs e)
        {
            AddBird addBird = new AddBird();
            addBird.ShowDialog();
        }

        private void AddMammal_Click(object sender, RoutedEventArgs e)
        {
            ReadCSV();
            AddMammal addMammal = new AddMammal();
            addMammal.ShowDialog();
        }

        private void AllAnimals_Click(object sender, RoutedEventArgs e)
        {
            AllAnimals allAnimals = new AllAnimals(animals);
            allAnimals.ShowDialog();
        }

        public void DescribeAnimal()
        {

        }

        public void DescribeBirdWingS()
        {

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        public void ReadCSV()
        {
            mammalArray = new string[18, 8];
            birdArray = new string[16, 10];
            animals = new string[34, 10];


            using (StreamReader sr = new StreamReader(csvFile))
            {
                int regelA = 0;
                int regelM = 0;
                int regelB = 0;
                while (!sr.EndOfStream)
                {
                    string[] waarden = sr.ReadLine().Split(';');

                    if (waarden[0] != "")
                    {
                        if (waarden[0] == "M")
                        {
                            animals[regelA, 1] = waarden[1];
                            animals[regelA, 2] = waarden[2];
                            animals[regelA, 3] = waarden[3];
                            animals[regelA, 4] = waarden[4];
                            animals[regelA, 5] = waarden[5];
                            animals[regelA, 6] = waarden[6];
                            animals[regelA, 7] = waarden[7];

                            mammalArray[regelM, 1] = waarden[1];
                            mammalArray[regelM, 2] = waarden[2];
                            mammalArray[regelM, 3] = waarden[3];
                            mammalArray[regelM, 4] = waarden[4];
                            mammalArray[regelM, 5] = waarden[5];
                            mammalArray[regelM, 6] = waarden[6];
                            mammalArray[regelM, 7] = waarden[7];
                            regelM++;
                        }
                        else
                        {
                            animals[regelA, 1] = waarden[1];
                            animals[regelA, 2] = waarden[2];
                            animals[regelA, 3] = waarden[3];
                            animals[regelA, 4] = waarden[4];
                            animals[regelA, 5] = waarden[5];
                            animals[regelA, 6] = waarden[6];
                            animals[regelA, 7] = waarden[7];
                            animals[regelA, 8] = waarden[8];
                            animals[regelA, 9] = waarden[9];

                            birdArray[regelB, 1] = waarden[1];
                            birdArray[regelB, 2] = waarden[2];
                            birdArray[regelB, 3] = waarden[3];
                            birdArray[regelB, 4] = waarden[4];
                            birdArray[regelB, 5] = waarden[5];
                            birdArray[regelB, 6] = waarden[6];
                            birdArray[regelB, 7] = waarden[7];
                            birdArray[regelB, 8] = waarden[8];
                            birdArray[regelB, 9] = waarden[9];
                            regelB++;
                        }
                        regelA++;
                    }
                }
            }
        }

        private void Zoek_Click(object sender, RoutedEventArgs e)
        {
            ReadCSV();
            bool found = false;

            for (int i = 0; i < mammalArray.GetLength(0); i++)
            {
                if (TextBoxZoek.Text.ToLower() == mammalArray[i, 1].ToLower())
                {
                    MessageBox.Show("Animal found!");
                    Mammal mammal = new Mammal(TextBoxZoek.Text);
                    string describe = mammal.Describe();
                    TextBlockBeschrijving.Text = describe;
                    found = true;
                    break;
                }
            }
            for (int i = 0; i < birdArray.GetLength(0); i++)
            {
                if (TextBoxZoek.Text.ToLower() == birdArray[i, 1].ToLower())
                {
                    MessageBox.Show("Bird found!");
                    Bird bird = new Bird(TextBoxZoek.Text);
                    string describe = bird.Describe();
                    TextBlockBeschrijving.Text = "animal found";
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Animal not found.");
            }
        }
    }
}
