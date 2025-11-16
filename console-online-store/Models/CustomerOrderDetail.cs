using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class CustomerOrderDetail
{
    public int Id { get; set; }

    public int CustomerOrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public int ProductAmount { get; set; }

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
