using BasicConnectivity.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controller
{
    public class LocationController : ManageAll
    {
        private Location _location;
        private LocationView _locationView;
        HandlerController handler = new HandlerController();

        public LocationController(Location location, LocationView locationView)
        {
            _location = location;
            _locationView = locationView;
        }

        public void ShowData()
        {
            var locationData = _location.GetAllData("tbl_locations");
            _locationView.ShowData(locationData);
        }

        public void Update()
        {
            var values = _locationView.GetUserInputForUpdateInsert();
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
                    _location.UpdateById(idValue, "tbl_locations", values);
                }
            }
        }

        public void Insert()
        {
            var columnValues = _locationView.GetUserInputForUpdateInsert();

            if (handler.ValidateInput(columnValues))
            {
                _location.Insert("tbl_locations", columnValues);

                Console.WriteLine($"\nData has been inserted.");
            }
        }

        public void Delete()
        {
            int idToDelete = _locationView.GetIdToDelete();

            if (idToDelete <= 0)
            {
                Console.WriteLine($"\nNo data found with ID {idToDelete}.");
            }
            else
            {
                _location.DeleteById(idToDelete, "tbl_locations");
                Console.WriteLine($"\nData with ID {idToDelete} has been deleted.");
            }
        }
    }
}
