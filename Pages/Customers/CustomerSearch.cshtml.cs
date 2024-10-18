using Azure;
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
        public int CurrentPage { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string Q { get; set; }


        public List<CustomerProfileViewModel> AllCustomers { get; set; }
        public void OnGet(string sortColumn, string sortOrder, int pageNo, string q)
            
        {
            Q = q;

            if (pageNo == 0)
                pageNo = 1;
            CurrentPage = pageNo;

            SortColumn = sortColumn;
            SortOrder = sortOrder;


            AllCustomers = _customerService.GetAllCustomers(sortColumn ,sortOrder, pageNo, q)
             .Select(c => new CustomerProfileViewModel

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
