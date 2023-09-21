using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class ManageAll
    {
        public static ManageAll manageAll = new ManageAll();

        // Method untuk mengambil semua data dari tabel dalam database SQL Server
        public List<Dictionary<string, object>> GetAllData(string tableName)
        {
            // List untuk menyimpan data hasil query
            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();

            // Membuat koneksi ke database SQL Server
            using var connection = Provider.GetConnection();
            // Membuat objek perintah SQL
            using var command = Provider.GetCommand();

            // Menghubungkan perintah SQL dengan koneksi
            command.Connection = connection;
            // Menentukan teks perintah SQL dengan parameter tabel yang dinamis
            command.CommandText = $"SELECT * FROM {tableName}";

            try
            {
                // Membuka koneksi ke database
                connection.Open();

                // Mengeksekusi perintah SQL dan membaca hasil query
                using var reader = command.ExecuteReader();

                // Membaca setiap baris hasil query
                while (reader.Read())
                {
                    // Membuat Dictionary untuk merepresentasikan satu baris data
                    var dataRow = new Dictionary<string, object>();

                    // Membaca setiap kolom hasil query
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // Mendapatkan nama kolom
                        var columnName = reader.GetName(i);
                        // Mendapatkan nilai kolom
                        var value = reader.GetValue(i);

                        // Menambahkan nama kolom dan nilainya ke dalam Dictionary
                        dataRow[columnName] = value;
                    }

                    // Menambahkan data satu baris ke dalam list
                    dataList.Add(dataRow);
                }

                // Menutup objek SqlDataReader dan koneksi
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                // Menangkap dan menampilkan pesan error jika terjadi kesalahan
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Mengembalikan list data hasil query
            return dataList;
        }

        public void ShowTableData<T>(string tableName) // cara simple menampilkan data method generic
        {
            var tableData = GetAllData(tableName);

            foreach (var row in tableData)
            {
                foreach (var column in row)
                {
                    Console.WriteLine($"{column.Key}: {column.Value}");
                }
                Console.WriteLine();
            }
        }

        public string Insert(string tableName, Dictionary<string, object> columnValues)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;

            // Membuat string SQL untuk menentukan tabel dan kolom
            string columns = string.Join(", ", columnValues.Keys);
            string values = string.Join(", ", columnValues.Keys.Select(key => "@" + key));

            command.CommandText = $"INSERT INTO {tableName} ({columns}) VALUES ({values});";

            try
            {
                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    // Menambahkan parameter dinamis sesuai dengan objek kolom dan nilainya
                    foreach (var column in columnValues)
                    {
                        command.Parameters.Add(new SqlParameter("@" + column.Key, column.Value));
                    }

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public T GetById<T>(int id, string tableName, Func<Dictionary<string, object>, T> createObject)
        {
            using (var connection = Provider.GetConnection())
            using (var command = Provider.GetCommand())
            {
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM {tableName} WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var columnValues = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var columnName = reader.GetName(i);
                                var value = reader.GetValue(i);
                                columnValues[columnName] = value;
                            }

                            return createObject(columnValues);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                return default(T);
            }
        }

        public void DeleteById(int id, string tableName)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = $"DELETE FROM {tableName} WHERE id = @Id";

            command.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Data with ID {id} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"No data found with ID {id}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateById(int id, string tableName, Dictionary<string, object> columnValues)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;

            // Membuat string SQL untuk menentukan tabel dan kolom
            var updateColumns = string.Join(", ", columnValues.Keys.Select(key => $"{key} = @{key}"));

            command.CommandText = $"UPDATE {tableName} SET {updateColumns} WHERE id = @Id";

            command.Parameters.AddWithValue("@Id", id);

            // Menambahkan parameter dinamis sesuai dengan objek kolom dan nilainya
            foreach (var column in columnValues)
            {
                command.Parameters.AddWithValue($"@{column.Key}", column.Value);
            }

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Data with ID {id} has been updated.");
                }
                else
                {
                    Console.WriteLine($"No data found with ID {id}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //implementasi lineQ
        public void ShowEmployeeDataWithDetails()
        {
            // Mengambil data employees
            var employeesData = GetAllData("tbl_employees");
            var departmentData = GetAllData("tbl_departments");
            var locationData = GetAllData("tbl_locations");
            var countryData = GetAllData("tbl_countries");
            var regionData = GetAllData("tbl_regions");

            // join untuk mendapatkan data dari berbagai tabel relasi
            var resultJoin = (from e in employeesData
                              join d in departmentData on e["department_id"] equals d["id"]
                              join l in locationData on d["location_id"] equals l["id"]
                              join c in countryData on l["country_id"] equals c["id"]
                              join r in regionData on c["regions_id"] equals r["id"]
                              select new
                              {
                                  Id = e["id"],
                                  Full_Name = $"{e["first_name"]} {e["last_name"]}",
                                  Email = e["email"],
                                  Phone = e["phone_number"],
                                  Salary = e["salary"],
                                  Department_Name = d["name"],
                                  Street_Address = l["street_address"],
                                  Country_Name = c["name"],
                                  Region_Name = r["name"]
                              }).ToList();

            GeneralMenu.PrintJoinResult(resultJoin);

            // Sekarang Anda memiliki hasil join dalam variabel resultJoin

        }

        public void ShowEmployeeKriteria()
        {
            var employeesData = GetAllData("tbl_employees");
            var departmentData = GetAllData("tbl_departments");

            var result = (from e in employeesData
                              join d in departmentData on e["department_id"].ToString() equals d["id"].ToString()
                              group new { e, d } by new
                              {
                                  DepartmentName = d["name"].ToString(),
                              } into grouped
                              where grouped.Count() > 3
                              select new
                              {
                                  Department_Name = grouped.Key.DepartmentName,
                                  Total_Employee = grouped.Count(),
                                  Min_Salary = grouped.Min(x => decimal.Parse(x.e["salary"].ToString())),
                                  Max_Salary = grouped.Max(x => decimal.Parse(x.e["salary"].ToString())),
                                  Average_Salary = grouped.Average(x => decimal.Parse(x.e["salary"].ToString()))
                              }).ToList();

            GeneralMenu.PrintJoinResult(result);

        }
    }

}
