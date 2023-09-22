using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.View
{
    public class CountryView : GeneralView
    {
        public Dictionary<string, object> GetUserInputForUpdateInsert()
        {
            var columnValues = new Dictionary<string, object>();

            // Meminta input ID dari pengguna
            Console.Write("Masukkan ID : ");
            int.TryParse(Console.ReadLine(), out int id);

            // Meminta input Nama dari pengguna
            Console.Write("Masukkan Nama Country : ");
            string name = Console.ReadLine();

            // Meminta input Regions_id
            Console.Write("Masukkan Regions_id : ");
            int.TryParse(Console.ReadLine(), out int region_id);

            columnValues.Add("id", id);
            columnValues.Add("name", name);
            columnValues.Add("regions_id", region_id);

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
