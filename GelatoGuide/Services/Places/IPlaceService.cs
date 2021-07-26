using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Models.Places;

namespace GelatoGuide.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(CreatePlaceFormModel place);

        IEnumerable<ReadPlaceViewModel> ReadAllPlaces();

        IEnumerable<AllPlacesViewModel> GetAllPlaces();
    }
}
