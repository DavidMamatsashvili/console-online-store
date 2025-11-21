using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Implementations;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Services.Implementations
{
    public class UserRegistrationService:IUserRegistrationService
    {
        private readonly IUserRepository _repo;
        public UserRegistrationService(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<UserDto> CreateUser(UserDto user)
        {
            if (user == null) return null;
        
            //user input validation
            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Login) ||
                user.Balance < 0) return null;

            //check if there is another user with the same login
            bool exists = await _repo.CheckIfUserExists(user.Login);
            if (exists) return null;

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.PasswordHash = passwordHash;

            await _repo.CreateUser(user);
            return user;
        }
    }
}
