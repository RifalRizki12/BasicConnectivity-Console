using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class GeneralMenu
    {
        public static void List<T>(List<T> items, string title)
        {
            Console.WriteLine($"List of {title}");
            Console.WriteLine("---------------");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void PrintJoinResult<T>(IEnumerable<T> joinResult)
        {
            var properties = typeof(T).GetProperties();

            foreach (var result in joinResult)
            {
                var lastIndex = properties.Length - 1;

                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    var value = property.GetValue(result);
                    Console.Write(value);

                    if (i < lastIndex) // Tambahkan "-" jika bukan elemen terakhir dalam baris
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine(); // Baris baru setelah mencetak satu baris data
            }
        }

        // menampilkan data dengan nama kolom
        /*public static void PrintJoinResult<T>(IEnumerable<T> joinResult)
        {
            var properties = typeof(T).GetProperties();

            foreach (var result in joinResult)
            {
                //Console.WriteLine("--------------------------------------------------");
                foreach (var property in properties)
                {
                    var value = property.GetValue(result);
                    Console.Write($"{value} - ");
                    //Console.WriteLine($"{property.Name}: {value}");
                }
                Console.WriteLine();
            }
        }*/
    }
}
