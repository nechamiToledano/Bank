
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
        static CreditCard()
        {
          
        }
        public CreditCard()
        {
            
        }
        public CreditCard(CreditCardType type,int custId,string accountNumber) { 
            
            Number = GenerateCreditCardNumber();
            CVV=GenerateCVV();
            Type = type;
            Status = CreditCardStatus.Active;
            ExpirationMonth =  DateTime.Now.Month;
            ExpirationYear = DateTime.Now.AddYears(7).Year;
            CustomerID=custId;
            AccountNumber = accountNumber;
        }

        public string GenerateCreditCardNumber()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmm");
            return timestamp;
        }
          static Random _random = new Random();
        public string GenerateCVV()
        {
            string randomSuffix = _random.Next(100, 999).ToString(); // 4-digit suffix

            return randomSuffix;
        }
        [Key]
        public int Id { get; set; }
        public CreditCardType Type { get; set; }
        public CreditCardStatus Status { get; set; }
        public string Number { get;  set; }
        public string CVV { get;  set; }
        public int IssueDate { get;  set; }
        public int CreditLimit { get;  set; }
        public int AvailableBalance { get;  set; }
        public string AccountNumber { get; set; }
        public int ExpirationMonth { get;  set; }
        public int ExpirationYear { get;  set; }
        public int CustomerID { get; set; }

    }
}
