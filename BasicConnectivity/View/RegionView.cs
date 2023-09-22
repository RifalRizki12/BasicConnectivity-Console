namespace BasicConnectivity.View;

public class RegionView : GeneralView
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public Dictionary<string, object> GetUserInputForUpdate()
    {
        var columnValues = new Dictionary<string, object>();

        Console.Write("Masukkan ID : ");
        int.TryParse(Console.ReadLine(), out int id);

        Console.Write("Masukkan Nama Regions : ");
        string name = Console.ReadLine();

        columnValues.Add("id", id);
        columnValues.Add("name", name);

        return columnValues;
    }

    public Dictionary<string, object> GetUserInputForInsert()
    {
        var columnValues = new Dictionary<string, object>();

        Console.Write("Masukkan ID: ");
        int.TryParse(Console.ReadLine(), out int id);

        Console.Write("Masukkan Nama Regions: ");
        string name = Console.ReadLine();

        columnValues.Add("id", id);
        columnValues.Add("name", name);

        return columnValues;
    }

    public int GetIdToDelete()
    {
        Console.Write("Masukkan ID yang akan dihapus: ");
        int.TryParse(Console.ReadLine(), out int id);

        return id;
    }
}