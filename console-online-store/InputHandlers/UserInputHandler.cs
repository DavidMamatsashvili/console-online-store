using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.MenuBuilder;
using console_online_store.MenuCore;

namespace console_online_store.InputHandlers
{
    public class UserInputHandler
    {
        public async Task CheckInput(ConsoleKey key, MenuContext context, UserMenuBuilder userMenuBuilder)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    await userMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F2:
                    await userMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F3:
                    await userMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F4:
                    await userMenuBuilder.Draw(key,context);
                    break;
                case ConsoleKey.F5:
                    await userMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F6:
                    await userMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F7:
                    await userMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F8:
                    await userMenuBuilder.Draw(key, context);
                    break;
            }
        }
    }
}
