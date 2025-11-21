using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.InputHandlers;
using console_online_store.MenuBuilder;

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
    }

    public static class MainMenu
    {
        public static void Start()
        {
            MenuContext context = new MenuContext();

            while (true)
            {
                if (context.State == State.Guest)
                {
                    if (context.showGuestMenu)
                    {
                        GuestMenuBuilder.DisplayMenuItems();
                        context.showGuestMenu = false;
                    }

                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        context.showGuestMenu = true;
                        Console.Clear();
                        continue;
                    }

                    GuestInputHandler.CheckInput(key, context);
                }
                if (context.State == State.Admin)
                {
                    if (context.showAdminMenu)
                    {
                        AdminMenuBuilder.DisplayMenuItems();
                        context.showAdminMenu = false;
                    }

                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        context.showAdminMenu = true;
                        Console.Clear();
                        continue;
                    }
                    AdminInputHandler.CheckInput(key, context);
                }
            }
        }
    }
}
