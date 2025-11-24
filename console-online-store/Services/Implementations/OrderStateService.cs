using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;

namespace console_online_store.Services.Implementations
{
    public class OrderStateService : IOrderStateService
    {
        private readonly IOrderStateRepository _orderStateRepository;
        public OrderStateService(IOrderStateRepository orderStateRepository)
        {
            _orderStateRepository = orderStateRepository;
        }

        public async Task<OrderState> GetOrderStateByStateId(int id)
        {
            if (id <= 0) return null;
            OrderState? state = await _orderStateRepository.GetOrderStateByStateId(id);
            return state;
        }
    }
}
