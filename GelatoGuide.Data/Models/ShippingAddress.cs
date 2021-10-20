using System;

namespace GelatoGuide.Data.Models
{
    public class ShippingAddress
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Country { get; set; }

        public string City { get; set; }

        public string StreetName { get; set; }

        public int StreetNumber { get; set; }

        public int PostCode { get; set; }

        public string BuyerId { get; set; }

        public Buyer Buyer { get; set; }
    }
}
