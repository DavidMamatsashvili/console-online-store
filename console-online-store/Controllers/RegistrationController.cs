using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.MenuCore;
using console_online_store.Models;
using console_online_store.Services.Implementations;
using Microsoft.Identity.Client;

namespace console_online_store.Controllers
{
    public class RegistrationController
    {
        public MenuContext _context;
        public UserRegistrationService _userRegistrationService;
        public UserLoginService _userLoginService;
        public CartService _cartService;
        public RegistrationController(MenuContext context, UserRegistrationService registrationservice, UserLoginService loginservice, CartService cartService)
        {
            _context = context;
            _userRegistrationService = registrationservice;
            _userLoginService = loginservice;
            _cartService = cartService;
        }
        public async Task NewUserRegistration()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Please enter your name");
            string? firstname = Console.ReadLine();

            Console.WriteLine("Please enter yout last name");
            string? lastname = Console.ReadLine();

            Console.WriteLine("Login");
            string? login = Console.ReadLine();

            Console.WriteLine("Password");
            string? password = Console.ReadLine();

            Console.WriteLine("Please enter your balance");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

            UserDto user = new UserDto()
            {
                FirstName = firstname,
                LastName = lastname,
                Login = login,
                Password = password,
                Balance = balance
            };

            await _userRegistrationService.CreateUser(user);
            User loginnedUser = await _userLoginService.LoginUser(login,password);
            int userid = loginnedUser.Id;
            Cart cart = await _cartService.CreateCart(userid);

            if (user != null)
            {
                _context.State = State.User;
                _context.UserId = userid;
            }
            else
            {
                Console.WriteLine("Error has been occured during registration");
                return;
            }
        }
    }
}
