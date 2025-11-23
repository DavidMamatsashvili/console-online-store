using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using console_online_store.MenuCore;
using console_online_store.Models;
using console_online_store.Repository.Implementations;
using console_online_store.Services.Implementations;

namespace console_online_store.Controllers
{
    public class UserController
    {
        public MenuContext _context;
        public UserBalanceService _userService;
        public UserController(MenuContext context, UserBalanceService service)
        {
            _context = context;
            _userService = service;
        }

        public async Task DepositUserBalance()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Enter amount:");
            decimal deposit = Convert.ToDecimal(Console.ReadLine());
            User user = await _userService.DepositBalance(_context.UserId, deposit);

            if (user != null)
            {
                Console.WriteLine("sucessfully deposited on account");
            }
            else 
            {
                Console.WriteLine("error occured during deposit");
                return;
            }
        }

        public async Task WithdrawUserBalance()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Enter amount:");
            decimal deposit = Convert.ToDecimal(Console.ReadLine());
            User user = await _userService.WithdrawBalance(_context.UserId, deposit);

            if (user != null)
            {
                Console.WriteLine("sucessfully withdrew money from account");
            }
            else
            {
                Console.WriteLine("error occured while withrdarwing money");
                return;
            }
        }
    }
}
