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
        Task<User> Login(string login);
        Task<User> CreateUser(UserDto user);
        Task<User> BanUser(int userId);
        Task<User> UnbanUser(int userId);
        Task<bool> CheckIfUserExists(string login);
        Task<User> GetUserById(int id);
    }
}
