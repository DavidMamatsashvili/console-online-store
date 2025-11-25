using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.MenuCore;
using console_online_store.Models;
using console_online_store.Services.Implementations;

namespace console_online_store.Controllers
{
    public class OrderController
    {
        public MenuContext _context;
        public CustomerOrderService _customerOrderService;
        public OrderStateService _orderStateService;
        public OrderController(MenuContext context, CustomerOrderService customerOrderService, OrderStateService orderStateService)
        {
            _context = context;
            _customerOrderService = customerOrderService;
            _orderStateService = orderStateService;
        }

        public async Task ShowOrders()
        {
            Console.WriteLine("**********");
            Console.WriteLine("User orders:");
            IEnumerable<CustomerOrder>? orders = await _customerOrderService.GetAllOrders();
            foreach (CustomerOrder order in orders)
            {
                OrderState state = await _customerOrderService.GetOrderState(order.OrderStateId);
                Console.WriteLine($"Order id:{order.Id}. Operation Time:{order.OperationTime}, Order State:{state.StateName}, Total Amount:{order.TotalAmount}");
            }
        }

        public async Task ChangeOrderByUser()
        {
            Console.WriteLine("**********");
            IEnumerable<OrderState> states = await _customerOrderService.GetStates();
            foreach (OrderState state in states)
            {
                Console.WriteLine($"Id:{state.Id}, State Name{state.StateName}");
            }

            Console.WriteLine("Enter order id:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter state id:");
            int stateid = Convert.ToInt32(Console.ReadLine());
            CustomerOrder order = await _customerOrderService.ChangeOrderState(id, stateid);
            if (order != null)
            {
                Console.WriteLine("State successefully changed");
            }
            else
            {
                Console.WriteLine("error has been occured during changing order states");
                return;
            }
        }
        public async Task ChangeOrderByAdministrator()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Enter order id to be changed");
            int orderid = Convert.ToInt32(Console.ReadLine());

            IEnumerable<OrderState> states = await _customerOrderService.GetStates();
            foreach (OrderState state in states)
            {
                Console.WriteLine($"Id:{state.Id}, State Name : {state.StateName}");
            }

            Console.WriteLine("Enter order state id");
            int orderstateid = Convert.ToInt32(Console.ReadLine());

            CustomerOrder order = await _customerOrderService.ChangeOrderState(orderid, orderstateid);
            if (order != null)
            {
                Console.WriteLine("order state id sucessfully changed by administrator");
            }
            else
            {
                Console.WriteLine("error has been occured during changing order state id");
                return;
            }
        }

        public async Task GetOrdersByUserId()
        {
            Console.WriteLine("Order history:");
            IEnumerable<CustomerOrder> orders = await _customerOrderService.GetOrdersFromUser(_context.UserId);
            foreach (CustomerOrder order in orders)
            {
                int id = order.OrderStateId;
                OrderState state = await _orderStateService.GetOrderStateByStateId(id);
                Console.WriteLine($"{order.Id}. state:{state.StateName} Total Amount:{order.TotalAmount} Time:{order.OperationTime}");
            }
        }
    }
}
