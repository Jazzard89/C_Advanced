using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwapClassLibrary
{
    public class SkillSwapData
    {
        public static DataSet GetSkillSwapDataSet()
        {
            // Create a new dataset
            DataSet festivalDataset = new DataSet("PXLSkillSwap");

            // Create a DataTable for Category
            DataTable categoryTable = new DataTable("Category");
            categoryTable.Columns.Add("CategoryId", typeof(int));
            categoryTable.Columns.Add("CategoryName", typeof(string));
            categoryTable.PrimaryKey = new DataColumn[] { categoryTable.Columns[0] };

            categoryTable.Rows.Add(1, "Sports");
            categoryTable.Rows.Add(2, "Music");
            categoryTable.Rows.Add(3, "Technology");

            // Create a DataTable for workshops
            DataTable workshopsTable = new DataTable("Workshops");
            workshopsTable.Columns.Add("WorkshopId", typeof(int));
            workshopsTable.Columns.Add("WorkshopName", typeof(string));
            workshopsTable.Columns.Add("CategoryId", typeof(int));
            workshopsTable.Columns.Add("Description", typeof(string));
            workshopsTable.Columns.Add("Time", typeof(DateTime));
            workshopsTable.Columns.Add("Location", typeof(string));
            workshopsTable.PrimaryKey = new DataColumn[] { workshopsTable.Columns[0] };
            workshopsTable.Constraints.Add(
                new ForeignKeyConstraint(
                    categoryTable.Columns[0],
                    workshopsTable.Columns[2]));

            // Add records to sports
            workshopsTable.Rows.Add(1, "Running for beginners", 1, "Learn the basics of running and how to improve your technique", new DateTime(2023, 6, 15, 9, 0, 0), "Building A");
            workshopsTable.Rows.Add(2, "E-sports tournament", 1, "Compete against others in a tournament of popular video games", new DateTime(2023, 6, 16, 13, 0, 0), "Building G");
            workshopsTable.Rows.Add(3, "Indoor rowing", 1,"Try out indoor rowing machines and learn about proper form and technique", new DateTime(2023, 6, 17, 11, 0, 0), "Buildings B");

            // Add records to music
            workshopsTable.Rows.Add(4, "DJ workshop", 2, "Learn how to mix tracks and use DJ equipment like a pro", new DateTime(2023, 6, 15, 14, 0, 0), "Building D");
            workshopsTable.Rows.Add(5, "Live music showcase", 2, "Listen to up-and-coming artists perform live on stage", new DateTime(2023, 6, 16, 18, 0, 0), "Buildings B");
            workshopsTable.Rows.Add(6, "Music production masterclass", 2, "Learn how to create your own music using software like Ableton Live", new DateTime(2023, 6, 17, 15, 0, 0), "Building G");

            // Add records to technologyTable
            workshopsTable.Rows.Add(7, "C# programming basics", 3, "Learn the fundamentals of C# programming language", new DateTime(2023, 6, 15, 10, 0, 0), "Building G");
            workshopsTable.Rows.Add(8, "Software development in the real world", 3, "Hear from professionals about their experiences developing software for various industries", new DateTime(2023, 6, 16, 16, 0, 0), "Building D");
            workshopsTable.Rows.Add(9, "Robotics showcase", 3, "See the latest advancements in robotics technology and meet the creators", new DateTime(2023, 6, 17, 12, 0, 0), "Building B");
            workshopsTable.Rows.Add(10, "Novel drone applications", 3, "Discover new and innovative uses for drones in various industries", new DateTime(2023, 6, 18, 14, 0, 0), "Building A");
            workshopsTable.Rows.Add(11, "Learn to fly a drone", 3, "Get hands-on experience flying a drone and learn about safety regulations", new DateTime(2023, 6, 19, 10, 0, 0), "Building G");

            return festivalDataset;
        }
    }
}
