namespace BasicConnectivity.View;

public class GeneralView
{
    public void ShowData(List<Dictionary<string, object>> data)
    {
        foreach (var row in data)
        {
            foreach (var column in row)
            {
                Console.WriteLine($"{column.Key}: {column.Value}");
            }
            Console.WriteLine();
        }
    }
}