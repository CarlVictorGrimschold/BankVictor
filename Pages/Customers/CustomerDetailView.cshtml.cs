using BankCore.Data.Models;
using BankCore.Services;
using BankVictor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Reflection.Emit;

namespace BankVictor.Pages.Customers
{
    public class CustomerDetailViewModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly AccountService _accountService;

        public CustomerDetailViewModel(CustomerService customerService,  AccountService  accountService)
        {
            _customerService = customerService;
            _accountService = accountService;

        }
        public CustomerProfileViewModel CustomerDetail { get; set; }


        public void OnGet(int customerId)
        {
            var customerDB = _customerService.GetSpecificCustomer(customerId);
            
            CustomerDetail.CustomerId = customerDB.CustomerId;
            CustomerDetail.Country = customerDB.Country;
            CustomerDetail.Gender = customerDB.Gender;
            CustomerDetail.Givenname = customerDB.Givenname;
            CustomerDetail.Surname = customerDB.Surname;
            CustomerDetail.Streetaddress = customerDB.Streetaddress;
            CustomerDetail.City = customerDB.City;
            CustomerDetail.Zipcode = customerDB.Zipcode;
            CustomerDetail.CountryCode = customerDB.CountryCode;
            CustomerDetail.Birthday = customerDB.Birthday;
            CustomerDetail.NationalId = customerDB.NationalId;
            CustomerDetail.Telephonecountrycode = customerDB.Telephonecountrycode;
            CustomerDetail.Telephonenumber = customerDB.Telephonenumber;
            CustomerDetail.Emailaddress = customerDB.Emailaddress;

            var customerBalance = _accountService.TotalBalance(customerId);
            CustomerDetail.BalanceCustomer = customerBalance;

            


        }
    }
}
