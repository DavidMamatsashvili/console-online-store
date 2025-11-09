using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using console_online_store.InputHandlers;
using console_online_store.MenuCore;

namespace console_online_store.MenuBuilder
{
    public static class GuestMenuBuilder
    {
        public static Dictionary<ConsoleKey,string>Items = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.F1, "Login" },
            { ConsoleKey.F2, "Show Products" },
            { ConsoleKey.F3, "Register" }
        };
        public static void DisplayMenuItems()
        {
            foreach (var i in Items)
            {
                Console.WriteLine($"<{i.Key}> : {i.Value}");
            }
        }

        //showproducts will use dbcontext to display products
        public static void ShowProducts()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"product{i + 1}:iphone");
            }
        }

        //if guest can login then change state into State.User or State.Admin
        //login will use controller to check for a user in a database
        public static void Login(State state) 
        {
            Console.WriteLine("Login:");
            var x = Console.ReadLine();
            Console.WriteLine(x);
        }

        //if guest will register then change state into State.User
        public static void Register(State state)
        {
            Console.WriteLine("Register:");
            var x = Console.ReadLine();
            Console.WriteLine(x);
        }

        public static void Draw(ConsoleKey key, State state)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    Login(state);
                    break;
                case ConsoleKey.F2:
                    ShowProducts();
                    break;
                case ConsoleKey.F3:
                    Register(state);
                    break;
                default:
                    DisplayMenuItems();
                    break;
            }
        }
    }
}
