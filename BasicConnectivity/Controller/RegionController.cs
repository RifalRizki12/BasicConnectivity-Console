using BasicConnectivity.View;
namespace BasicConnectivity.Controller;

public class RegionController
{
    private Regions _region;
    private RegionView _regionView;

    public RegionController(Regions region, RegionView regionView)
    {
        _region = region;
        _regionView = regionView;
    }

    public RegionController(ManageAll dataManager, GeneralView view)
    {
    }

    public void ShowRegionData()
    {
        var regionData = _region.GetAllData("tbl_regions");
        _regionView.ShowData(regionData);
    } 
}