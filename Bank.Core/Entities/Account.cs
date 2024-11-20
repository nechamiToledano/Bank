
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
       private static int identity=1;
        public Account()
        {
            
        }
        public Account(int holderId,int branchId)
        {
            Id = identity ++;
            HolderId=holderId;
            BranchId=branchId;   
            Balance = 0;
            Number =GenerateAccountNumber() ;
            DateCreating = DateTime.Now;
            Status=AccountStatus.Active;

        }
        private static Random _random = new Random();
        public string GenerateAccountNumber()
        {
            // Use the current timestamp (e.g., "202311041230") plus a random suffix
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmm");


            string randomSuffix = _random.Next(1000, 9999).ToString(); // 4-digit suffix
            return $"{timestamp}{randomSuffix}";
        }
        public int Id { get; set; }
        public string Number { get; set; }
        public int BranchId { get; set; }
        public int HolderId { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreating { get; set; }
        public AccountStatus Status { get; set; }
    }
}
