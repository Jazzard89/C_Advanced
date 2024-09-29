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

namespace Toepassing21_iBankrekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IBankrekening> accounts;
        public MainWindow()
        {
            InitializeComponent();
            accounts = new List<IBankrekening>();
            accounts.Add(new Bankrekening("Bob Kees", 7777, 100));

        }


        private void BtnBerekenSaldo_Click(object sender, RoutedEventArgs e)
        {
            string InsertedNaam = TxtNaam.Text;
            int InsertedNr = Convert.ToInt32(TxtRekeningNummer.Text);
            double InsertedMoney = Convert.ToDouble(TxtStorting.Text);
            bool AccountExists = false;
            int accountIndex = 7777;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Rekeningnummer == InsertedNr)
                {
                    AccountExists = true;
                    accountIndex = i;

                }

            }
            if (AccountExists == false)
            {
                accounts.Add(new Bankrekening(InsertedNaam, InsertedNr, InsertedMoney));
                TxtSaldo.Text = (accounts[(accounts.Count) - 1].Saldo).ToString();

            }

            if (AccountExists && accounts[accountIndex].Naam == InsertedNaam)
            {
                if (InsertedMoney > 0)
                {
                    accounts[accountIndex].Storting(InsertedMoney);
                    TxtSaldo.Text = (accounts[accountIndex].Saldo).ToString();
                }
                else if (InsertedMoney < 0)
                {
                    accounts[accountIndex].Opname(InsertedMoney);
                    TxtSaldo.Text = (accounts[accountIndex].Saldo).ToString();
                }
                else
                {
                    TxtSaldo.Text = (accounts[accountIndex].Saldo).ToString();

                }





            }
        }

        private void TxtStorting_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
