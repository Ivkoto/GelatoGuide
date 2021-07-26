using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Areas.Administration.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(AddPlaceFormModel place);

        IEnumerable<ViewPlaceFormModel> GetAllPlaces();
    }
}
