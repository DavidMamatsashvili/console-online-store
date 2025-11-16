using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class ProductTitle
{
    public int Id { get; set; }

    public string ProductTitle1 { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
