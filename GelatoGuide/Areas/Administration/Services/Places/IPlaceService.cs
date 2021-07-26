using GelatoGuide.Areas.Administration.Models.Places;
using System.Collections.Generic;

namespace GelatoGuide.Areas.Administration.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(AddPlaceFormModel place);

        IEnumerable<ViewPlaceFormModel> GetAllPlaces();
    }
}
