using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Regions
    {
        public static Regions region = new Regions();
        ManageAll manageAll = new ManageAll();

        public int Id { get; set; }
        public string Name { get; set; }

        //private readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";

        //ini method yang dipakai
        public void InsertReg(Regions region)
        {
            
            // Membuat objek Dictionary untuk menyimpan data yang ingin dimasukkan ke tabel regions
            var columnValues = new Dictionary<string, object>
            {
                { "id", $"{region.Id}" }, // Ganti "NamaRegion" dengan nilai yang sesuai
                { "name", $"{region.Name}" } // Ganti "NamaRegion" dengan nilai yang sesuai
            };

            // Memanggil metode Insert untuk memasukkan data ke tabel regions dari kelas ManageAll
            string result = manageAll.Insert("tbl_regions", columnValues);

            // Menampilkan hasil (berhasil atau gagal)
            Console.WriteLine(result);
        }

        /*public void GetAllData()
        {
            manageAll.GetAllData("tbl_regions");
        }*/

        public void Search(int id)
        {
            // Membuat delegate untuk membuat objek Country
            Func<Dictionary<string, object>, Regions> createRegions = columnValues => new Regions
            {
                Id = (int)columnValues["id"],
                Name = (string)columnValues["name"] // Sesuaikan dengan nama kolom yang benar
            };

            // Menggunakan instance ManageAll untuk mengambil data dari tabel "tbl_countries"
            Regions regions = manageAll.GetById(id, "tbl_regions", createRegions);

            if (region != null)
            {
                Console.WriteLine($"ID: {region.Id} \nName: {region.Name}");
            }
            else
            {
                Console.WriteLine("Country not found.");
            }
        }
        public void DeleteRegionById(int id)
        {
            // Menggunakan instance ManageAll yang sudah disimpan untuk menghapus data
            manageAll.DeleteById(id, "tbl_regions");
        }

        public void Update(int id, string newName)
        {
            var columnValues = new Dictionary<string, object>
            {
                { "name", newName }
            };

            // Menggunakan instance ManageAll yang sudah disimpan untuk memperbarui data
            manageAll.UpdateById(id, "tbl_regions", columnValues);
        }
        //sampai disini method yang dipakai


/*
        // GET ALL: Region
        public List<Regions> GetAll()
        {
            var regions = new List<Regions>();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_regions";

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
        }

        // GET BY ID: Region
        public void GetRegionById(int id)
        {
            using var connection = new SqlConnection(connectionString); //deklarasi blok using yang digunakan untuk membuat objek koneksi (SqlConnection) ke database. 
            using var command = new SqlCommand(); //membuat objek perintah (SqlCommand) yang akan digunakan untuk menjalankan query SQL ke database.

            command.Connection = connection; //Menghubungkan objek perintah dengan objek koneksi yang telah dibuat sebelumnya.
            command.CommandText = "SELECT * FROM tbl_regions where id = @id"; //perintah SQL yang akan dieksekusi untuk mengambil data berdasarkan ID dari tabel "regions". Dalam query ini, kita menggunakan parameter bernama @Id
            command.Parameters.AddWithValue("@id", id); //Ini adalah cara kita mengikat nilai parameter @Id dengan nilai yang diberikan dalam parameter method int id. Ini penting untuk mencegah SQL injection.

            try
            {
                connection.Open(); //Membuka koneksi ke database sebelum menjalankan query.
                using var reader = command.ExecuteReader(); //Membuat objek pembaca (SqlDataReader) yang akan digunakan untuk membaca hasil query.

                if (reader.HasRows) //kondisi yang memeriksa apakah hasil query mengandung baris-baris data. Jika ada, kita akan memproses data.
                {
                    while (reader.Read()) //Menggunakan loop while untuk membaca setiap baris data dari hasil query.
                    {
                        int regionId = reader.GetInt32(reader.GetOrdinal("id")); //cara kita mendapatkan nilai kolom "id" dari hasil query, GetOrdinal("id") digunakan untuk mendapatkan indeks kolom berdasarkan namanya.
                        string regionName = reader.GetString(reader.GetOrdinal("Name"));

                        Console.WriteLine("Id: " + regionId);
                        Console.WriteLine("Name: " + regionName);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found for ID: " + id);
                }

                reader.Close(); //Menghentikan pembaca dan menutup koneksi database setelah selesai membaca data.
                connection.Close();
            }
            catch (Exception ex) //Ini adalah blok penanganan kesalahan. Jika terjadi kesalahan selama eksekusi, pesan kesalahan akan dicetak.
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // INSERT: Region
        public string Insert(Regions region)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO regions (id, name) VALUES (@id, @name);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", region.Id));
                command.Parameters.Add(new SqlParameter("@name", region.Name));

                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

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

        public bool ValidateInputName(string name)
        {
            // Validasi panjang name
            if (name.Length > 10)
            {
                return false; //Nama terlalu panjang. Maksimum 25 karakter diizinkan.";
                              // Menghentikan penyimpanan
            }
            return true;
        }

        // UPDATE: Region
        public void UpdateRegion(int id, string name)
        {

            if (ValidateInputName(name) == false)
            {
                Console.WriteLine("inputan tidak valid ");
                return;
            }

            using var connection = new SqlConnection(connectionString);
            connection.Open(); // Buka koneksi

            // Mulai transaksi
            SqlTransaction transaction = connection.BeginTransaction();

            using var command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = "UPDATE tbl_regions SET name = @Name WHERE id = @Id";

                // Parameter
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);

                var result = command.ExecuteNonQuery(); // Jalankan perintah SQL

                transaction.Commit(); // Commit transaksi jika berhasil

                switch (result)
                {
                    case >= 1:
                        Console.WriteLine("Data berhasil diperbarui.");
                        break;
                    default:
                        Console.WriteLine("Insert Failed");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                try
                {
                    transaction.Rollback(); // Rollback transaksi jika terjadi kesalahan
                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine($"Error saat melakukan rollback: {rollbackEx.Message}");
                }
            }
            finally
            {
                connection.Close(); // Tutup koneksi
            }
        }

        // DELETE: Region
        public void DeleteRegion(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open(); // Buka koneksi

            // Mulai transaksi
            SqlTransaction transaction = connection.BeginTransaction();

            using var command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = "DELETE FROM tbl_regions WHERE id = @Id";

                // Parameter
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery(); // Jalankan perintah SQL

                if (rowsAffected > 0)
                {
                    transaction.Commit(); // Commit transaksi jika berhasil
                    Console.WriteLine("Data berhasil dihapus.");
                }
                else
                {
                    transaction.Rollback(); // Rollback jika tidak ada baris yang terpengaruh
                    Console.WriteLine($"Data dengan ID {id} tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                try
                {
                    transaction.Rollback(); // Rollback transaksi jika terjadi kesalahan
                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine($"Error saat melakukan rollback: {rollbackEx.Message}");
                }
            }
            finally
            {
                connection.Close(); // Tutup koneksi
            }
        }*/
    }
}
