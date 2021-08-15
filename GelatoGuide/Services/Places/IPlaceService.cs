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
        IEnumerable<PlaceServiceModel> AllPlaces();

        SearchPlaceViewModel AllPlaces(
            string searchTerm, string country, string city,
            int currentPage, int placesPerPage);

        Place PlaceById(string id);

        void UpdatePlace(PlaceServiceModel model);
        void DeletePlace(Place place);

        int TotalPlacesCount();

        IEnumerable<string> AllCities();

        IEnumerable<string> AllCountries();
    }
}
