using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankVictor.Pages.Account
{
    public class IndexModel : PageModel
    {
        public List<AccountViewModel> Accounts { get; set; }

        public class AccountViewModel
        {
            public int Id { get; set; }
            public string AccountNo { get; set; }
            public decimal Balance { get; set; }
        }

        public void OnGet()
        {
        }
    }
}
