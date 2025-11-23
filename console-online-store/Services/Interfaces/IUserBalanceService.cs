using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;

namespace console_online_store.Services.Interfaces
{
    public interface IUserBalanceService
    {
        Task<decimal> GetUserBalance(int userid);
        Task<User> DepositBalance(int userid, decimal amount);
        Task<User> WithdrawBalance(int userid, decimal amount);
    }
}
