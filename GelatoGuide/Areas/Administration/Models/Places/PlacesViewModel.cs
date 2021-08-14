using System;

namespace GelatoGuide.Areas.Administration.Models.Places
{
    public class PlacesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int SinceYear { get; set; }
        public string WebsiteLink { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
 