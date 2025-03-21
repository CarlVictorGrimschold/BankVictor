//using System;
//using System.Collections.Generic;

//namespace BankCore.Data.Models;

//public partial class Transaction
//{
//    public int TransactionId { get; set; }

//    public int AccountId { get; set; }

//    public DateOnly Date { get; set; }

//    public string Type { get; set; } = null!;

//    public string Operation { get; set; } = null!;

//    public decimal Amount { get; set; }

//    public decimal Balance { get; set; }

//    public string? Symbol { get; set; }

//    public string? Bank { get; set; }

//    public string? Account { get; set; }

//    public virtual Account AccountNavigation { get; set; } = null!;
//}
using System;

namespace BankCore.Data.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }
    public int AccountId { get; set; }
    public DateOnly TransactionDate { get; set; }  // Använder DateTime för att inkludera både datum och tid
    public string Type { get; set; } = null!;
    public string Operation { get; set; } = null!;
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public string Description { get; set; } = null!;  // Ser till att detta fält finns
    public string? Symbol { get; set; }
    public string? Bank { get; set; }
    public string? Account { get; set; }
    public virtual Account AccountNavigation { get; set; } = null!;
}
