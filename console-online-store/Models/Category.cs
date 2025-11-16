using System;
using System.Collections.Generic;

namespace console_online_store.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductTitle> ProductTitles { get; set; } = new List<ProductTitle>();
}
