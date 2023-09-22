using BasicConnectivity.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controller
{
    public class CountryController
    {
        private Country _country;
        private CountryView _countryView;
        HandlerController handler = new HandlerController();

        public CountryController(Country country, CountryView countryView)
        {
            _country = country;
            _countryView = countryView;
        }

        public void ShowData()
        {
            var countryData = _country.GetAllData("tbl_countries");
            _countryView.ShowData(countryData);
        }

        public void Update()
        {
            var values = _countryView.GetUserInputForUpdateInsert();
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
                    _country.UpdateById(idValue, "tbl_countries", values);
                }
            }
        }

        public void Insert()
        {
            var columnValues = _countryView.GetUserInputForUpdateInsert();

            if (handler.ValidateInput(columnValues))
            {
                _country.Insert("tbl_countries", columnValues);

                Console.WriteLine($"\nData has been inserted.");
            }
        }

        public void Delete()
        {
            int idToDelete = _countryView.GetIdToDelete();

            if (idToDelete <= 0)
            {
                Console.WriteLine($"\nNo data found with ID {idToDelete}.");
            }
            else
            {
                _country.DeleteById(idToDelete, "tbl_countries");
                Console.WriteLine($"\nData with ID {idToDelete} has been deleted.");
            }
        }
    }
}
