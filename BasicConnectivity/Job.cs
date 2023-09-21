using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Job
    {
        private readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";
        ManageAll manageAll = new ManageAll();
        public static Job job = new Job();

        public int Id { get; set; }
        public string Job_Title { get; set; }
        public decimal Min_Salary { get; set; }
        public decimal Max_Salary { get; set; }

        /*public void GetAllData()
        {
            var jobData = manageAll.GetAllData("tbl_jobs");

            foreach (var row in jobData)
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
