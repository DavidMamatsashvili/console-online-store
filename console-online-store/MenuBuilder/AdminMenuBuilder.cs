using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.MenuCore;

namespace console_online_store.MenuBuilder
{
    public static class AdminMenuBuilder
    {
        public static Dictionary<ConsoleKey, string> Items = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.F1, "Logout" },
            { ConsoleKey.F2, "Show Products" },
            { ConsoleKey.F3, "Add product" },
            { ConsoleKey.F4, "Show order list" },
            { ConsoleKey.F5, "Cancel order" },
            { ConsoleKey.F6, "Change order state" },
            { ConsoleKey.F7, "User roles" },
            { ConsoleKey.F8, "Order States" },
            { ConsoleKey.Escape, "Or press <Esc> to return" }
        };
        public static void DisplayMenuItems()
        {
            for (int i = 0; i < Items.Count - 1; i++) 
            {
                Console.WriteLine($"<{Items.ElementAt(i).Key}> : {Items.ElementAt(i).Value}");
            }
            Console.WriteLine(Items.ElementAt(Items.Count - 1).Value);
        }

        public static void ShowProducts()
        {
            using var context = new StoreDbContext();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"product{i + 1}:iphone");
            }
        }

        public static void Logout(ref State state, ref bool flag)
        {
            state = State.Guest;
            flag = true;
            Console.Clear();
        }

        public static void Esc()
        {
            
        }

        public static void Draw(ConsoleKey key, ref State state,ref bool flag)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    Logout(ref state,ref flag);
                    break;
                case ConsoleKey.F2:
                    ShowProducts();
                    break;
                case ConsoleKey.F3:
                    //Register(state);
                    break;
                default:
                    DisplayMenuItems();
                    break;
            }
        }
    }
}
