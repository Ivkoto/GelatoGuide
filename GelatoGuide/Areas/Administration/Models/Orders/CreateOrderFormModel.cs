using GelatoGuide.Data.Enums;
using GelatoGuide.Data.Models;
using System;
using System.Collections.Generic;

namespace GelatoGuide.Areas.Administration.Models.Orders;

public class CreateOrderFormModel
{
    public long OrderNumber { get; set; }

    public string UserId { get; set; }

    public Customer Customer { get; set; }

    public IEnumerable<ShopItem> Items { get; set; }

    public ShippingAddress ShippingAddress { get; set; }

    public string Description { get; set; }

    public IEnumerable<Image> DescriptionImages { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateFinished { get; set; }

    public DateTime DeliveryDate { get; set; }

    public OrderStatusEnum Status { get; set; }
}