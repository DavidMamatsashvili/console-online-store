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
    public class UserBalanceService : IUserBalanceService
    {
        private readonly IUserBalanceRepository _userBalanceRepository;
        public UserBalanceService(IUserBalanceRepository userBalanceRepository)
        {
            _userBalanceRepository = userBalanceRepository;
        }
        public async Task<decimal> GetUserBalance(int userid)
        {
            if (userid <= 0) return 0;
            decimal balance = await _userBalanceRepository.GetUserBalance(userid);
            return balance;
        }
        public async Task<User> DepositBalance(int userid, decimal amount)
        {
            if (userid <= 0) return null;
            User? user = await _userBalanceRepository.DepositBalance(userid, amount);
            return user;
        }
        public async Task<User> WithdrawBalance(int userid, decimal amount)
        {
            if (userid <= 0) return null;
            User? user = await _userBalanceRepository.WithdrawBalance(userid, amount);
            return user;
        }
    }
}
