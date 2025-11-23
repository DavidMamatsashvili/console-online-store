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
    public class BanController
    {
        public MenuContext _context;
        public UserService _userService;
       
        public BanController(MenuContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task BanUser()
        {
            Console.WriteLine("********");
            Console.WriteLine("Enter user id to ban:");
            int id = Convert.ToInt32(Console.ReadLine());

            User? user = await _userService.BanUser(id);
            if (user != null)
            {
                Console.WriteLine("successfully banned user");
            }
            else
            {
                Console.WriteLine("error has been occured while banning a user");
                return;
            }
        }
        public async Task UnbanUser()
        {
            Console.WriteLine("********");
            Console.WriteLine("Enter user id to unban:");
            int id = Convert.ToInt32(Console.ReadLine());

            User? user = await _userService.UnbanUser(id);
            if (user != null)
            {
                Console.WriteLine("successfully unbanned user");
            }
            else
            {
                Console.WriteLine("error has been occured while unbanning a user");
                return;
            }
        }
    }
}
