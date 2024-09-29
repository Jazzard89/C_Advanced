using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Toepassing23_DatasetMedewerkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet ds = new DataSet("MedewerkersDS");
        DataTable medewerkers = new DataTable("Medewerkers");

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MaakTabellen()
        {
            /* dit gaat ook 
            medewerkers.Columns.Add("Mnr", typeof(int)); */

            DataColumn mMnr = new DataColumn("Mnr", typeof(int));
            DataColumn mNaam = new DataColumn("Naam", typeof(string));
            DataColumn mVoornaam = new DataColumn("Voornaam", typeof(string));
            DataColumn mFunctie = new DataColumn("Functie", typeof(string));
            DataColumn mChef = new DataColumn("Chef", typeof(string));
            DataColumn mGbDatum = new DataColumn("GbDatum", typeof(string));
            DataColumn mMaandsal = new DataColumn("Maandsal", typeof(float));
            DataColumn mComm = new DataColumn("Comm", typeof(float));
            DataColumn mAfd = new DataColumn("Afd", typeof(int));

            //add de koloms
            medewerkers.Columns.Add(mMnr);
            medewerkers.Columns.Add(mNaam);
            medewerkers.Columns.Add(mVoornaam);
            medewerkers.Columns.Add(mFunctie);
            medewerkers.Columns.Add(mChef);
            medewerkers.Columns.Add(mGbDatum);
            medewerkers.Columns.Add(mMaandsal);
            medewerkers.Columns.Add(mComm);
            medewerkers.Columns.Add(mAfd);

            //PrimaryKey
            //DataColumn[] pk = { medewerkers.Columns["mMnr"] };
            //medewerkers.PrimaryKey = pk;
            medewerkers.PrimaryKey = new DataColumn[] { medewerkers.Columns["mnr"] };

            //Constraints, comm en chef mogen null zijn
            //Tabel mag null bevatten
            mChef.AllowDBNull = true;
            mComm.AllowDBNull = true;

            //Dataset in Database zetten
            ds.Tables.Add(medewerkers);
        }

        private void VulTabellen()
        {

            medewerkers.Rows.Add(new object[] { 1, "Palmaers", "Kristof", "TRAINER", "5", new DateTime(1980, 8, 17), 1450.15, 200, 30 });
            medewerkers.Rows.Add(2, "Dox", "Paul", "TRAINER", "4", new DateTime(1972, 3, 17), 1340.15, null, 10);
            medewerkers.Rows.Add(3, "Briers", "Patricia", "DEPARTEMENTSHOOFD", null, new DateTime(1971, 10, 17), 2500, 100, 20);

            DgDatagrid.ItemsSource = medewerkers.DefaultView;
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            MaakTabellen();
            VulTabellen();
        }





        private void BtnMedTabel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt";
            ofd.FilterIndex = 2;
            ofd.FileName = "DatMedewerkers.txt";
            ofd.InitialDirectory = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            {
                //een streamreader in plaats van ReadAllLines had ook gemogen
                string[] inhoud = File.ReadAllLines(ofd.FileName);
                string[] waarden;
                DataRow dr;
                foreach (string lijn in inhoud)
                {
                    waarden = lijn.Split(';');
                    dr = medewerkers.NewRow();

                    dr["Mnr"] = int.Parse(waarden[0]);
                    dr["Naam"] = waarden[1];
                    dr["Voornaam"] = waarden[2];
                    dr["Functie"] = waarden[3];
                    dr["Chef"] = waarden[4];
                    dr["Gbdatum"] = waarden[5];
                    if (float.TryParse(waarden[6], out float msal))
                    {
                        dr["Maandsal"] = msal;
                    }
                    else
                    {
                        //write error log
                    }
                    if (waarden[7] == string.Empty)
                        dr["Comm"] = DBNull.Value; //hier mogen we geen 'null' gebruiken, we gebruiken de waarde van de null
                    else
                        dr["Comm"] = float.Parse(waarden[7]);
                    dr["Afd"] = int.Parse(waarden[8]);
                    medewerkers.Rows.Add(dr);
                }

                DgDatagrid.ItemsSource = medewerkers.DefaultView;
            }



        }
    }
}
