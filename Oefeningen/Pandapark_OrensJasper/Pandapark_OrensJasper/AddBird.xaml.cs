using ClassLibrary;
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

namespace Pandapark_OrensJasper
{
    /// <summary>
    /// Interaction logic for AddBird.xaml
    /// </summary>
    public partial class AddBird : Window
    {
        public AddBird()
        {
            InitializeComponent();
        }

        private void AddBird_Click(object sender, RoutedEventArgs e)
        {
            isValidFields();
        }

        public void isValidFields()
        {
            if ((TextBoxName.Text == "") || (TextBoxType.Text == "") || (ComboBoxDiet.SelectedItem == null) || (ComboBoxGender.SelectedItem == null) || (DatePickerBirth.SelectedDate == null) || (ComboBoxNestType.SelectedItem == null) || (TextBoxWingSpan.Text == ""))
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

                if (ComboBoxNestType.SelectedItem == null)
                {
                    MessageBox.Show("Selecteer een nesttype");
                    return;
                }

                if (TextBoxWingSpan.Text == "")
                {
                    MessageBox.Show("Geef een wingspan op");
                    return;
                }
            }
            else
            {
                SaveBird();
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
            ComboBoxNestType.SelectedItem = null;
            TextBoxWingSpan.Text = "";
        }

        public void SaveBird()
        {
            string dietString = ComboBoxDiet.SelectionBoxItem.ToString();
            string genderString = ComboBoxGender.SelectionBoxItem.ToString();
            string nestTypeString = ComboBoxNestType.SelectedItem.ToString();

            Bird bird = new Bird(
                TextBoxName.Text,
                TextBoxType.Text,
                Convert.ToBoolean(CheckBoxDanger.IsChecked),
                dietString,
                genderString,
                DatePickerBirth.SelectedDate.Value,
                TextBoxCountry.Text,
                nestTypeString,
                TextBoxWingSpan.Text
                ); ;

            bird.ToCSV();

            ResetFields();
        }
    }
}
