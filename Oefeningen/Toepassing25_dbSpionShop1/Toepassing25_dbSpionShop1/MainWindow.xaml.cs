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
using System.Data.SqlClient;
using System.Data;

namespace Toepassing25_dbSpionShop1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cn = Properties.Settings.Default.CNstr.ToString();
        bool bekeken = true;
        int maxId;



        public MainWindow()
        {
            InitializeComponent();
            ToonData();
        }

        private void GetIndex()
        {
            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();

            string queryString = "select max(klant_id) from klant";
            SqlCommand cmd = new SqlCommand(queryString, sqlcn);

            maxId = (int)cmd.ExecuteScalar();
            MessageBox.Show(maxId.ToString());
        }

        private void ToonData()
        {
            lBox.Items.Clear();

            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();

            if (bekeken == true)
            {
                //controle of state open is door middel van aangemaakte method
                ConnectionCheck(sqlcn);
                bekeken = false;
            }


            string queryString = "select * from klant";
            SqlCommand cmd = new SqlCommand(queryString, sqlcn);

            //Dankzij using wordt de SqlDataReader automatisch gesloten!
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                //SqlDataReader gebruiken we om elke teruggegeven rij (record) te inspecteren
                while (reader.Read())
                {
                    //snelst, let op dat je de juiste types neemt die overeenkomen met SQL server:
                    lBox.Items.Add($"{reader.GetString(1)} {reader.GetString(2)} ( {reader.GetInt32(0)} ) {reader.GetString(3)} \r\n");
                }
            }





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

        private void BntAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //noodzakelijkheden zijn globaal verklaard
                SqlConnection sqlcn = new SqlConnection(cn);
                sqlcn.Open();

                maxId += 1;
                int klantId = maxId;
                string naam = TxtNaam.Text;
                string voorNaam = TxtVoorNaam.Text;
                string woonplaats = TxtWoonplaats.Text;
                string gbDatum = TxtGbDatum.Text;
                string username = TxtUsername.Text;
                string password = TxtPassword.Password.ToString();


                string query =
                    $@"insert into klant(Klant_id, Naam, Voornaam, Woonplaats, Geboortedatum, Gebruikersnaam, Pwd)
                    values ({klantId}, '{naam}', '{voorNaam}', '{woonplaats}', '{gbDatum}', '{username}', '{password}')";

                SqlCommand cmd = new SqlCommand(query, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar command

                sqlcn.Close();

                ToonData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //noodzakelijkheden zijn globaal verklaard
                SqlConnection sqlcn = new SqlConnection(cn);
                sqlcn.Open();

                int gekozenId = Convert.ToInt32(lBox.SelectedIndex) + 1;
                MessageBox.Show(Convert.ToString(gekozenId));
                string naam = TxtNaam.Text;
                string voorNaam = TxtVoorNaam.Text;
                string woonplaats = TxtWoonplaats.Text;
                string gbDatum = TxtGbDatum.Text;
                string username = TxtUsername.Text;
                string password = TxtPassword.Password.ToString();

                string query = $@"update klant set naam = '{naam}', voornaam = '{voorNaam}', woonplaats = '{woonplaats}', geboortedatum = '{gbDatum}', gebruikersnaam = '{username}', Pwd = '{password}' where klant_id = {gekozenId}";

                SqlCommand cmd = new SqlCommand(query, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar command

                sqlcn.Close();

                ToonData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //noodzakelijkheden zijn globaal verklaard
                SqlConnection sqlcn = new SqlConnection(cn);
                sqlcn.Open();

                int gekozenId = Convert.ToInt32(lBox.SelectedIndex) + 1;
                MessageBox.Show(Convert.ToString(gekozenId));
                string naam = TxtNaam.Text;
                string voorNaam = TxtVoorNaam.Text;
                string woonplaats = TxtWoonplaats.Text;
                string gbDatum = TxtGbDatum.Text;
                string username = TxtUsername.Text;
                string password = TxtPassword.Password.ToString();

                string query = $@"delete from klant where klant_id = {gekozenId}";

                SqlCommand cmd = new SqlCommand(query, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar command

                sqlcn.Close();

                ToonData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();
            ConnectionCheck(sqlcn);
        }
    }
}
