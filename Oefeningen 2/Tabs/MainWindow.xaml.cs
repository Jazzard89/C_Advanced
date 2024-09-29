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

namespace Tabs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name;
        string lastname;
        string classname;
        List<Student> students = new List<Student>();
        StringBuilder sb = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();

            if (students.Count > 0 )
            {
                foreach (Student studentX in students)
                {
                    sb.Append(studentX.studentName.ToString());
                    sb.Append(studentX.studentLastName.ToString());
                    sb.AppendLine(studentX.studentClass.ToString());
                }
                TxtShow.Text = "";
                TxtShow.Text = sb.ToString();
            }

        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            name = TxtName.Text;
            lastname = TxtLastName.Text;
            classname = TxtClass.Text;

            Student student = new Student(name, lastname, classname);
            students.Add(student);


        }
    }
}
