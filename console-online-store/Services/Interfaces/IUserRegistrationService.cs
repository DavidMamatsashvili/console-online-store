using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Services.Interfaces
{
    public interface IUserRegistrationService
    {
        Task<UserDto> CreateUser(UserDto user);

    }
}
