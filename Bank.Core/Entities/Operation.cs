

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
        static private int identity;
        public Operation()
        {
            
        }
        static Operation()
        {
            identity = 1;
        }
        public Operation(string description,decimal amount,int accountId,OperationType type) {
            Id = identity++;
            Description = description;
            Amount = amount;
            AccountId = accountId;
            Type = type;
            Date = DateTime.Now;
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public OperationType Type { get; set; }
        public int AccountId { get; set; }
    }
}
