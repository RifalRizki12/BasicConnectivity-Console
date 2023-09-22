using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Country : ManageAll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Regions_id { get; set; }

        private readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";
        ManageAll manageAll = new ManageAll();
        public static Country country = new Country();

        public override string ToString()
        {
            return $"{Id} - {Name} - {Regions_id}";
        }

        public void GetAllData()
        {
            var countryData = manageAll.GetAllData("tbl_countries");

            foreach (var row in countryData)
            {
                foreach (var column in row)
                {
                    Console.WriteLine($"{column.Key}: {column.Value}");
                }
                Console.WriteLine("------------");
            }
        }

        public void Insert(Country country)
        {

            // Membuat objek Dictionary untuk menyimpan data yang ingin dimasukkan ke tabel countrys
            var columnValues = new Dictionary<string, object>
            {
                { "id", $"{country.Id}" }, // Ganti "Namacountry" dengan nilai yang sesuai
                { "name", $"{country.Name}" }, // Ganti "Namacountry" dengan nilai yang sesuai
                { "regions_id", $"{country.Regions_id}" } // Ganti "Namacountry" dengan nilai yang sesuai
            };

            // Memanggil metode Insert untuk memasukkan data ke tabel countrys dari kelas ManageAll
            string result = manageAll.Insert("tbl_countries", columnValues);

            // Menampilkan hasil (berhasil atau gagal)
            Console.WriteLine(result);
        }

        public void Update(int id, string newName, int newRegions)
        {
            var columnValues = new Dictionary<string, object>
            {
                { "name", newName },
                { "regions_id", newRegions }
            };

            // Menggunakan instance ManageAll yang sudah disimpan untuk memperbarui data
            manageAll.UpdateById(id, "tbl_countries", columnValues);
        }

        public void Search(int id)
        {
            // Membuat delegate untuk membuat objek Country
            Func<Dictionary<string, object>, Country> createCountry = columnValues => new Country
            {
                Id = (int)columnValues["id"],
                Name = (string)columnValues["name"],
                Regions_id = (int)columnValues["regions_id"] // Sesuaikan dengan nama kolom yang benar
            };

            // Menggunakan instance ManageAll untuk mengambil data dari tabel "tbl_countries"
            Country country = manageAll.GetById(id, "tbl_countries", createCountry);

            if (country != null)
            {
                Console.WriteLine($"ID: {country.Id} \nName: {country.Name} \nRegions_id: {country.Regions_id}");
            }
            else
            {
                Console.WriteLine("Country not found.");
            }
        }

        public void Delete(int id)
        {
            // Menggunakan instance ManageAll yang sudah disimpan untuk menghapus data
            manageAll.DeleteById(id, "tbl_countries");
        }

    }
}
