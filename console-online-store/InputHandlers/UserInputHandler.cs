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
            await userMenuBuilder.Draw(key, context);
        }
    }
}
