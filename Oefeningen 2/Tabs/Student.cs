using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public class Student
    {
        public string studentName;
        public string studentLastName;
        public string studentClass;

        public Student(string studentNameX, string studentLastNameX, string studentClassX)
        {
            this.studentName = studentNameX;
            this.studentLastName = studentLastNameX;
            this.studentClass = studentClassX;
        }
    }
}
