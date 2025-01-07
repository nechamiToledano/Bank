
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bank.Core.Entities
{
    public enum AccountStatus
    {
        Active,
        Inactive,
        Suspended,
        Closed,
    }

    public enum Branch
    {
        Main = 1,
        East = 2,
        West = 3,
        North = 4,
        South = 5,
        Online = 6
    }
    public class Account
    {
      
        
        [Key]
        public int Id { get;   set; }
        public string Number { get;   set; }
        public Branch Branch { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreating { get;   set; }
        public AccountStatus Status { get; set; }
        public List<Operation> Operations { get; set; }
    }
}
