using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Department
    {
        private readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";
        ManageAll manageAll = new ManageAll();
        public static Department department = new Department();

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public int LocationId { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {ManagerId} - {LocationId}";
        }

        /*public void GetAllData()
        {
            var deparmentData = manageAll.GetAllData("tbl_departments");

            foreach (var row in deparmentData)
            {
                foreach (var column in row)
                {
                    Console.WriteLine($"{column.Key}: {column.Value}");
                }
                Console.WriteLine("------------");
            }
        }*/

    }
}
