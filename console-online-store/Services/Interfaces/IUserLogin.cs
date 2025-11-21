using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.MenuCore;

namespace console_online_store.Services.Interfaces
{
    public interface IUserLogin
    {
        Task<UserDto> LoginUser(string login, string password, MenuContext context);
        Task LogOutUser(MenuContext context);
    }
}
