using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.MenuCore;
using console_online_store.Models;
using console_online_store.Services.Implementations;

namespace console_online_store.Controllers
{
    public class CartController
    {
        public MenuContext _context;
        public CartService _cartService;
        public ProductService _productService;
        public CustomerOrderService _customerOrderService;
        public UserBalanceService _userBalanceService;
        public CartController(MenuContext context, CartService service, ProductService productService, CustomerOrderService customerOrderService, UserBalanceService userBalanceService )
        {
            _context = context;
            _cartService = service;
            _productService = productService;
            _customerOrderService = customerOrderService;
            _userBalanceService = userBalanceService;
        }

        public async Task AddItemInCart()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Enter product id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Product? product = await _productService.GetProductById(id);

            if (product == null)
            {
                Console.WriteLine("product doesnt exists, enter a valid id");
                id = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Cart? cart = await _cartService.GetCartById(_context.UserId);
                if (cart == null)
                {
                    Console.WriteLine("cart doesnt exist");
                    return;
                }
                Cart? added = await _cartService.AddProduct(_context.UserId, product.Id);
                if (added == null)
                {
                    Console.WriteLine("erro occured while adding in cart");
                    return;
                }
                Console.WriteLine("successfully added product in cart");
            }
        }

        public async Task RemoveItemFromCart()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Enter product id:");
            int id = Convert.ToInt32(Console.ReadLine());
            bool exists = await _cartService.CheckIfCartItemExists(_context.UserId, id);
            if (!exists)
            {
                Console.WriteLine("item has been removed from a cart");
                return;
            }

            Cart? cart = await _cartService.RemoveProduct(_context.UserId, id);
            if (cart != null)
            {
                Console.WriteLine("item successfully removed from cart");
            }
            else
            {
                Console.WriteLine("error occured during a process of removing a item from cart");
                return;
            }
        }

        public async Task Payment()
        {
            Console.WriteLine("**********");
            decimal total = await _cartService.GetTotalAmount(_context.UserId);
            Console.WriteLine($"Total Amount:{total}");
            Console.WriteLine("Do you want to pay now? yes/no");
            string? input = Console.ReadLine();
            if(input == "yes")
            {
                decimal balance = await _userBalanceService.GetUserBalance(_context.UserId);
                if (balance < total)
                {
                    Console.WriteLine("not enough money");
                    return;
                }
                else
                {
                    User? user = await _userBalanceService.WithdrawBalance(_context.UserId, total);
                    CustomerOrderDto customerOrderDto = new CustomerOrderDto()
                    {
                        OrderStateId = 1,
                        TotalAmount = total
                    };
                    CustomerOrder? order = await _customerOrderService.CreateCustomerOrder(customerOrderDto);
                    if (order != null)
                    {
                        Console.WriteLine("payment was successful");
                    }
                    else
                    {
                        Console.WriteLine("erro has been during payment");
                        return;
                    }
                }
            }
        }
       
    }
}
