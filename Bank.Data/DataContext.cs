using Bank.Core.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Operation> Operations { get; set; }

 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-SSNMLFD;Database=Bank_db;Integrated Security=true;");
    }

}