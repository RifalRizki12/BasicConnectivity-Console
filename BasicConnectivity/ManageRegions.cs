using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class ManageRegions
    {
        /*Regions regions = new Regions();
        public void ShowAll()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("     Daftar Regions");
            Console.WriteLine("==========================\n");
            var getAllRegion = regions.GetAll();

            foreach (Regions get in getAllRegion)
            {
                Console.WriteLine($"ID: {get.Id} " +
                    $"\nNama: {get.Name}\n");
            }
            Console.WriteLine("--------------------------");
        }*/

/*        public void ShowAll<T>(List<T> dataList) where T : class
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"     Daftar {typeof(T).Name}");
            Console.WriteLine("==========================\n");

            foreach (T data in dataList)
            {
                // Menggunakan refleksi untuk mendapatkan properti dari objek
                var properties = typeof(T).GetProperties();

                foreach (var property in properties)
                {
                    Console.WriteLine($"{property.Name}: {property.GetValue(data)}");
                }

                Console.WriteLine();
            }
        }
*/
    }
}
