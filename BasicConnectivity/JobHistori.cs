using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class JobHistori
    {
        //private readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";
        ManageAll manageAll = new ManageAll();
        public static JobHistori jobHistori = new JobHistori();

        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }

        public override string ToString()
        {
            return $"{EmployeeId} - {StartDate} - {EndDate} - {DepartmentId} - {JobId}";
        }

        public void GetAllData()
        {
            var jobData = manageAll.GetAllData("tbl_job_history");

            foreach (var row in jobData)
            {
                foreach (var column in row)
                {
                    Console.WriteLine($"{column.Key}: {column.Value}");
                }
                Console.WriteLine("------------");
            }
        }


    }
}
