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
using System.Windows.Shapes;
using Transportmiddelen.Properties;

namespace Transportmiddelen
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public bool loginOk = false;
        public bool isChecked = false;
        public string UserName = "";

        public void LoginSucces()
        {
            DialogResult = true;
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            Annuleren();
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Annuleren();
            }
        }

        private void Annuleren()
        {
            DialogResult = false;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNString.ToString();

            if (TxtUserName.Text == "")
            {
                MessageBox.Show("Vul een naam in");
            }
            if (PwPassword.Password == "")
            {
                MessageBox.Show("Vul een wachtwoord in");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection(cn);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandText = $"select * from Gebruikers where Naam = @naam and WachtWoord = @wachtwoord";
                    sqlCommand.Parameters.AddWithValue("@naam", TxtUserName.Text);
                    sqlCommand.Parameters.AddWithValue("@wachtwoord", PwPassword.Password.ToString());


                SqlDataReader rdr = sqlCommand.ExecuteReader();
                if (rdr.Read())
                {
                    rdr.GetString(0);
                    rdr.GetString(1);
                    UserName = rdr.GetString(0);
                    loginOk = true;
                    isChecked = true;
                    MainWindow mainwindow = new MainWindow(UserName);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data fail!");
                    isChecked = true;
                }
                sqlConnection.Close();
            }
        }
    }
}
