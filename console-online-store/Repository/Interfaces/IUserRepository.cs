using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(UserDto user);
        Task<User> BanUser(int userId);
        Task<User> UnbanUser(int userId);
    }
}
