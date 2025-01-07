

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
     
     
        [Key]
        public int Id { get;  set; }
        public DateTime DateIssued { get;  set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double Amount { get; set; }
        public DateTime MaturityDate { get;  set; }
        public double InterestRate { get; set; }
        public double OutstandingBalance { get; set; }
        public LoanStatus Status { get; set; }
    }
}
