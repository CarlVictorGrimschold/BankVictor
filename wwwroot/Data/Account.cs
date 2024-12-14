namespace BankVictor.wwwroot.Data
{
    public class Account
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
    }
}
