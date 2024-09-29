using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeam10Library.Business.Entities;
using WpfTeam10Library.Data.Repositories;

namespace WpfTeam10Library.Business
{
    public static class students
    {
        public static IEnumerable<Student> List()
        {
            return StudentRepository.StudentList;
        }

        public static void Add(string firstName, string lastName) 
        {
            StudentRepository.Add(firstName, lastName); 
        }
    }
}
