//namespace bankvictor.viewmodels
//{
//    public class transactionpagemodel
//    {
//        public accountviewmodel accountdetails { get; set; }
//        public list<transactionviewmodel> transactions { get; set; } = new list<transactionviewmodel>();
//    }
//}
using System.Collections.Generic;

namespace BankVictor.ViewModels
{
    public class TransactionPageModel
    {
        public AccountViewModel AccountDetails { get; set; }
        public List<TransactionViewModel> Transactions { get; set; } = new List<TransactionViewModel>();
    }

    //public class AccountViewModel
    //{
    //    public int AccountId { get; set; }
    //    public decimal Balance { get; set; }
    //}

    public class TransactionViewModel
    {
        public DateTime Date { get; set; } // Använd DateTime om korrekt datatypshantering behövs
        public string Type { get; set; }
        public decimal Amount { get; set; }
    }
}
 

