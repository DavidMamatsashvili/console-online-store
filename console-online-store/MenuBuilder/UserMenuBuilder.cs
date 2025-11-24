using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Controllers;
using console_online_store.Data;
using console_online_store.MenuCore;

namespace console_online_store.MenuBuilder
{
    public class UserMenuBuilder
    {
        public Dictionary<ConsoleKey, string> Items = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.F1, "Logout" },
            { ConsoleKey.F2, "Deposit Money" },
            { ConsoleKey.F3, "Withdraw Money" },
            { ConsoleKey.F4, "Products" },
            { ConsoleKey.F5, "Add to Cart" },
            { ConsoleKey.F6, "View Cart" },
            { ConsoleKey.F7, "Payment" },
            { ConsoleKey.F8, "Order History" },
            { ConsoleKey.Escape, "Or press <Esc> to return" }
        };
        public LoginController LoginController { get; set; }
        public ProductController ProductController { get; set; }
        public OrderController OrderController { get; set; }
        public UserController UserController { get; set; }
        public CartController CartController { get; set; }

        public UserMenuBuilder(LoginController loginController, ProductController productController, OrderController orderController, UserController userController, CartController crtController)
        {
            LoginController = loginController;
            ProductController = productController;
            OrderController = orderController;
            UserController = userController;
            CartController = crtController;
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
                    await UserController.DepositUserBalance();
                    break;
                case ConsoleKey.F3:
                    await UserController.WithdrawUserBalance();
                    break;
                case ConsoleKey.F4:
                    await ProductController.ShowAllProducts();
                    break;
                case ConsoleKey.F5:
                    await CartController.AddItemInCart();
                    break;
                case ConsoleKey.F6:
                    await CartController.ViewProductsInCart();
                    break;
                case ConsoleKey.F7:
                    await CartController.Payment();
                    break;
                case ConsoleKey.F8:
                    await OrderController.GetOrdersByUserId();
                    break;
                default:
                    DisplayMenuItems();
                    break;
            }
        }
    }
}
