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
using ClassLibrary;

namespace Pandapark_OrensJasper
{
    /// <summary>
    /// Interaction logic for AddMammal.xaml
    /// </summary>
    public partial class AddMammal : Window
    {
        public AddMammal()
        {
            InitializeComponent();
        }

        private void AddMammal_Click(object sender, RoutedEventArgs e)
        {
            isValidFields();
        }

        public void isValidFields()
        {
            if ((TextBoxName.Text == "") || (TextBoxType.Text == "") || (ComboBoxDiet.SelectedItem == null) || (ComboBoxGender.SelectedItem == null) || (DatePickerBirth.SelectedDate == null))
            {
                if (TextBoxName.Text == "")
                {
                    MessageBox.Show("Geef een naam in!");
                    return;
                }

                if (TextBoxType.Text == "")
                {
                    MessageBox.Show("Geef een type in!");
                    return;
                }

                if (ComboBoxDiet.SelectedItem == null)
                {
                    MessageBox.Show("Geef een Diet op");
                    return;
                }

                if (ComboBoxGender.SelectedItem == null)
                {
                    MessageBox.Show("Geef een Gender op");
                    return;
                }

                if (DatePickerBirth.SelectedDate == null)
                {
                    MessageBox.Show("Selecteer een geboortedatum");
                    return;
                }
            }
            else
            {
                SaveMammal();
            }
        }

        public void ResetFields()
        {
            TextBoxName.Text = "";
            TextBoxType.Text = "";
            CheckBoxDanger.IsChecked = false;
            ComboBoxDiet.SelectedItem = null;
            ComboBoxGender.SelectedItem = null;
            DatePickerBirth.SelectedDate = null;
            TextBoxCountry.Text = "";
        }

        public void SaveMammal()
        {
            string dietString = ComboBoxDiet.SelectionBoxItem.ToString();
            string genderString = ComboBoxGender.SelectionBoxItem.ToString();

            Mammal mam = new Mammal(
                TextBoxName.Text,
                TextBoxType.Text,
                Convert.ToBoolean(CheckBoxDanger.IsChecked),
                dietString,
                genderString,
                DatePickerBirth.SelectedDate.Value,
                TextBoxCountry.Text
                ); ;

            mam.ToCSV();

            ResetFields();
        }
    }
}
