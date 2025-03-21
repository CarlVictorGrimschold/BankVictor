//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace BankVictor.Pages.Account
//{
//    public class IndexModel : PageModel
//    {
//        public List<AccountViewModel> Accounts { get; set; }

//        public class AccountViewModel
//        {
//            public int Id { get; set; }
//            public string AccountNo { get; set; }
//            public decimal Balance { get; set; }
//        }

//        public void OnGet()
//        {
//        }
//    }
//} ändrat 2025-02-05

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankCore.Data.Models;// Antag att detta är din DbContext
using System.Collections.Generic;
using System.Linq;
using BankCore.Data;

namespace BankVictor.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly VictorBankAppContext _context;

        public IndexModel(VictorBankAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountViewModel Account { get; set; }

        public class AccountViewModel
        {
            public int AccountId { get; set; }
            public decimal Balance { get; set; }
            public List<TransactionViewModel> Transactions { get; set; }
        }

        public class TransactionViewModel
        {
            public int TransactionId { get; set; }
            public DateOnly TransactionDate { get; set; }
            public decimal Amount { get; set; }
            public string Description { get; set; }
        }

        public void OnGet(int accountId)
        {
            var account = _context.Accounts
                .Where(a => a.AccountId == accountId)
                .Select(a => new AccountViewModel
                {
                    AccountId = a.AccountId,
                    Balance = a.Balance,
                    Transactions = a.Transactions.Select(t => new TransactionViewModel
                    {
                        TransactionId = t.TransactionId,
                        TransactionDate = t.TransactionDate,
                        Amount = t.Amount,
                        Description = t.Description
                    }).OrderByDescending(t => t.TransactionDate).ToList()
                }).FirstOrDefault();

            Account = account;
        }
    }
}
