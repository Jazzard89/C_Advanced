using System;
using System.Collections.Generic;
using System.Data;
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

namespace Dataset
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ////stap 1
            //DataSet ds = new DataSet();

            ////stap2
            //DataTable dt = new DataTable("stud");

            ///*we gaan kolomn naam meegeven en datatype meegeven
            //stap3*/
            //DataColumn dcStudId = new DataColumn("StudId", typeof(int));
            //DataColumn dcNaam = new DataColumn("Name", typeof(string));
            //DataColumn dcOpleiding = new DataColumn("Opleiding", typeof(string));
            //DataColumn dcGbDatum = new DataColumn("GbDatum", typeof(DateTime));
            //DataColumn dcGeslaagd = new DataColumn();

            ///*op deze manier kunnen we dit ook opvullen
            //we doen dit dus indien we in een method de code willen hergebruiken en anders willen impliceren
            //afhankelijk van welke method we gebruiken bv.*/
            //dcGeslaagd.ColumnName = "Geslaagd";
            //dcGeslaagd.DataType = typeof(bool);

            ///*stap3 ook
            //voeg de datacolumn toe aan de table*/
            //dt.Columns.Add(dcStudId);
            //dt.Columns.Add(dcNaam);
            //dt.Columns.Add(dcOpleiding);
            //dt.Columns.Add(dcGbDatum);
            ///*indien  dcGeslaagd empty is gaan we een default 'typeof()' terug krijgen, dit is een Object
            //dit is dus niet goed als we connect gaan werken met een database gaan we diverse datatypes met elkaar
            //kunnen gaan vergelijken, wat dus problemen gaat geven. dus altijd iets proberen mee te geven */
            //dt.Columns.Add(dcGeslaagd);

            ///* stap4
            //Maak een array aan met alle primary keys voor de DataTable, dit moet een array zijn omdat een PK een tabel is,
            //een tabel heeft meerdere componenten */
            //DataColumn[] pk = { dcStudId };
            ///* verklaar dat de Array de primairy key is,
            // */
            //dt.PrimaryKey = pk;

            ///* stap5
            // Maak constraints aan en voeg die toe aan DataTable */
            //UniqueConstraint unique = new UniqueConstraint(dcNaam);
            //dt.Constraints.Add(unique);

            ////voeg datatable toe aan dataset
            //ds.Tables.Add(dt);

            ///* Alle elementen worden opgesomt zoals we deze boven hebben gedefineerd */
            //dt.Rows.Add(new object[] { "Koen", "Grad Pro", new DateTime(2000,1,1), false, 48.8 });
            ////dt.Rows.Add(pk); //<- een voorbeeld

            //DataRow dr = dt.NewRow();
            //dr[dcNaam] = "Jefke";
            //dr[dcOpleiding] = "Grad Prog";




            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataColumn dcStudId = new DataColumn("StudId", typeof(int));
            DataColumn dcStudName = new DataColumn("Name", typeof(string));
            DataColumn dcOpleiding = new DataColumn("Opleiding", typeof(string));
            DataColumn dcGbDatum = new DataColumn("GbDatum", typeof(DateTime));

            dt.Columns.Add(dcStudId);
            dt.Columns.Add(dcStudName);
            dt.Columns.Add(dcGbDatum);
            dt.Columns.Add(new DataColumn("Telefoon", typeof(string)));

            //primaryKey
            DataColumn[] pk = { dt.Columns["StudId"] };
            dt.PrimaryKey= pk;

            UniqueConstraint unique = new UniqueConstraint(dcStudName);
            dt.Constraints.Add(unique);

            ds.Tables.Add(dt);
            dt.Rows.Add(new object[] { 1, "Kristof Palmaers", new DateTime(1980, 8, 17), "011775100" }); dt.Rows.Add(2, "Paul Dox", new DateTime(1972, 3, 17), "011775101"); dt.Rows.Add(3, "Patricia Briers", new DateTime(1971, 10, 17), "011775102");
            
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("ResultId", typeof(int)));
            dt2.Columns.Add(new DataColumn("StudentId", typeof(int)));
            dt2.Columns.Add(new DataColumn("Graad", typeof(float)));
            ds.Tables.Add(dt2);


            //DataView dv = ds.Tables["Stud"].DefaultView; // of gewoon: = dt.DefaultView;

            ds.Relations.Add("StudentResultaat", dt.Columns["StudId"], dt2.Columns["StudentId"]);

            dt2.Rows.Add(new object[] { 1, 1, 75.3 });
            dt2.Rows.Add(new object[] { 2, 1, 65.8 });
            dt2.Rows.Add(new object[] { 3, 2, 17.1 });

            dt.WriteXml("test.xml");

            DgStud.ItemsSource = dt.DefaultView;
        }
    }
}
