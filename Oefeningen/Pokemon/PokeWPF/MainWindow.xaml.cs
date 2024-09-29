using PokemonClassLibrary;
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

namespace PokeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataBewerking.InitializeDataBewerking();
            InitializeComponent();

        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TrainerData.CheckTrainerLogin(TextBoxNaam.Text, PasswordBoxWachtwoord.Password))
            {
                PokemonWindow pokemonWindow = new PokemonWindow(TextBoxNaam.Text);
                pokemonWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Incorrecte logingegevens", 
                    "Je naam of wachtwoord was incorrect",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Exclamation);
            }
            ClearLogin();
        }

        private void NieuweGebruiker_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBoxNaam.Text) 
                && !String.IsNullOrWhiteSpace(PasswordBoxWachtwoord.Password))
            {
                if (TrainerData.CheckUniqueTrainerName(TextBoxNaam.Text))
                {
                    TrainerData.CreateTrainer(TextBoxNaam.Text, PasswordBoxWachtwoord.Password);
                    PokemonWindow pokemonWindow = new PokemonWindow(TextBoxNaam.Text);
                    pokemonWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Naam niet uniek", "De gekozen trainer naam is al in gebruik",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ClearLogin();
            }
        }

        private void ClearLogin()
        {
            TextBoxNaam.Clear();
            PasswordBoxWachtwoord.Clear();
        }
    }
}
