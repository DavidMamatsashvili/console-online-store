using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;

namespace console_online_store.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(string login)
        {
            if (string.IsNullOrEmpty(login)) return null;
            User user = await _userRepository.Login(login);
            return user;
        }

        public async Task<User> CreateUser(UserDto user)
        {
            if (user == null) return null;
            bool exists = await _userRepository.CheckIfUserExists(user.Login);
            if (exists) return null;

            User? newuser = await _userRepository.CreateUser(user);
            return newuser;
        }

        public async Task<User> BanUser(int userId)
        {
            if (userId <= 0) return null;
            User? user = await _userRepository.BanUser(userId);
            return user;
        }
        public async Task<User> UnbanUser(int userId)
        {
            if (userId <= 0) return null;
            User? user = await _userRepository.UnbanUser(userId);
            return user;
        }
        public async Task<bool> CheckIfUserExists(string login)
        {
            if (!string.IsNullOrEmpty(login)) return false;
            bool exists = await _userRepository.CheckIfUserExists(login);
            return exists;
        }
        public async Task<User> GetUserById(int id)
        {
            if (id <= 0) return null;
         
            User? user = await _userRepository.GetUserById(id);
            return user;
        }

    }
}
