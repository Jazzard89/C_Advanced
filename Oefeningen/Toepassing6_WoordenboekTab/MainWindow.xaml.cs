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

namespace LogIn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string connStr = LogIn.Properties.Settings.Default.MO_con_str; //dit staat in de settings
            SqlConnection sqlConn = new SqlConnection(connStr);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;

            /////////////////////////////////////
            //sqlCmd.CommandText = $"select * from UserInfo where username = '{TxtUser.Text}' and passwd = '{TxtPassword.Text}'";

            //or

            sqlCmd.CommandText = $"select * from UserInfo where username = @naam and passwd = @wachtwoord";
            sqlCmd.Parameters.AddWithValue("@naam", TxtUser.Text);
            sqlCmd.Parameters.AddWithValue("@wachtwoord", TxtPassword.Text);
            /////////////////////////////////////

            sqlConn.Open();
            SqlDataReader rdr = sqlCmd.ExecuteReader();
            if (rdr.HasRows)
            {
                MessageBox.Show("u bent ingelogd!"); //let op met text -> ' or 1=1 -- <-- dit is Sql injection, hier kan dan drop tables bij
            }
            else
            {
                MessageBox.Show("Authenticatie gefaald!");
            }
            sqlConn.Close();
        }

        private void BtnLogin_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
