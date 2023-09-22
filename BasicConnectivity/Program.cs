using BasicConnectivity.Controller;
using BasicConnectivity.View;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;

namespace BasicConnectivity;

class Program
{
    public static void Main()
    {
        Menu();
    }

    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("\t Menu: \t");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Manage Regions");
            Console.WriteLine("2. Manage Country");
            Console.WriteLine("3. Manage Locations");
            Console.WriteLine("4. Manage Department");
            Console.WriteLine("5. Manage Employees");
            Console.WriteLine("6. Manage Job");
            Console.WriteLine("7. Manage Job Histori");
            Console.WriteLine("8. Select Join Employees");
            Console.WriteLine("9. Join Employees Kriteria");
            Console.WriteLine("10. Exit");
            Console.Write("\nMasukkan Pilihan : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegionMenu();
                    break;

                case "2":
                    CountryMenu();
                    break;

                case "3":
                    Console.Clear();

                    Console.WriteLine("==========================");
                    Console.WriteLine("\t Menu Locations \t");
                    Console.WriteLine("==========================");
                    ChoiceMenu();
                    Console.Write("\nMasukkan Pilihan : ");
                    string createLocation = Console.ReadLine();

                    switch (createLocation)
                    {
                        case "1":
                            // Meminta input ID dari pengguna
                            Console.Write("Masukkan ID : ");
                            int id = int.Parse(Console.ReadLine());

                            // Meminta input Nama dari pengguna
                            Console.Write("Masukkan Nama Country : ");
                            string name = Console.ReadLine();

                            // Meminta input Regions_id
                            Console.Write("Masukkan Regions_id : ");
                            int regionId = int.Parse(Console.ReadLine());

                            // Membuat objek Regions dengan data yang diperoleh dari pengguna
                            Country country = new Country
                            {
                                Id = id,
                                Name = name,
                                Regions_id = regionId
                            };

                            // Memanggil metode InsertReg untuk memasukkan data ke dalam tabel regions
                            Country.country.Insert(country);
                            // memungkinkan pengguna kembali ke menu utama atau melakukan tindakan lain.
                            Console.WriteLine("Data berhasil dimasukkan. Tekan Enter untuk kembali ke menu utama.");
                            Console.ReadLine();
                            break;
                        case "2":
                            Console.Write("Masukkan Id Countries : ");
                            int.TryParse(Console.ReadLine(), out id);
                            Console.Write("Masukkan Name Countries : ");
                            string countryName = Console.ReadLine();
                            Console.Write("Masukkan regions_Id : ");
                            int.TryParse(Console.ReadLine(), out regionId);

                            Country.country.Update(id, countryName, regionId);
                            break;
                        case "3":
                            ManageAll.manageAll.ShowTableData<Location>("tbl_locations");
                            break;
                        case "4":
                            Console.Write("Masukkan Id country yang dicari : ");
                            int.TryParse(Console.ReadLine(), out id);
                            Country.country.Search(id);
                            break;
                        case "5":
                            Console.Write("Masukkan Id country yang ingin dihapus : ");
                            int.TryParse(Console.ReadLine(), out id);
                            Country.country.Delete(id);
                            break;
                        case "6":
                            break;
                    }
                    Console.WriteLine("\nTekan Enter untuk kembali !!!");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();

                    Console.WriteLine("==========================");
                    Console.WriteLine("\t Menu Department \t");
                    Console.WriteLine("==========================");
                    ChoiceMenu();
                    Console.Write("\nMasukkan Pilihan : ");
                    string createDepartment = Console.ReadLine();

                    switch (createDepartment)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            ManageAll.manageAll.ShowTableData<Department>("tbl_departments");
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                    }
                    Console.WriteLine("\nTekan Enter untuk kembali !!!");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.Clear();

                    Console.WriteLine("==========================");
                    Console.WriteLine("\t Menu Employees \t");
                    Console.WriteLine("==========================");
                    ChoiceMenu();
                    Console.Write("\nMasukkan Pilihan : ");
                    string createEmployees = Console.ReadLine();

