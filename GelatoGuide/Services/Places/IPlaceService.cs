using GelatoGuide.Services.Places.Models;
using System.Collections.Generic;
using GelatoGuide.Data.Models;
using GelatoGuide.Models.Places;

namespace GelatoGuide.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(PlaceServiceModel place, string userId);

        //Admin area
        IEnumerable<PlaceServiceModel> GetAllPlaces();

        SearchPlaceViewModel GetAllPlaces(
            string searchTerm, string country, string city,
            int currentPage, int placesPerPage);

        Place GetPlaceById(string id);

        void UpdatePlace(PlaceServiceModel model);
        void DeletePlace(Place place);

        int GetTotalPlacesCount();

        IEnumerable<string> GetAllCities();

        IEnumerable<string> GetAllCountries();
    }
}
