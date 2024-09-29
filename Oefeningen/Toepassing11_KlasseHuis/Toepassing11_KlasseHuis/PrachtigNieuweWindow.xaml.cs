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

namespace Toepassing11_KlasseHuis
{
    /// <summary>
    /// Interaction logic for PrachtigNieuweWindow.xaml
    /// </summary>
    public partial class PrachtigNieuweWindow : Window
    {
        public PrachtigNieuweWindow()
        {
            InitializeComponent();
        }
        private void BtnSmallButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
