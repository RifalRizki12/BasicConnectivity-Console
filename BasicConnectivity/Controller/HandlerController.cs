using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controller
{
    public class HandlerController
    {
        public bool ValidateInput<T>(Dictionary<string, T> inputValues)
        {
            foreach (var keyValue in inputValues)
            {
                if (keyValue.Value == null || (keyValue.Value is string stringValue && string.IsNullOrWhiteSpace(stringValue)))
                {
                    Console.WriteLine($"\nInput {keyValue.Key} tidak valid. Pastikan semua kolom diisi!");
                    return false;
                }
                // Tambahkan validasi untuk angka <= 0
                if (keyValue.Value is int intValue && intValue <= 0)
                {
                    Console.WriteLine($"\nInput {keyValue.Key} tidak valid. Harap masukkan angka yang lebih besar dari 0.");
                    return false;
                }
            }
            return true;
        }

        public int GetValidIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Input tidak valid. Harap masukkan angka.");
                }
            }
        }

        public string GetValidStringInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Input tidak valid. Harap masukkan teks yang valid.");
                }
            }
        }

    }
}
