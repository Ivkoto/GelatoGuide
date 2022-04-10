using System;
using System.Collections.Generic;

namespace GelatoGuide.Data.Models;

public class ShippingAddress
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public string Country { get; set; }

    public string City { get; set; }

    public string StreetName { get; set; }

    public int StreetNumber { get; set; }

    public int PostCode { get; set; }

    public string CustomerId { get; set; }

    public Customer Customer { get; set; }

    public IEnumerable<Order> Orders { get; set; }
}