using GelatoGuide.Services.Places.Models;
using System.Collections.Generic;

namespace GelatoGuide.Services.Places;

public interface IPlaceService
{

    //Admin area
    IEnumerable<PlaceServiceModel> AllPlaces();

    AllPlacesServiceModel AllPlaces(
        string searchTerm, string country, string city,
        int currentPage, int placesPerPage);

    void CreatePlace(PlaceServiceModel place);

    void UpdatePlace(PlaceServiceModel model);

    void DeletePlace(string Id);

    PlaceServiceModel PlaceById(string id);

    bool IsPlaceExist(string id);

    int TotalPlacesCount();

    //searching area
    IEnumerable<string> AllCities();

    IEnumerable<string> AllCountries();

    bool IsPlaceNameExist(string name);
}