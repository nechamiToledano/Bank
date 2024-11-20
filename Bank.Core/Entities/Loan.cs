

namespace Bank.Core.Entities
{
    public enum LoanStatus
    {
        Active,
        Closed,
        Defaulted,
        Paid
    }
    public class Loan
    {
        static int identity;
        public Loan()
        {
            
        }
        public Loan(int customerId,double amount) {
            Id=identity++;
            CustomerId = customerId;
            Amount = amount;
            DateIssued = DateTime.Now;
            InterestRate = 0.01 ;
            

        }
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public DateOnly MaturityDate { get; set; }
        public double InterestRate { get; set; }
        public double OutstandingBalance { get; set; }
        public LoanStatus Status { get; set; }
    }
}
