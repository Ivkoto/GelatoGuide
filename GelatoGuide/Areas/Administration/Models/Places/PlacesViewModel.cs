using System;

namespace GelatoGuide.Areas.Administration.Models.Places
{
    public class PlacesViewModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public int SinceYear { get; init; }
        public string WebsiteLink { get; init; }
        public string Country { get; init; }
        public string City { get; init; }

        public string Address { get; init; }
        public DateTime DateCreated { get; init; }
    }
}
 