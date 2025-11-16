using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public string UserRoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
