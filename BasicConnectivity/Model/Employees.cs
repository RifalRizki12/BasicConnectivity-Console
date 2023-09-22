using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Employees
    {
        //private readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";
        ManageAll manageAll = new ManageAll();
        public static Employees employees = new Employees();

        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public DateTime Hire_Date { get; set; }
        public decimal Salary { get; set; }
        public decimal Commission_Pct { get; set; }
        public int Manager_Id { get; set; }
        public int Department_Id { get; set; }
        public int Job_Id { get; set; }

        public override string ToString()
        {
            return $"{Id} - {First_Name} - {Last_Name} - {Email} - {Phone_Number} - {Hire_Date} - {Salary} - {Commission_Pct} - {Manager_Id} - {Department_Id} - {Job_Id}";
        }

        /*public void GetAllData()
        {
            var EmployeesData = manageAll.GetAllData("tbl_employees");

            foreach (var row in EmployeesData)
            {
                foreach (var column in row)
                {
                    Console.WriteLine($"{column.Key}: {column.Value}");
                }
                Console.WriteLine("------------");
            }
        }*/

        /*public List<Regions> GetAll()
        {
            var regions = new List<Regions>();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_employees";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regions.Add(new Regions
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return regions;
                }
                reader.Close();
                connection.Close();

                return new List<Regions>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Regions>();
        }*/
    }
}
