using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Console
{
    internal class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int WarehouseId { get; set; }

        public Employee(string firstName, string lastName, int iD, int warehouseId) 
        {
            FirstName = firstName;
            LastName = lastName;
            ID = iD;
            WarehouseId = warehouseId;
        }
    }
}
