using GelatoGuide.Services.Places.Models;
using System.Collections.Generic;
using GelatoGuide.Models.Places;

namespace GelatoGuide.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(CreatePlaceServiceModel place, string userId);

        //Admin area
        IEnumerable<PlaceServiceModel> GetAllPlaces();

        SearchPlaceViewModel GetAllPlaces(
            string searchTerm, string country, string city,
            int currentPage, int placesPerPage);

        int GetTotalPlacesCount();

        IEnumerable<string> GetAllCities();

        IEnumerable<string> GetAllCountries();
    }
}
