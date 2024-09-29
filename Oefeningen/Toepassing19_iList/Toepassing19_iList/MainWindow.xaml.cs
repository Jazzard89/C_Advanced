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

namespace Toepassing19_iList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListModule listofModules;
        public MainWindow()
        {
            InitializeComponent();
            listofModules = new ListModule(TxtOutput);
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            listofModules.Add(TxtInput.Text);
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Positie: {listofModules.IndexOf(TxtInput.Text)}");
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            listofModules.Remove(TxtInput.Text);
        }
    }
}
