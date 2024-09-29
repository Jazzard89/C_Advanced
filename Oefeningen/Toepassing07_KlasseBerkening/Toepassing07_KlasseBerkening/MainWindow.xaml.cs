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

namespace Toepassing07_KlasseBerkening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bankrekening bank = new Bankrekening();

        public MainWindow()
        {
            InitializeComponent();
        }

        void BedragVerhogen(int bedrag)
        {
            bank.Storting(bedrag);
            TxtResultaat.Text = bank.HuidigSaldo.ToString();
        }

        private void BedragVerminderen(int bedrag)
        {
            bank.Opname(bedrag);
            TxtResultaat.Text = bank.HuidigSaldo.ToString();

        }

        private void TxtGetal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int bedrag = int.Parse(TxtGetal.Text);
                if (bedrag > 0)
                {
                    BedragVerhogen(bedrag);
                }
                else
                {
                    BedragVerminderen(Math.Abs(bedrag));
                }
            }
        }
    }
}
