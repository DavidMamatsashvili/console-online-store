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
            bool showMenu = true;
            while (true)
            {
                if (state == State.Guest)
                {
                    if (showMenu)
                    {
                        GuestMenuBuilder.DisplayMenuItems();
                        showMenu = false;
                    }

                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        showMenu = true;
                        Console.Clear();
                        continue;
                    }
                    GuestInputHandler.CheckInput(key, state);
                }
            }
        }
    }
}
