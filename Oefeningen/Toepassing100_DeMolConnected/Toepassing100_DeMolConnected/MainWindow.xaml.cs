using System;
using System.Collections.Generic;
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

namespace Toepassing100_DeMolConnected
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //static verhinderd dat we meerdere klasses moeten maken
        bool rbSQL;
        string cn = Properties.Settings.Default.Cnstr.ToString();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HaalTabellenuitDatabase(rbSQL);
        }

        private void RbSql_Checked(object sender, RoutedEventArgs e)
        {
            if (RbSql.IsChecked == true)
            {
                rbSQL = true;
            }
            else
            {
                rbSQL = false;
            }
        }

        public void HaalTabellenuitDatabase(bool rbSQL)
        {
            if (TxtNaam.Text == "")
            {
                MessageBox.Show("Vul een naam in");
            }
            if (TxtWachtwoord.Password == "")
            {
                MessageBox.Show("Vul een wachtwoord in");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection(cn);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                if (rbSQL != true)
                {
                    //indien de radiobutton geslecteerd is geven werken we zonder parameters en is sqlinjection mogelijk
                    sqlCommand.CommandText = $"select * from spelers where naam = '{TxtNaam.Text}' and wachtwoord = '{TxtWachtwoord.Password.ToString()}'";
                }
                else
                {
                    sqlCommand.CommandText = $"select * from spelers where username = @naam and passwd = @wachtwoord";
                    sqlCommand.Parameters.AddWithValue("@naam", TxtNaam.Text);
                    sqlCommand.Parameters.AddWithValue("@wachtwoord", TxtWachtwoord.Password.ToString());
                }


                SqlDataReader rdr = sqlCommand.ExecuteReader();
                if (rdr.Read())
                {
                    rdr.GetInt32(0);
                    rdr.GetInt32(1);
                    rdr.GetString(2);
                    rdr.GetString(3);
                    rdr.GetBoolean(4);
                    rdr.GetInt32(5);
                    rdr.GetString(6);

                    MessageBox.Show("Data opgehaald"); //let op met text -> ' or 1=1 -- <-- dit is Sql injection, hier kan dan drop tables bij


                    ProfileWindow profileW = new ProfileWindow(rdr.GetInt32(0));
                    profileW.Show();
                }
                else
                {
                    MessageBox.Show("Data fail!");
                }
                sqlConnection.Close();
            }
        }



        private void ZetKleur(string kleur)
        {
            //die de tekst in het
            //profielvenster van kleur verandert
        }

        private void GetSpel()
        {
            // die het spel van de speler ophaalt
            //uit de “database”.
        }

        private void BitmapVerander()
        {
            //bitmap image weizigen van image
        }
    }
}
