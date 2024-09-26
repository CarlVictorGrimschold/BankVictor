using BankCore.Data.Models;
using BankCore.Services;
using BankVictor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace BankVictor.Pages
{
    public class RichestCustomersByCountryModel : PageModel
    {
        private readonly CountryService _countryService;
        private readonly AccountService _accountService;

        public RichestCustomersByCountryModel(CountryService countryService, AccountService accountService)
        {
            _countryService = countryService;
            _accountService = accountService;
        }





        public List<TopCustomerViewModel> Customers { get; set; }
       

        public void OnGet(string countryCode = "SE")
        {
            Customers = _countryService.GetTopWealthyCustomersByCountry(countryCode)
                .Select(c => new TopCustomerViewModel
            {
                CustomerId = c.CustomerId,
                Country = c.Country,
                Gender = c.Gender,
                Givenname = c.Givenname,
                Surname = c.Surname,
                Streetaddress = c.Streetaddress,
                City = c.City,
                Zipcode = c.Zipcode,
                CountryCode = c.CountryCode,
                Birthday = c.Birthday,
                NationalId = c.NationalId,
                Telephonecountrycode = c.Telephonecountrycode,
                Telephonenumber = c.Telephonenumber,
                Emailaddress = c.Emailaddress,


            }).ToList();

            foreach (TopCustomerViewModel customer in Customers)
            {

                customer.BalanceCustomer = _accountService.TotalBalance(customer.CustomerId);

                
            }
        }



    }
}

