using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;

namespace console_online_store.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;
        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUser(UserDto user)
        {
            User newuser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                PasswordHash = user.PasswordHash,
                Balance = user.Balance,
                UserRoleId = 2,
                CreatedAt = DateTime.UtcNow,
            };
            _dbContext.Users.Add(newuser);
            await _dbContext.SaveChangesAsync();
            return newuser;
        }

    }
}
