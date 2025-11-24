using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Controllers;
using console_online_store.Data;
using console_online_store.MenuCore;
using console_online_store.Models;

namespace console_online_store.MenuBuilder
{
    public class GuestMenuBuilder
    {
        public Dictionary<ConsoleKey, string> Items = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.F1, "Login" },
            { ConsoleKey.F2, "Show Products" },
            { ConsoleKey.F3, "Register" }
        };
        public LoginController LoginController { get; set; }
        public RegistrationController RegistrationController { get; set; }
        public ProductController ProductController { get; set; }
        public GuestMenuBuilder(LoginController loginController, RegistrationController registrationController, ProductController productController)
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

        public async Task Draw(ConsoleKey key, MenuContext context)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    await LoginController.UserLogin();
                    break;
                case ConsoleKey.F2:
                    await ProductController.ShowAllProducts();
                    break;
                case ConsoleKey.F3:
                    await RegistrationController.NewUserRegistration();
                    break;
                default:
                    DisplayMenuItems();
                    break;
            }
        }
    }
}
