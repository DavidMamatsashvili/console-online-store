using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;

namespace console_online_store.Repository.Implementations
{
    public class UserBalanceRepository : IUserBalanceRepository
    {
        private readonly StoreDbContext _dbContext;
        public UserBalanceRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal> GetUserBalance(int userid)
        {
            User? user = await _dbContext.Users.FindAsync(userid);
            decimal balance = user.Balance;
            return balance;
        }
        public async Task<User> DepositBalance(int userid, decimal amount)
        {
            User? user = await _dbContext.Users.FindAsync(userid);
            user.Balance += amount;
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> WithdrawBalance(int userid, decimal amount)
        {
            User? user = await _dbContext.Users.FindAsync(userid);
            user.Balance -= amount;
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
