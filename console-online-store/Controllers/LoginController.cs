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
    public class LoginController
    {
        public MenuContext _context;
        public UserLoginService _userRegistrationService;
        public LoginController(MenuContext context, UserLoginService service)
        {
            _context = context;
            _userRegistrationService = service;
        }

        public async Task UserLogin()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Login:");
            string? login = Console.ReadLine();

            Console.WriteLine("Password:");
            string? password = Console.ReadLine();

            if (login == "admin" && password == "admin")
            {
                _context.State = State.Admin;
                _context.showGuestMenu = false;
                _context.showAdminMenu = true;
                _context.showUserMenu = false;
                _context.UserId = 0;
                Console.Clear();
                return;
            }

            User? user = await _userRegistrationService.LoginUser(login, password);

            if (user.IsBanned)
            {
                Console.WriteLine("User is banned");
                return;
            }

            if (user != null && !user.IsBanned)
            {
                _context.State = State.User;
                _context.UserId = user.Id;
                _context.Login = login;
                _context.showGuestMenu = false;
                _context.showAdminMenu = false;
                _context.showUserMenu = true;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Error has been occured during login");
                return;
            }
        }

        public async Task Logout()
        {
            //_context.showGuestMenu = true;
            //_context.UserId = 0;
            //_context.Login = null;

            _context.State = State.Guest;
            _context.showGuestMenu = true;
            _context.showAdminMenu = false;
            _context.showUserMenu = false;
            _context.UserId = 0;
            Console.Clear();
        }
    }
}
