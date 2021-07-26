using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Places;

namespace GelatoGuide.Services.Places
{
    public interface IPlaceService
    {
        void CreatePlace(AdminAddPlaceFormModel place);

        IEnumerable<AdminViewPlaceFormModel> GetAllPlaces();
    }
}
