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
    public class AdminMenuBuilder
    {
        public Dictionary<ConsoleKey, string> Items = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.F1, "Logout" },
            { ConsoleKey.F2, "Show Product List" },
            { ConsoleKey.F3, "Edit Product List" },
            { ConsoleKey.F4, "Show order list" },
            { ConsoleKey.F5, "Change order" },
            { ConsoleKey.F6, "Ban user" },
            { ConsoleKey.F7, "Unban user" },
            { ConsoleKey.Escape, "Or press <Esc> to return" }
        };
        public LoginController LoginController { get; set; }
        public ProductController ProductController { get; set; }
        public OrderController OrderController { get; set; }
        public BanController BanController { get; set; }

        public AdminMenuBuilder(LoginController loginController, ProductController productController, OrderController orderController, BanController banController)
        {
            LoginController = loginController;
            ProductController = productController;
            OrderController = orderController;
            BanController = banController;
        }

        public void DisplayMenuItems()
        {
            for (int i = 0; i < Items.Count - 1; i++)
            {
                Console.WriteLine($"<{Items.ElementAt(i).Key}> : {Items.ElementAt(i).Value}");
            }
            Console.WriteLine(Items.ElementAt(Items.Count - 1).Value);
        }

        public async Task Draw(ConsoleKey key, MenuContext context)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    await LoginController.Logout();
                    break;
                case ConsoleKey.F2:
                    await ProductController.ShowAllProducts();
                    break;
                case ConsoleKey.F3:
                    await ProductController.EditProductList();
                    break;
                case ConsoleKey.F4:
                    await OrderController.ShowOrders();
                    break;
                case ConsoleKey.F5:
                    await OrderController.ChangeOrderByAdministrator();
                    break;
                case ConsoleKey.F6:
                    await BanController.BanUser();
                    break;
                case ConsoleKey.F7:
                    await BanController.UnbanUser();
                    break;
                default:
                    DisplayMenuItems();
                    break;
            }
        }
    }
}
