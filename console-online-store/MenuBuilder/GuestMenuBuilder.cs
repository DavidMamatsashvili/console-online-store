using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Controllers;
using console_online_store.Data;
using console_online_store.InputHandlers;
using console_online_store.MenuCore;
using console_online_store.Models;

namespace console_online_store.MenuBuilder
{
    public class GuestMenuBuilder
    {  
        public Dictionary<ConsoleKey,string>Items = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.F1, "Login" },
            { ConsoleKey.F2, "Show Products" },
            { ConsoleKey.F3, "Register" }
        };
        public LoginController LoginController { get; set; }
        public RegistrationController RegistrationController { get; set; }
        public ProductController ProductController { get; set; }
        public GuestMenuBuilder(LoginController loginController,RegistrationController registrationController, ProductController productController)
        {
            LoginController = loginController;
            RegistrationController = registrationController;
            ProductController = productController;
        }
        public void DisplayMenuItems()
        {
            foreach (var i in Items)
            {
                Console.WriteLine($"<{i.Key}> : {i.Value}");
            }
        }

        //showproducts will use dbcontext to display products
        public void ShowProducts()
        {
            using var context = new StoreDbContext();
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"product{i + 1}:iphone");
            }
        }

        //if guest can login then change state into State.User or State.Admin
        //login will use controller to check for a user in a database
        public void Login(MenuContext context) 
        {
            Console.WriteLine("Login:");
            var x = Console.ReadLine();
            if (x == "user")
            {
                context.State = State.User;
                context.showGuestMenu = false;
                context.showAdminMenu = false;
            }
            else if (x == "admin")
            {
                context.State = State.Admin;
                context.showAdminMenu = true;
                context.showGuestMenu = false;
            }
            
            if (context.State != State.Guest) Console.Clear();
          
            //if (x == "user") state = State.User;
            //if (x == "admin") state = State.Admin;
            //if (state != State.Guest) Console.Clear();
            //flag = true;
        }

        //if guest will register then change state into State.User
        public void Register()
        {
            Console.WriteLine("Register:");
            var x = Console.ReadLine();
            Console.WriteLine(x);
        }

        public async Task Draw(ConsoleKey key, MenuContext context)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    //Login(context);
                    await LoginController.UserLogin();
                    break;
                case ConsoleKey.F2:
                    //ShowProducts();
                    await ProductController.ShowAllProducts();
                    break;
                case ConsoleKey.F3:
                    //Register();
                    await RegistrationController.NewUserRegistration();
                    break;
                default:
                    DisplayMenuItems();
                    break;
            }
        }
    }
}
