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
using System.Windows.Shapes;
using KingdomSimClassLibrary;


namespace KingdomSimWPF
{
    /// <summary>
    /// Interaction logic for SpelWindow.xaml
    /// </summary>
    public partial class SpelWindow : Window
    {


        public SpelWindow()
        {
            InitializeComponent();
            Speler activeSpeler = new Speler(1, "naam", "wachtwoord");
        }

        private void BtnLaadSpel_Click(object sender, RoutedEventArgs e)
        {
            // Zie 2.2.1
        }

        private void BtnGeschiedenis_Click(object sender, RoutedEventArgs e)
        {
            // Zie 2.2.6
        }


        private void BrdVeld1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Zie 2.2.5
        }

        private void BrdVeld2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Zie 2.2.5
        }

        /// <summary>
        /// Evalueert de dag door de waardes aan te passen van Speler 
        /// op basis van het actieve event en de gemaakte keuze
        /// </summary>
        /// <param name="keuze">1 of 2</param>
        private void VerwerkDagMetKeuze(int keuze)
        {
            // Zie 2.2.4
        }


        /// <summary>
        /// Zie 2.2.3
        /// 
        /// ZetPercentageX(double percentage) verwacht een getal tussen 0 en 100
        /// en past vervolgens de afbeelding aan van X op basis van het percentage.
        /// X kan Piety, Happiness, Military en Economy zijn, de vier waardes van
        /// het Speler object.
        /// </summary>
        /// <param name="percentage">[0,100]</param>
        #region Zet Percentage
        private void ZetPercentagePiety(double percentage)
        {
            percentage = Math.Min(100, percentage);
            ImgValuePiety.Height = Math.Max(ImgMaxPiety.ActualHeight * percentage / 100, 0);
        }

        private void ZetPercentageHappiness(double percentage)
        {
            percentage = Math.Min(100, percentage);
            ImgValueHappiness.Height = Math.Max(ImgMaxHappiness.ActualHeight * percentage / 100, 0);
        }

        private void ZetPercentageMilitary(double percentage)
        {
            percentage = Math.Min(100, percentage);
            ImgValueMilitary.Height = Math.Max(ImgMaxMilitary.ActualHeight * percentage / 100, 0);
        }

        private void ZetPercentageEconomy(double percentage)
        {
            percentage = Math.Min(100, percentage);
            ImgValueEconomy.Height = Math.Max(ImgMaxEconomy.ActualHeight * percentage / 100, 0);
        }
        #endregion

        #region SKELET - NIET NODIG VOOR EXAMEN
        private void Brd_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = Brushes.DarkGray;
            border.Background = Brushes.Ivory;
        }

        private void Brd_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = Brushes.Silver;
            border.Background = Brushes.Beige;
        }
        #endregion
    }
}
