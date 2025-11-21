using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Services.Implementations
{
    //public class UserLogin : IUserLogin
    //{
    //    private readonly StoreDbContext _dbContext;
    //    public UserLogin(StoreDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public async Task<UserDto> LoginUser(UserDto user, ref bool flag)
    //    {
    //        if (user == null) return null;
    //        if (string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password)) return null;

    //        User? found = await _dbContext.Users.SingleOrDefaultAsync(x => x.Login == user.Login);
    //        bool pass = BCrypt.Net.BCrypt.Verify(user.Password, found?.PasswordHash);
    //        if (found == null || !pass) return null;


    //    }
    //}
}
