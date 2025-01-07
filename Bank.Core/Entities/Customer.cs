


using System.ComponentModel.DataAnnotations;

namespace Bank.Core.Entities
{
    public enum CustomerStatus
    {
        New,
        Active,
        Inactive,
        Suspended,
        Closed,
        Banned
    }
    public class Customer
    {
        
        [Key]
        public int Id { get;  set; }
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public  CustomerStatus Status { get; set; }
        public DateTime JoiningDate { get;  set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<Loan> Loans { get; set; } 
        public List<Account> Accounts { get; set; }
    }
}
