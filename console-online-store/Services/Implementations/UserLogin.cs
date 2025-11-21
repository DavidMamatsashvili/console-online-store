using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.MenuCore;
using console_online_store.Models;
using console_online_store.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace console_online_store.Services.Implementations
{
    public class UserLogin : IUserLogin
    {
        private readonly StoreDbContext _dbContext;
        public UserLogin(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> LoginUser(string login, string password, MenuContext context)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) return null;

            User? found = await _dbContext.Users.SingleOrDefaultAsync(x => x.Login == login);
            bool pass = BCrypt.Net.BCrypt.Verify(password, found?.PasswordHash);
            if (found == null || !pass) return null;

            if(login == "admin")
            {
                context.showGuestMenu = false;
                context.showAdminMenu = true;
                context.showUserMenu = false;
                context.State = State.Admin;
            }
            else
            {
                context.showGuestMenu = false;
                context.showAdminMenu = false;
                context.showUserMenu = true;
                context.State = State.User;
            }

            return found;
        }

        public async Task LogOutUser(MenuContext context)
        {
            context.showGuestMenu = true;
            context.showAdminMenu = false;
            context.showUserMenu = false;
            context.State = State.Guest;
        }
    }
}
