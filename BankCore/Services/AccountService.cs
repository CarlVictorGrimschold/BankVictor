using BankCore.Data;
using BankCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCore.Services
{
    public class AccountService
    {
        private readonly VictorBankAppContext _dbContext;

        public AccountService(VictorBankAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public decimal TotalBalance (int customerId)
        {
            var totalBalance = _dbContext.Dispositions
            .Where(d => d.CustomerId == customerId && d.Type =="OWNER").Sum(d => d.Account.Balance);
            return totalBalance;
        }
        public List<Account> GetAllAccountsForCustomer(int customerId)
        {
            var accounts = _dbContext.Dispositions
                .Include(d => d.Account)
                .ThenInclude(a=>a.Dispositions)
                .Where(d => d.CustomerId == customerId && d.Type == "OWNER")
                .Select(d => d.Account) 
                .ToList(); 

            return accounts;
        }
    }
}
