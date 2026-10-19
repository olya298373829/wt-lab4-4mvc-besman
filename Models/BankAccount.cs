namespace wt_lab4_4mvc_besman.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Owner { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "BYN";
        public bool IsActive { get; set; } = true;
    }
}