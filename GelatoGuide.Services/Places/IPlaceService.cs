using GelatoGuide.Services.Places.Models;
using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Services.Places
{
    public interface IPlaceService
    {
        
        //Admin area
        IEnumerable<PlaceServiceModel> AllPlaces();

        AllPlacesServiceModel AllPlaces(
            string searchTerm, string country, string city,
            int currentPage, int placesPerPage);

        void CreatePlace(PlaceServiceModel place, string userId);

        void UpdatePlace(PlaceServiceModel model);

        void DeletePlace(Place place);

        Place PlaceById(string id);

        int TotalPlacesCount();

        //for searching area
        IEnumerable<string> AllCities();

        IEnumerable<string> AllCountries();
    }
}
