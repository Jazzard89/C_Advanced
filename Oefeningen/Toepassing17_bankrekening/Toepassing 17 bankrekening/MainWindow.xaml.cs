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

namespace Toepassing_17_bankrekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Spaarrekening spaarrekening;
        Zichtrekening zichtrekening;
        public MainWindow()
        {
            InitializeComponent();
            spaarrekening = new Spaarrekening(100, "Bob", "Bobland");
            zichtrekening = new Zichtrekening(100, "Bob", "Bobland");
            TxtSRInfo.Content = $"{spaarrekening.Naam} - {spaarrekening.Adres} - Spaarrekening";
            TxtZRInfo.Content = $"{zichtrekening.Naam} - {zichtrekening.Adres} - Zichtrekening";
            SRSaldo.Content = $"{spaarrekening.CreditSaldo(0)}";
            ZRSaldo.Content = $"{zichtrekening.CreditSaldo(0)}";
        }

        private void BtnSaldo_Click(object sender, RoutedEventArgs e)
        {
            double transactie = Convert.ToDouble(TxtBedrag.Text);
            
            
            spaarrekening.HuidigSaldo = spaarrekening.CreditSaldo(transactie);
            zichtrekening.HuidigSaldo = zichtrekening.CreditSaldo(transactie);
            SRSaldo.Content = $"{spaarrekening.HuidigSaldo}";
            ZRSaldo.Content = $"{zichtrekening.HuidigSaldo}";
        }

        private void BtnRente_Click(object sender, RoutedEventArgs e)
        {
            SRRente.Content = $"{spaarrekening.BerekenRente()}";
            ZRRente.Content = $"{zichtrekening.BerekenRente()}";
        }

        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
