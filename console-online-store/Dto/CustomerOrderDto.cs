using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_online_store.Dto
{
    public partial class CustomerOrderDto
    {
        public int OrderStateId { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
