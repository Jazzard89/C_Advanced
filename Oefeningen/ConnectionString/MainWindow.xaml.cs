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

namespace ConnectionString
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        //Haal de ConnectionString uit de settings file
        string cn;
        SqlConnection sqlcn;

        public MainWindow()
        {
            InitializeComponent();
            //in Settings.settings plaatsen we de correcte data //Save
            //Dan kijken we in de App.config of alles in orde is
            //onderstaande code in ButtonX zorgt dat we connection opvragen

            //Haal de ConnectionString uit de settings file
            cn = Properties.Settings.Default.CNstr.ToString();
            sqlcn = new SqlConnection(cn);
        }

        private void buttonX_Click(object sender, RoutedEventArgs e)
        {
            sqlcn.Open();

            if (sqlcn.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("De connection is open.");
            }
            else
            {
                MessageBox.Show("De connection is NIET open");
            }
        }
        private void buttonY_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNstr.ToString();
            SqlConnection sqlcn = new SqlConnection(cn);
            //SqlConnection sqlcn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;User ID="";Initial Catalog=DB_Team10;Data Source=5CG21505WF\SQLEXPRESS;");
            string query = "select * from factions";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcn; // connection doorgeven aan commando
            cmd.CommandType = CommandType.Text; // we zeggen: commando staat in tekstformaat
            cmd.CommandText = query; // comando tekst is de query
            TxtResultaat.Text = cmd.CommandText;
            sqlcn.Open();
            //Dankzij using wordt de SqlDataReader automatisch afgesloten
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                //SqlDatareader gebruiken we om elke teruggeven rij (recordd) te inspecteren
                while (reader.Read())
                {
                    //Snelst, let op dat je de jiuste types neemt die overeenkomen met sql server:
                    //TxtResultaat.AppendText($"{reader.GetInt16(0)} {reader.GetString(1)} \r \n ");
                    // of trager
                    TxtResultaat.AppendText($"{reader[0]} {reader[1]}\r \n");
                }
            }
            sqlcn.Close();
        }
        private void buttonZ_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlcn = new SqlConnection(cn)) 
            {
                sqlcn.Open();
                string query = "select max(factionId) from factions";
                SqlCommand cmd = new SqlCommand(query, sqlcn);
                // short van C# komt overeen met smallint in sqL server
                //maar neem toch maar int
                int maxMed = (int)cmd.ExecuteScalar();
                TxtResultaat.Text = $"{maxMed}";
            }
        }
    }
}
