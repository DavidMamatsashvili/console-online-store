using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.MenuBuilder;
using console_online_store.MenuCore;

namespace console_online_store.InputHandlers
{
    public static class GuestInputHandler
    {
        public static void CheckInput(ConsoleKey key, State state)
        {
            //GuestMenuBuilder.Draw(key);
            switch (key)
            {
                case ConsoleKey.F1:
                    GuestMenuBuilder.Draw(key,state);
                    break;
                case ConsoleKey.F2:
                    GuestMenuBuilder.Draw(key,state);
                    break;
                case ConsoleKey.F3:
                    GuestMenuBuilder.Draw(key,state);
                    break;
            }
        }
    }
}
