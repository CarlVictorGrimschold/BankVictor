namespace BankVictor.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public DateOnly TransactionDate { get; set; }
        public string Type { get; set; } // Beroende på dina behov kanske du vill visa transaktionstyp
        public decimal Amount { get; set; }
        public string Description { get; set; } // Tillval, om du vill visa en beskrivning
    }
}

