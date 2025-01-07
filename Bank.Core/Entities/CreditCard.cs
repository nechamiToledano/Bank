
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Bank.Core.Entities
{
    public enum CreditCardStatus
    {
        Active,
        Inactive,
        Blocked,
        Expired
    }
    public enum CreditCardType
    {
        Visa, MasterCard, Amex, Discover
    }
    public class CreditCard
    {

        [Key]
        public int Id { get; set; }
        public CreditCardType Type { get; set; }
        public CreditCardStatus Status { get; set; }
        public string Number { get;  set; }
        public string CVV { get;  set; }
        public DateTime IssueDate { get;  set; }
        public int CreditLimit { get;  set; }
        public int AvailableBalance { get;  set; }
        public string AccountNumber { get; set; }
        public int ExpirationMonth { get;  set; }
        public int ExpirationYear { get;  set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
