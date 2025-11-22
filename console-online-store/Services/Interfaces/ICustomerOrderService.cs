using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Services.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<IEnumerable<CustomerOrder>> GetAllOrders();
        Task<CustomerOrder> GetCustomerOrderById(int id);
        Task<CustomerOrder> CreateCustomerOrder(CustomerOrderDto order);
        Task<CustomerOrder> ChangeOrderState(int id, int state);
        Task<CustomerOrder> CancelOrderByUser(int id);
        Task<CustomerOrder> CancelOrderByAdministrator(int id);
        Task<bool> CheckIfCustomerOrderExist(int id);
    }
}