                    switch (createEmployees)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            ManageAll.manageAll.ShowTableData<Employees>("tbl_employees");
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                    }
                    Console.WriteLine("\nTekan Enter untuk kembali !!!");
                    Console.ReadLine();
                    break;

                case "6":
                    Console.Clear();

                    Console.WriteLine("==========================");
                    Console.WriteLine("\t Menu Job \t");
                    Console.WriteLine("==========================");
                    ChoiceMenu();
                    Console.Write("\nMasukkan Pilihan : ");
                    string createJob = Console.ReadLine();

                    switch (createJob)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            ManageAll.manageAll.ShowTableData<Job>("tbl_jobs");
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                    }
                    Console.WriteLine("\nTekan Enter untuk kembali !!!");
                    Console.ReadLine();
                    break;

                case "7":
                    Console.Clear();

                    Console.WriteLine("==========================");
                    Console.WriteLine("\t Menu Job Histori \t");
                    Console.WriteLine("==========================");
                    ChoiceMenu();
                    Console.Write("\nMasukkan Pilihan : ");
                    string createHistori = Console.ReadLine();

                    switch (createHistori)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            ManageAll.manageAll.ShowTableData<JobHistori>("tbl_job_history");
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                    }
                    Console.WriteLine("\nTekan Enter untuk kembali !!!");
                    Console.ReadLine();
                    break;

                case "8":
                    ManageAll.manageAll.ShowEmployeeDataWithDetails();
                    
                    Console.WriteLine("\nTekan Enter untuk kembali !!!");
                    Console.ReadLine();
                    break;

                case "9":
                    ManageAll.manageAll.ShowEmployeeKriteria();

                    Console.WriteLine("\nTekan Enter untuk kembali !!!");
                    Console.ReadLine();
                    break;

                case "10":
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public static void ChoiceMenu()
    {
        Console.WriteLine("1. List all regions");
        Console.WriteLine("2. Insert new region");
        Console.WriteLine("3. Update region");
        Console.WriteLine("4. Delete region");
        Console.WriteLine("10. Back");
    }

    public static void RegionMenu()
    {
        // Inisialisasi Model, View, dan Controller
        Regions dataManager = new Regions();
        RegionView view = new RegionView();
        RegionController controller = new RegionController(dataManager, view);

        var isLoop = true;
        while (isLoop)
        {
            Console.Clear();

            Console.WriteLine("==========================");
            Console.WriteLine("\t Menu Regions \t");
            Console.WriteLine("==========================");
            ChoiceMenu();
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    controller.ShowData();
                    break;
                case "2":
                    // Memanggil metode InsertRegion untuk menginsert data ke dalam tabel regions
                    controller.Insert();
                    break;
                case "3":
                    // Memanggil metode UpdateRegion untuk mengupdate data ke dalam tabel regions
                    controller.Update();
                    break;
                case "4":
                    // Memanggil metode DeleteRegion untuk menghapus data dari tabel regions
                    controller.Delete();
                    break;
                case "10":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid choice");
                    break;
            }
            Console.WriteLine("Tekan Enter untuk kembali !!!");
            Console.ReadLine();
        }

    }

    public static void CountryMenu()
    {
        // Inisialisasi Model, View, dan Controller
        Country dataManager = new Country();
        CountryView view = new CountryView();
        CountryController controller = new CountryController(dataManager, view);

        var isLoop = true;
        while (isLoop)
        {
            Console.Clear();

            Console.WriteLine("==========================");
            Console.WriteLine("\t Menu Country \t");
            Console.WriteLine("==========================");
            ChoiceMenu();
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    controller.ShowData();
                    break;
                case "2":
                    // Memanggil metode InsertRegion untuk menginsert data ke dalam tabel regions
                    controller.Insert();
                    break;
                case "3":
                    // Memanggil metode UpdateRegion untuk mengupdate data ke dalam tabel regions
                    controller.Update();
                    break;
                case "4":
                    // Memanggil metode DeleteRegion untuk menghapus data dari tabel regions
                    controller.Delete();
                    break;
                case "10":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid choice");
                    break;
            }
            Console.WriteLine("Tekan Enter untuk kembali !!!");
            Console.ReadLine();
        }

    }



}