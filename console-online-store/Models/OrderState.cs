using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class OrderState
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();
}
