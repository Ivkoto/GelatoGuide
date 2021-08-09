using GelatoGuide.Services.Places.Models;
using System.Collections.Generic;

namespace GelatoGuide.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(CreatePlaceServiceModel place);

        IEnumerable<GetPlaceServiceModel> GetAllPlaces();

        IEnumerable<GetPlaceServiceModel> GetAllPlaces(
            string searchTerm, string country, string city,
            int currentPage, int placesPerPage);

        int GetTotalPlacesCount();

        IEnumerable<string> GetAllCities();

        IEnumerable<string> GetAllCountries();
    }
}
