using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.MenuBuilder;
using console_online_store.MenuCore;

namespace console_online_store.InputHandlers
{
    public class AdminInputHandler
    {
        public async Task CheckInput(ConsoleKey key, MenuContext context, AdminMenuBuilder adminMenuBuilder)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    await adminMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F2:
                    await adminMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F3:
                    await adminMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F4:
                    await adminMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F5:
                    await adminMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F6:
                    await adminMenuBuilder.Draw(key, context);
                    break;
                case ConsoleKey.F7:
                    await adminMenuBuilder.Draw(key, context);
                    break;
            }
        }
    }
}
