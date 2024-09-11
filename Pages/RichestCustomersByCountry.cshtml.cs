using BankCore.Data.Models;
using BankCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankVictor.Pages
{
    public class RichestCustomersByCountryModel : PageModel
    {
        private readonly CountryService _countryService;

        public RichestCustomersByCountryModel(CountryService countryService)
        {
            _countryService = countryService;
        }


        public List<Customer> Customers { get; set; }


        public void OnGet(string countryCode = "SE")
        {
            Customers = _countryService.GetCustomersByCountry(countryCode);
        }
    }
}
