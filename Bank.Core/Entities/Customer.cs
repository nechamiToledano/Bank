


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
        static int identity = 1;
        public Customer()
        {
            
        }
        public Customer(string tz,string firstName,string lastName,string phoneNumber,string address,string email,int accountId)
        {
          
        
            Id = identity++;
            //TzValid tzValid = new TzValid();
            //ErrorTZ res;
            //if(tzValid.ISOK(tz, out res))
            //    Tz= tz;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            Status=CustomerStatus.Active;
            AccountId = accountId;
            JoiningDate = DateTime.Now;

        }
        public int Id { get; set; }
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public  CustomerStatus Status { get; set; }
        public int AccountId { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
