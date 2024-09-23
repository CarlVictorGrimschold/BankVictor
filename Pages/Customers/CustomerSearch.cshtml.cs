using BankCore.Services;
using BankVictor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace BankVictor.Pages.Customers
{
    public class CustomerSearchModel : PageModel
    {
        private readonly CustomerService _customerService;
        public CustomerSearchModel(CustomerService customerService)
        {
            _customerService = customerService;
            
        }

        public List<AllCustomerWiewModels> AllCustomers { get; set; }
        public void OnGet(string sortColumn, string sortOrder)
            
        {
            
            AllCustomers = _customerService.GetAllCustomers(sortColumn ,sortOrder)
             .Select(c => new AllCustomerWiewModels

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


        }
               
    }
}
