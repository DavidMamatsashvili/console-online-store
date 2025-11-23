using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;

namespace console_online_store.Services.Implementations
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _orderRepository;

        public CustomerOrderService(ICustomerOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<CustomerOrder>> GetAllOrders()
        {
            IEnumerable<CustomerOrder>? customerOrders = await _orderRepository.GetAllOrders();
            return customerOrders;
        }

        public async Task<CustomerOrder> GetCustomerOrderById(int id)
        {
            if (id <= 0) return null;
            CustomerOrder? order = await _orderRepository.GetOrderById(id);
            return order;
        }

        public async Task<CustomerOrder> CreateCustomerOrder(CustomerOrderDto order)
        {
            if (order == null) return null;
            CustomerOrder neworder = await _orderRepository.CreateOrder(order);
            return neworder;
        }

        public async Task<CustomerOrder> ChangeOrderState(int id, int state)
        {
            if (id <= 0 || state > 4 || state <= 0) return null;
            if (!await _orderRepository.CheckIfOrderExists(id)) return null;

            CustomerOrder? order = await _orderRepository.ChangeOrderState(id,state);
            return order;
        }

        public async Task<CustomerOrder> CancelOrderByUser(int id)
        {
            if (id <= 0) return null;
            if (!await _orderRepository.CheckIfOrderExists(id)) return null;

            CustomerOrder? order = await _orderRepository.CancelOrderByUser(id);
            return order;
        }

        public async Task<CustomerOrder> CancelOrderByAdministrator(int id)
        {
            if (id <= 0) return null;
            if (!await _orderRepository.CheckIfOrderExists(id)) return null;

            CustomerOrder? order = await _orderRepository.CancelOrderByAdministrator(id);
            return order;
        }

        public async Task<bool> CheckIfCustomerOrderExist(int id)
        {
            bool exists = await _orderRepository.CheckIfOrderExists(id);
            return exists;
        }

        public async Task<IEnumerable<CustomerOrder>> GetOrdersFromUser(int userid)
        {
            if (userid <= 0) return null;
            IEnumerable<CustomerOrder> orders = await _orderRepository.GetOrdersFromUser(userid);
            return orders;
        }

        public async Task<OrderState> GetOrderState(int id)
        {
            if (id <= 0) return null;
            OrderState state = await _orderRepository.GetOrderState(id);
            return state;
        }
        public async Task<IEnumerable<OrderState>> GetStates()
        {
            return await _orderRepository.GetStates();
        }
    }
}
