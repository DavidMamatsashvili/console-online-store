using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class CustomerOrder
{
    public int Id { get; set; }

    public DateTime OperationTime { get; set; }

    public int CustomerId { get; set; }

    public int OrderStateId { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; set; } = new List<CustomerOrderDetail>();

    public virtual OrderState OrderState { get; set; } = null!;
}
