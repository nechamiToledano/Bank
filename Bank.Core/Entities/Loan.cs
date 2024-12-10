

using System.ComponentModel.DataAnnotations;

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
     
        public Loan()
        {
            
        }
        public Loan(int customerId,double amount,double interestRate) {
            CustomerId = customerId;
            Amount = amount;
            DateIssued = DateTime.Now;
            InterestRate = interestRate ;
            

        }
        [Key]
        public int Id { get;  set; }
        public DateTime DateIssued { get;  set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public DateTime MaturityDate { get;  set; }
        public double InterestRate { get; set; }
        public double OutstandingBalance { get; set; }
        public LoanStatus Status { get; set; }
    }
}
