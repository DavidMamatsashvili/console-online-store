using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.MenuBuilder;
using console_online_store.MenuCore;

namespace console_online_store.InputHandlers
{
    public class GuestInputHandler
    {
        public void CheckInput(ConsoleKey key, MenuContext context, GuestMenuBuilder guestMenuBuilder)
        {
            //GuestMenuBuilder.Draw(key);
            switch (key)
            {
                case ConsoleKey.F1:
                    guestMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F2:
                    guestMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F3:
                    guestMenuBuilder.Draw(key, context);
                    break;
            }
        }
    }
}
