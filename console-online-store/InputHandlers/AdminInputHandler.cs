using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.MenuBuilder;
using console_online_store.MenuCore;

namespace console_online_store.InputHandlers
{
    public static class AdminInputHandler
    {
        public static void CheckInput(ConsoleKey key, ref State state, ref bool flag)
        {
            //GuestMenuBuilder.Draw(key);
            switch (key)
            {
                case ConsoleKey.F1:
                    AdminMenuBuilder.Draw(key, ref state, ref flag);
                    break;
                case ConsoleKey.F2:
                    AdminMenuBuilder.Draw(key, ref state, ref flag);
                    break;
                case ConsoleKey.F3:
                    AdminMenuBuilder.Draw(key, ref state, ref flag);
                    break;
            }
        }
    }
}
