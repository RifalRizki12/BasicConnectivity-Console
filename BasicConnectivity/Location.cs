using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Location
    {
        private readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";
        ManageAll manageAll = new ManageAll();
        public static Location location = new Location();

        public int Id { get; set; }
        public string StreetAdress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public int CountryId { get; set; }

        public override string ToString()
        {
            return $"{Id} - {StreetAdress} - {PostalCode} - {City} - {StateProvince} - {CountryId}";
        }

        public void GetAllData()
        {
            var locationData = manageAll.GetAllData("tbl_locations");

            foreach (var row in locationData)
            {
                foreach (var column in row)
                {
                    Console.WriteLine($"{column.Key}: {column.Value}");
                }
                Console.WriteLine("------------");
            }
        }

        public void Insert(Location location)
        {

            // Membuat objek Dictionary untuk menyimpan data yang ingin dimasukkan ke tabel locations
            var columnValues = new Dictionary<string, object>
            {
                { "id", $"{location.Id}" }, // Ganti "Namalocation" dengan nilai yang sesuai
                { "street_address", $"{location.StreetAdress}" },
                { "postal_code", $"{location.PostalCode}" },
                { "city", $"{location.City}" },
                { "state_province", $"{location.StateProvince}" }, 
                { "country_id", $"{location.CountryId}" } 
            };

            // Memanggil metode Insert untuk memasukkan data ke tabel locations dari kelas ManageAll
            string result = manageAll.Insert("tbl_locations", columnValues);

            // Menampilkan hasil (berhasil atau gagal)
            Console.WriteLine(result);
        }

        public void Update(int id, string newStreet, string newPostal, string newCity, string newState, int countryId)
        {
            var columnValues = new Dictionary<string, object>
            {
                { "street_address", newStreet },
                { "postal_code", newPostal },
                { "city", newCity },
                { "state_province", newState },
                { "country_id", countryId }
            };

            // Menggunakan instance ManageAll yang sudah disimpan untuk memperbarui data
            manageAll.UpdateById(id, "tbl_locations", columnValues);
        }

        public void Search(int id)
        {
            // Membuat delegate untuk membuat objek Country
            Func<Dictionary<string, object>, Location> createLocation = columnValues => new Location
            {
                Id = (int)columnValues["id"],
                StreetAdress = (string)columnValues["street_address"],
                PostalCode = (string)columnValues["postal_code"],
                City = (string)columnValues["city"],
                StateProvince = (string)columnValues["state_province"],
                CountryId = (int)columnValues["country_id"],
            };

            // Menggunakan instance ManageAll untuk mengambil data dari tabel "tbl_countries"
            Location location = manageAll.GetById(id, "tbl_locations", createLocation);

            if (location != null)
            {
                Console.WriteLine($"ID : {location.Id} " +
                    $"\nStreetAddress : {location.StreetAdress} " +
                    $"\nPostalCode : {location.PostalCode} " +
                    $"\nCity : {location.City} " +
                    $"\nStateProvince : {location.StateProvince} " +
                    $"\nCountryId : {location.CountryId}");
            }
            else
            {
                Console.WriteLine("Locations not found.");
            }
        }

        public void Delete(int id)
        {
            // Menggunakan instance ManageAll yang sudah disimpan untuk menghapus data
            manageAll.DeleteById(id, "tbl_locations");
        }
    }
}
