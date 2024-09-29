using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace Pandapark_OrensJasper
{
    /// <summary>
    /// Interaction logic for AllAnimals.xaml
    /// </summary>
    public partial class AllAnimals : Window
    {
        public AllAnimals(string[,] mammalArray)
        {
            InitializeComponent();

            DataTable dataTable = ConvertArrayToDataTable(mammalArray);
            AnimalGrid.ItemsSource = dataTable.DefaultView;
        }

        private DataTable ConvertArrayToDataTable(string[,] array)
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);

            DataTable dataTable = new DataTable();

            // Add column names
            dataTable.Columns.Add("Name:");
            dataTable.Columns.Add("Type:");
            dataTable.Columns.Add("Dangerous:");
            dataTable.Columns.Add("Diet:");
            dataTable.Columns.Add("Gender:");
            dataTable.Columns.Add("Date of Birth:");
            dataTable.Columns.Add("Country:");
            dataTable.Columns.Add("Nest Type:");
            dataTable.Columns.Add("Wingspan:");

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int columnIndex = 1; columnIndex < columnCount; columnIndex++)
                {
                    dataRow[columnIndex - 1] = array[rowIndex, columnIndex];
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }


        private string animals
        {
            get; set;
        }

        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = TextBoxFilter.Text;

            if (AnimalGrid.ItemsSource is DataView dataView)
            {
                foreach (DataGridRow row in GetDataGridRows(AnimalGrid))
                {
                    bool matchFound = false;

                    foreach (DataGridColumn column in AnimalGrid.Columns)
                    {
                        if (column.GetCellContent(row) is TextBlock cellContent)
                        {
                            if (cellContent.Text.Contains(searchText))
                            {
                                matchFound = true;
                                break;
                            }
                        }
                    }

                    row.Visibility = matchFound ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        private IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;

            if (null == itemsSource)
            {
                yield return null;
            }

            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row)
                {
                    yield return row;
                }
            }
        }

    }
}
