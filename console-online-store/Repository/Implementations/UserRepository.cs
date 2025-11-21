using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;
        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Login(string login)
        {
            return await _dbContext.Users?.SingleOrDefaultAsync(x=>x.Login==login);
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
                IsBanned = false,
            };
            _dbContext.Users.Add(newuser);
            await _dbContext.SaveChangesAsync();
            return newuser;
        }

        public async Task<User> BanUser(int userid)
        {
            User? user = await _dbContext.Users.FindAsync(userid);
            user.IsBanned = true;
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UnbanUser(int userid)
        {
            User? user = await _dbContext.Users.FindAsync(userid);
            user.IsBanned = false;
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> CheckIfUserExists(string login)
        {
            return await _dbContext.Users.AnyAsync(user => user.Login == login);
        }
    }
}
