using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Controllers;
using console_online_store.Data;
using console_online_store.InputHandlers;
using console_online_store.MenuBuilder;
using console_online_store.Repository.Implementations;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Implementations;

namespace console_online_store.MenuCore
{
    public enum State
    {
        Guest,
        User,
        Admin
    };
    public class MenuContext
    {
        public State State { get; set; } = State.Guest;
        public bool showGuestMenu { get; set; } = true;
        public bool showAdminMenu { get; set; } = false;
        public bool showUserMenu { get; set; } = false;
        public int UserId { get; set; }
    }

    public static class MainMenu
    {
        public static async Task StartAsync()
        {
            using StoreDbContext dbContext = new StoreDbContext();
            ICartRepository cartRepository = new CartRepository(dbContext);
            ICustomerOrderRepository customerOrderRepository = new CustomerOrderRepository(dbContext);
            IProductRepository productRepository = new ProductRepository(dbContext);
            IUserBalanceRepository userBalanceRepository = new UserBalanceRepository(dbContext);
            IUserRepository userRepository = new UserRepository(dbContext);

            MenuContext context = new MenuContext();

            CartService cartService = new CartService(cartRepository,productRepository);
            CustomerOrderService customerOrderService = new CustomerOrderService(customerOrderRepository);
            ProductService productService = new ProductService(productRepository);
            UserBalanceService userBalanceService = new UserBalanceService(userBalanceRepository);
            UserLoginService userLoginService = new UserLoginService(userRepository);
            UserRegistrationService userRegistrationService = new UserRegistrationService(userRepository);
            UserService userService = new UserService(userRepository);

            BanController banController = new BanController(context,userService);
            CartController cartController = new CartController(context,cartService,productService,customerOrderService,userBalanceService);
            LoginController loginController = new LoginController(context,userLoginService);
            OrderController orderController = new OrderController(context, customerOrderService);
            ProductController productController = new ProductController(context,productService);
            RegistrationController registrationController = new RegistrationController(context,userRegistrationService,userLoginService,cartService);
            UserController userController = new UserController(context, userBalanceService);

            GuestMenuBuilder guestMenuBuilder = new GuestMenuBuilder(loginController,registrationController,productController);
            GuestInputHandler guestInputHandler = new GuestInputHandler();

            AdminMenuBuilder adminMenuBuilder = new AdminMenuBuilder(loginController,productController,orderController,banController);
            AdminInputHandler adminInputHandler = new AdminInputHandler();


            while (true)
            {
                if (context.State == State.Guest)
                {
                    if (context.showGuestMenu)
                    {
                        guestMenuBuilder.DisplayMenuItems();
                        context.showGuestMenu = false;
                    }

                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        context.showGuestMenu = true;
                        Console.Clear();
                        continue;
                    }

                    await guestInputHandler.CheckInput(key, context, guestMenuBuilder);
                }
                if (context.State == State.Admin)
                {
                    if (context.showAdminMenu)
                    {
                        adminMenuBuilder.DisplayMenuItems();
                        context.showAdminMenu = false;
                    }

                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        context.showAdminMenu = true;
                        Console.Clear();
                        continue;
                    }
                    await adminInputHandler.CheckInput(key, context, adminMenuBuilder);
                }
            }
        }
    }
}
