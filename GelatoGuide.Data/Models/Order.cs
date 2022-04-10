using GelatoGuide.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Data.Models;

public class Order
{
    [Key]
    public string Id { get; init; } = Guid.NewGuid().ToString();

    [Required]
    public long OrderNumber { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }

    public string CustomerId { get; set; }

    public Customer Customer { get; set; }

    public IEnumerable<ShopItem> Items { get; set; }

    public string ShippingAddressId { get; set; }

    public ShippingAddress ShippingAddress { get; set; }

    public string Description { get; set; }

    public IEnumerable<Image> DescriptionImages { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateFinished { get; set; }

    public DateTime DeliveryDate { get; set; }

    public OrderStatusEnum Status { get; set; }

    public decimal TotalPrice { get; set; }
}