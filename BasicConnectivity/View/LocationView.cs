using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.View
{
    public class LocationView : GeneralView
    {
        public Dictionary<string, object> GetUserInputForUpdateInsert()
        {
            var columnValues = new Dictionary<string, object>();

            Console.Write("Masukkan ID : ");
            int id = int.Parse(Console.ReadLine());

            // Meminta input Nama dari pengguna
            Console.Write("Masukkan Street Address : ");
            string street = Console.ReadLine();

            // Meminta input
            Console.Write("Masukkan Postal Code : ");
            string postal = Console.ReadLine();

            Console.Write("Masukkan City : ");
            string city = Console.ReadLine();

            Console.Write("Masukkan State Province : ");
            string state = Console.ReadLine();

            Console.Write("Masukkan Country_id : ");
            int country_id = int.Parse(Console.ReadLine());

            columnValues.Add("id", id);
            columnValues.Add("street_address", street);
            columnValues.Add("postal_code", postal);
            columnValues.Add("city", city);
            columnValues.Add("state_province", state);
            columnValues.Add("country_id", country_id);

            return columnValues;
        }

        public int GetIdToDelete()
        {
            Console.Write("Masukkan ID yang akan dihapus: ");
            int.TryParse(Console.ReadLine(), out int id);

            return id;
        }
    }
}
