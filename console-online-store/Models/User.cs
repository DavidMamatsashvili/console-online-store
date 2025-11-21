using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public decimal Balance { get; set; }

    public int UserRoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsBanned { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual UserRole UserRole { get; set; } = null!;
}
