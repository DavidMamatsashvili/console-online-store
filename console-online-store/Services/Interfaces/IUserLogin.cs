using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;

namespace console_online_store.Services.Interfaces
{
    public interface IUserLogin
    {
        Task<UserDto> LoginUser(UserDto user, ref bool flag);
        Task<UserDto> LogOutUser(UserDto user, ref bool flag);
    }
}
