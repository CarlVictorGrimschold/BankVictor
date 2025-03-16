//using BankCore.Data;
//using BankCore.Data.Models;
//using Microsoft.Identity.Client;
//using Microsoft.Owin.Security;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BankCore.Services
//{
//    public class CountryService
//    {
//        private readonly VictorBankAppContext _dbContext;

//        public CountryService(VictorBankAppContext dbContext)
//        {
//           _dbContext = dbContext;
//        }

//        public List<Customer> GetCustomersByCountry(string countryCode)
//        {

//        }







//{
//    var customersByCountry = _dbContext.Customers
//        .Where(c => c.CountryCode == countryCode)
//        .ToList();
//    return customersByCountry;
//}




//public List<Customer> GetAllCustomers()
//{
//    var allCustomer = _dbContext.Customers.ToList();
//    return allCustomer;
//}
//    }
//}

using BankCore.Data;
using BankCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCore.Services
{
    public class CountryService
    {
        private readonly VictorBankAppContext _dbContext;

        public CountryService(VictorBankAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetTopWealthyCustomersByCountry(string countryCode)
        {
            
            var wealthiestCustomersByCountry = _dbContext.Customers
                .Where(c => c.CountryCode == countryCode)
                .Include(c => c.Dispositions)
                .ThenInclude(d =>d.Account)
                .OrderByDescending(c => c.Dispositions
                .Where(d => d.Type == "OWNER").Sum(d => d.Account.Balance))
                .Take(10)                
                .ToList();
            return wealthiestCustomersByCountry;

        }
    }
}
