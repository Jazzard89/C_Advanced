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
using System.Windows.Shapes;

namespace Toepassing101_DeMolDisconnected
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
        }



        public ProfileWindow(int spelerId)
        {
            InitializeComponent();
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



            LbNaam.Content = MaakTabellen.dtSpelers.Rows[spelerId][2].ToString();
            LbLeeftijd.Content = MaakTabellen.dtSpelers.Rows[spelerId][5].ToString();
            LbBeroep.Content = MaakTabellen.dtSpelers.Rows[spelerId][6].ToString();
            //MaakTabellen.dtSpelers.Rows[spelerId][1] == MaakTabellen.dtSpellen.Rows[1]
            LbLocatie.Content = MaakTabellen.dtSpellen.Rows[Convert.ToInt32(MaakTabellen.dtSpelers.Rows[spelerId][1])][2].ToString();
            LbJaar.Content = MaakTabellen.dtSpellen.Rows[Convert.ToInt32(MaakTabellen.dtSpelers.Rows[spelerId][1])][1].ToString();
        }
    }
}
