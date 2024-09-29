using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Console
{
    public class Warehouse
    {
        public string BuildingName { get; set; }
        public int WarehouseId { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public double StorageCapacity { get; set; } //in vierkante meter
        public List<int> EmployeeSatisfactionRating { get; set; } //scores van 1 tot 5

        public Warehouse()
        {

        }
        public Warehouse(string buildingName, int warehouseId, string city, int postCode, string street, int houseNumber, double storageCapacity, List<int> employeeSatisfactionRating)
        {
            BuildingName = buildingName;
            WarehouseId = warehouseId;
            City = city;
            PostCode = postCode;
            Street = street;
            HouseNumber = houseNumber;
            StorageCapacity = storageCapacity;
            EmployeeSatisfactionRating = employeeSatisfactionRating;
        }
    }
}
