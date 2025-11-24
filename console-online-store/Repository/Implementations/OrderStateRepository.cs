using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;

namespace console_online_store.Repository.Implementations
{
    public class OrderStateRepository : IOrderStateRepository
    {
        private readonly StoreDbContext _dbContext;
        public OrderStateRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderState> GetOrderStateByStateId(int orderId)
        {
            OrderState? state = await _dbContext.OrderStates.FindAsync(orderId);
            return state;
        }
    }
}
