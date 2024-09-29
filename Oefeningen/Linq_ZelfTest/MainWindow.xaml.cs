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

namespace Linq_ZelfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] getallen = new int[20]; // Assuming an array of size 10
        private bool checker = false;
        int newNummer = 0;

        int counter;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int getal1 = int.Parse(TxtGetal.Text);
            if (checker == true)
            {
                getallen[newNummer] = getal1;
            }
            else
            {
                getallen[counter] = getal1;
                counter++;
            }



            LbGetallen.Items.Add(getal1);
            TxtGetal.Text = "";
            TxtGetal.Focus();
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lbResultaat.Items.Clear();


            var linqQuery =
                from g in getallen
                where g == Convert.ToInt32(LbGetallen.SelectedValue)
                select g;

            //List <int> linqQuery =
            //    (from g in getallen
            //    where g == Convert.ToInt32(LbGetallen.SelectedValue)
            //    select g).ToList();

            //var linqQuery = getallen.Where(g => (g == Convert.ToInt32(LbGetallen.SelectedValue)

            getallen[LbGetallen.SelectedIndex] = 0;
            LbGetallen.Items.Remove(linqQuery.FirstOrDefault());
            checker = true;
            newNummer = LbGetallen.SelectedIndex;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LbGetallen.Items.Clear();
            lbResultaat.Items.Clear();

            int [] SorteerQuery =
                (from g in getallen
                orderby g
                select g).ToArray();

            foreach (int getal in SorteerQuery)
            {
                if (getal != 0)
                {
                    LbGetallen.Items.Add(Convert.ToString(getal));
                }

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LbGetallen.Items.Clear();
            lbResultaat.Items.Clear();

            var resultaat =
                from g in getallen
                group g by g % 2 == 0 into evenGroep
                select evenGroep;

            // Voor elke groep in het resultaat
            foreach (var group in resultaat)
            {
                if (group.Key == true)
                {
                    foreach (int getal in group)
                    {
                        if (getal != 0)
                        {
                            LbGetallen.Items.Add(Convert.ToString(getal));
                        }
                    }
                }
                else
                {
                    foreach (int getal in group)
                    {
                        if (getal != 0)
                        {
                            lbResultaat.Items.Add(Convert.ToString(getal));
                        }
                    }
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
