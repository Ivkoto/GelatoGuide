using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Data.Models
{
    public class Buyer
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        [Url]
        public string InstagramUrl { get; set; }

        [Url]
        public string FacebookUrl { get; set; }

        [Phone]
        public int PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Description { get; set; }

        public IEnumerable<ShippingAddress> ShippingAddresses { get; set; }

        public IEquatable<Order> Orders { get; set; }
    }
}
