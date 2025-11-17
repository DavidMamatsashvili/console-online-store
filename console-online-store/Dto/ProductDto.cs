using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;

namespace console_online_store.Dto
{
    public partial class ProductDto
    {
        public decimal UnitPrice { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }
    }
}
