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

    public static class MainMenu
    {
        static State state = State.Guest;
        public static void Start()
        {
            bool showGuestMenu = true;
            bool showAdminMenu = true;
            while (true)
            {
                if (state == State.Guest)
                {
                    if (showGuestMenu)
                    {
                        GuestMenuBuilder.DisplayMenuItems();
                        showGuestMenu = false;
                    }

                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        showGuestMenu = true;
                        Console.Clear();
                        continue;
                    }
                   
                    GuestInputHandler.CheckInput(key, ref state, ref showAdminMenu);
                }
                if (state == State.Admin)
                {
                    if (showAdminMenu)
                    {
                        AdminMenuBuilder.DisplayMenuItems();
                        showAdminMenu = false;
                    }

                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        showAdminMenu = true;
                        Console.Clear();
                        continue;
                    }
                    AdminInputHandler.CheckInput(key, ref state, ref showGuestMenu);
                }
            }
        }
    }
}
