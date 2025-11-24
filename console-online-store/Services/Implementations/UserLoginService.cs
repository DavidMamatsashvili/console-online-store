using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;

namespace console_online_store.Services.Implementations
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserRepository _repo;
        public UserLoginService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User> LoginUser(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) return null;

            User? found = await _repo.Login(login);
            bool pass = BCrypt.Net.BCrypt.Verify(password, found?.PasswordHash);
            if (found == null || !pass) return null;

            return found;
        }
    }
}
