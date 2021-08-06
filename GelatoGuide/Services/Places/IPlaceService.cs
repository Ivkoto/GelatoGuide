using GelatoGuide.Services.Places.Models;
using System.Collections.Generic;

namespace GelatoGuide.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(CreatePlaceServiceModel place);

        IEnumerable<AllPlacesServiceModel> GetAllPlaces();

        IEnumerable<AllPlacesServiceModel> GetAllPlaces(
            string searchTerm, string country, string city,
            int currentPage, int placesPerPage);

        IEnumerable<string> GetAllCities();

        IEnumerable<string> GetAllCountries();
    }
}
