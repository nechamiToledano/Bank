

using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Bank.Core.Entities
{
    public enum OperationType
    {
        Deposit,
        Withdrawal,
        Transfer,
        Fee,
        Interest,
        Refund,
        Payment,
        Adjustment
    }
    public class Operation
    {
  
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public OperationType Type { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
