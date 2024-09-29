using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Toepassing27_dbSpionshop3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cn = Properties.Settings.Default.CNstr.ToString();
        bool bekeken = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectionCheck(SqlConnection sqlcn)
        {
            if (sqlcn.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("De connection is open.");
            }
            else
            {
                MessageBox.Show("De connection is NIET open");
            }
        }

        private void TxtWoonplaats_TextChanged(object sender, TextChangedEventArgs e)
        {
            string inputText = TxtWoonplaats.Text.ToString();




            LbResultaat.Items.Clear();

            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();

            if (bekeken == true)
            {
                //controle of state open is door middel van aangemaakte method
                ConnectionCheck(sqlcn);
                bekeken = false;
            }

            string queryString = $"select Klant_id, Naam, Voornaam from klant where Woonplaats like '{inputText}%'";
            SqlCommand cmd = new SqlCommand(queryString, sqlcn);

            //Dankzij using wordt de SqlDataReader automatisch gesloten!
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                //SqlDataReader gebruiken we om elke teruggegeven rij (record) te inspecteren
                while (reader.Read())
                {
                    //snelst, let op dat je de juiste types neemt die overeenkomen met SQL server:
                    LbResultaat.Items.Add($"{reader.GetString(1)} {reader.GetString(2)} ( {reader.GetInt32(0)} )\r\n");
                }
            }

        }

        private void LbResultaat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LstCategorie.SelectedItem = LstCategorie.Items[2];
            //HandleLstCategorieSelection();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            HandleLstCategorieSelection();
        }

        private void HandleLstCategorieSelection()
        {
            int numberSend;
            if (LstCategorie.SelectedIndex > -1)
            {
                switch (LstCategorie.SelectedIndex)
                {
                    case 0:
                        numberSend = 1;
                        GetDataGridInfo(numberSend);
                        break;
                    case 1:
                        numberSend = 2;
                        GetDataGridInfo(numberSend);

                        break;
                    case 2:
                        numberSend = 3;
                        GetDataGridInfo(numberSend);
   
                        break;
                    default:
                        // Handle default case
                        break;
                }
            }
        }

        private void GetDataGridInfo(int number)
        {
            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();

            string queryString = $"select Artikel, Omschrijving, verkoopprijs from Artikel where Cat_id={number}";
            SqlCommand cmd = new SqlCommand(queryString, sqlcn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                DgdArtikel.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
