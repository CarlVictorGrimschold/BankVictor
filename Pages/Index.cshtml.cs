using BankCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using BankCore.Data.Models;

namespace BankVictor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CountryService _countryService;

        public IndexModel(CountryService countryService)
        {
            _countryService = countryService;
        }
        public List<Customer> Customers { get; set; }
        public void OnGet()
        {
            Customers = _countryService.GetTopWealthyCustomersByCountry("FI");
          //  _countryService.GetAllCustomers();
        }
    }
}
