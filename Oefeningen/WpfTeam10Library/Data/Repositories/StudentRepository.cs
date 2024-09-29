using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeam10Library.Business.Entities;

namespace WpfTeam10Library.Data.Repositories
{
    static class StudentRepository 
    {
        static StudentRepository() 
        {
            StudentList = new List<Student>(); 
        }
        public static List<Student> StudentList { get; set; }
        public static void Add(string firstName, string lastName) 
        { } 
    }
}
