using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class Product
{
    public int Id { get; set; }

    public int ProductTitleId { get; set; }

    public int ManufacturerId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Stock { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; set; } = new List<CustomerOrderDetail>();

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ProductTitle ProductTitle { get; set; } = null!;
}
