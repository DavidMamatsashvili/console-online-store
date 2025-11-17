using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Repository.Implementations
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly StoreDbContext _dbContext;
        public CustomerOrderRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerOrder> CancelOrderByUser(int id)
        {
            CustomerOrder? order = await _dbContext.CustomerOrders.FindAsync(id);
            order.OrderStateId = 3;
            await _dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<CustomerOrder> CancelOrderByAdministrator(int id)
        {
            CustomerOrder? order = await _dbContext.CustomerOrders.FindAsync(id);
            order.OrderStateId = 4;
            await _dbContext.SaveChangesAsync();
            return order;
        }


        public async Task<CustomerOrder> ChangeOrderState(int id, int state)
        {
            CustomerOrder? oldorder = await _dbContext.CustomerOrders.FindAsync(id);
            oldorder.OrderStateId = state;
            await _dbContext.SaveChangesAsync();
            return oldorder;
        }

        public async Task<CustomerOrder> CreateOrder(CustomerOrderDto order)
        {
            CustomerOrder neworder = new CustomerOrder()
            {
                OrderStateId = order.OrderStateId,
                TotalAmount = order.TotalAmount
            };
            _dbContext.CustomerOrders.Add(neworder);
            await _dbContext.SaveChangesAsync();
            return neworder;
        }

        public async Task<CustomerOrder> GetOrderById(int id)
        {
            CustomerOrder? order = await _dbContext.CustomerOrders.FindAsync(id);
            return order;
        }

        public async Task<IEnumerable<CustomerOrder>> GetAllOrders()
        {
            IEnumerable<CustomerOrder> orders = await _dbContext.CustomerOrders.ToListAsync();
            return orders;
        }
    }
}
