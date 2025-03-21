using BankCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankVictor.ViewModels;  // Se till att inkludera korrekt namespace för din ViewModel
using System.Threading.Tasks;

namespace BankVictor.Controllers
{
    public class AccountController : Controller
    {
        private readonly VictorBankAppContext _context;

        public AccountController(VictorBankAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int accountId)
        {
            var account = await _context.Accounts
                .Include(a => a.Transactions.OrderByDescending(t => t.TransactionDate))
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (account == null)
            {
                return NotFound();
            }

            var model = new AccountViewModel
            {
                AccountId = account.AccountId,
                Balance = account.Balance,
                Transactions = account.Transactions.Select(t => new TransactionViewModel
                {
                    TransactionId = t.TransactionId,
                    TransactionDate = t.TransactionDate,
                    Type = t.Type, // Antag att detta fält existerar
                    Amount = t.Amount,
                    Description = t.Description // Antag att detta fält existerar
                }).ToList()
            };

            return View(model);
        }
    }
}

