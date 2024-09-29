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

namespace Toepassing20_Hondenras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Hond hond = new Hond("", "", "", CboHond);
        }

        private void BtnOuderdomPersoon_Click(object sender, RoutedEventArgs e)
        {
            Persoon persoon = new Persoon(TxtPersoonVoornaam.Text, TxtPersoonFamilienaam.Text, Convert.ToInt32(TxtPersoonGeboortejaar.Text));
            MessageBox.Show($"Ouderdom: {persoon.Ouderdom}", $"{persoon.Naam}");
        }

        private void BtnOuderdomBoom_Click(object sender, RoutedEventArgs e)
        {
            Boom boom = new Boom(Convert.ToInt32(TxtBoomPlantjaar.Text), TxtBoomSoort.Text);
            MessageBox.Show($"Ouderdom: {boom.Ouderdom}", $"Boom: {boom.Naam}");
        }

        private void BtnOuderdomHond_Click(object sender, RoutedEventArgs e)
        {
            Hond hond = new Hond(TxtHondNaam.Text, TxtHondGeboortejaar.Text, TxtHondGrootte.Text, CboHond);
            MessageBox.Show($"Ouderdom: {hond.Ouderdom}", $"{CboHond.SelectedItem} ({TxtHondGrootte.Text}):{hond.Naam}");
        }

        private void CboHond_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
