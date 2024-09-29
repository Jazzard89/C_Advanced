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

namespace Toepassing100_DeMolConnected
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        string connectionString = Properties.Settings.Default.Cnstr.ToString();
        int spelerid;


        public ProfileWindow(int spelerId)
        {
            InitializeComponent();
            SqlCommandOphalen();

            spelerid = spelerId;
            string hexColor = "";
            BitmapImage bitmapImage = new BitmapImage();

            if (Convert.ToInt32(MaakTabellen.dtSpelers.Rows[spelerId][4]) == 1)
            {
                MessageBox.Show("is de mol");

                hexColor = "#e0371d";
                // Create a new BitmapImage object with the URI of the image file
                bitmapImage = new BitmapImage(new Uri("DeMolRed.jpg", UriKind.Relative));
            }
            else
            {
                hexColor = "#61f1f1";
                // Create a new BitmapImage object with the URI of the image file
                bitmapImage = new BitmapImage(new Uri("DeMol.jpg", UriKind.Relative));
            }
            var bc = new BrushConverter();
            ImLogo.Source = bitmapImage;

            LbNaam.Foreground = (Brush)bc.ConvertFrom(hexColor);
            LbBeroep.Foreground = (Brush)bc.ConvertFrom(hexColor);
            LbJaar.Foreground = (Brush)bc.ConvertFrom(hexColor);
            LbLeeftijd.Foreground = (Brush)bc.ConvertFrom(hexColor);
            LbLocatie.Foreground = (Brush)bc.ConvertFrom(hexColor);
        }

        public void SqlCommandOphalen()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = $"select * from spelers where spelerid = {spelerid}";

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(MaakTabellen.dtSpelers);


            int spelId = Convert.ToInt32(MaakTabellen.dtSpelers.Rows[0][1]);

            sqlCommand.CommandText = $"select * from spellen where spel_id = {spelId}";

            SqlDataAdapter da2 = new SqlDataAdapter(sqlCommand);
            da2.Fill(MaakTabellen.dtSpellen);


            sqlConnection.Open();

            LbNaam.Content = MaakTabellen.dtSpelers.Rows[0][2];
            LbLeeftijd.Content = MaakTabellen.dtSpelers.Rows[0][5];
            LbBeroep.Content = MaakTabellen.dtSpelers.Rows[0][4];

            LbLocatie.Content = MaakTabellen.dtSpellen.Rows[0]["locatie"];
            LbJaar.Content = MaakTabellen.dtSpellen.Rows[0][1];


            sqlConnection.Close();
        }
    }
}
