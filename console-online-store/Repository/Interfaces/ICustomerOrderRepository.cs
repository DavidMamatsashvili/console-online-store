using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Repository.Interfaces
{
    public interface ICustomerOrderRepository
    {
        Task<IEnumerable<CustomerOrder>> GetAllOrders();
        Task<CustomerOrder> GetOrderById(int id);
        Task<CustomerOrder> CreateOrder(CustomerOrderDto order);
        Task<CustomerOrder> CancelOrderByUser(int id);
        Task<CustomerOrder> CancelOrderByAdministrator(int id);
        Task<CustomerOrder> ChangeOrderState(int id, int state);
    }
}
