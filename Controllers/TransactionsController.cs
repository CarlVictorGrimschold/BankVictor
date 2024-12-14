//using BankCore.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace BankVictor.Api
//{
//    [ApiController]
//    [Route("api/transactions")]
//    public class TransactionsController : ControllerBase
//    {
//        private readonly TransactionService _transactionService;

//        public TransactionsController(TransactionService transactionService)
//        {
//            _transactionService = transactionService;
//        }

//        [HttpGet]
//        public IActionResult GetTransactions(int accountId, int skip, int take)
//        {
//            var transactions = _transactionService.GetTransactionsForAccount(accountId, skip, take);
//            return Ok(transactions.Select(t => new
//            {
//                t.TransactionId,
//                t.Date,
//                t.Amount,
//                t.Type
//            }));
//        }
//    }
//}

