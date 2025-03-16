namespace BankVictor.ViewModels
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }

        public string Frequency { get; set; } = null!;

        public DateOnly Created { get; set; }

        public decimal Balance { get; set; }
        public List<TransactionViewModel> Transactions { get; set; } = new List<TransactionViewModel>();
    }
}
