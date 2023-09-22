using BasicConnectivity.View;
namespace BasicConnectivity.Controller;

public class RegionController
{
    private Regions _region;
    private RegionView _regionView;
    HandlerController handler = new HandlerController();

    public RegionController(Regions region, RegionView regionView)
    {
        _region = region;
        _regionView = regionView;
    }

    public void ShowData()
    {
        var regionData = _region.GetAllData("tbl_regions");
        _regionView.ShowData(regionData);
    }

    public void Update()
    {
        var values = _regionView.GetUserInputForInsertUpdate();
        int idValue = Convert.ToInt32(values["id"]);

        if (idValue < 0)
        {
            Console.WriteLine($"\nNo data found with ID {idValue}.");            
        }
        else
        {
            if (handler.ValidateInput(values))
            {
                Console.WriteLine($"\nData with ID {idValue} has been updated.");
                _region.UpdateById(idValue, "tbl_regions", values);
            }
        }
    }

    public void Insert()
    {
        var columnValues = _regionView.GetUserInputForInsertUpdate();

        if (handler.ValidateInput(columnValues))
        {
            _region.Insert("tbl_regions",columnValues);

            _regionView.ShowMessage($"\nData has been inserted.");
        }
    }

    public void Delete()
    {
        int idToDelete = _regionView.GetIdToDelete();

        if (idToDelete <= 0)
        {
            Console.WriteLine($"\nNo data found with ID {idToDelete}.");
        }
        else
        {
            _region.DeleteById(idToDelete, "tbl_regions");
            Console.WriteLine($"\nData with ID {idToDelete} has been deleted.");
        }
    }
}