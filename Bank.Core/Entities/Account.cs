
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
    public class Account
    {
        public Account()
        {
            
        }
        public Account(int holderId,int branchId)
        {
            
            
            HolderId=holderId;
            BranchId=branchId;   
            Balance = 0;
            Number =GenerateAccountNumber() ;
            DateCreating = DateTime.Now;
            Status=AccountStatus.Active;

        }
          static Random _random = new Random();
        public string GenerateAccountNumber()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmm");
            string randomSuffix = _random.Next(1000, 9999).ToString(); // 4-digit suffix
            return $"{timestamp}{randomSuffix}";
        }
        [Key]
        public int Id { get;   set; }
        [BindNever]
        public string Number { get;   set; }
        public int BranchId { get; set; }
        public int HolderId { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreating { get;   set; }
        public AccountStatus Status { get; set; }
    }
}
