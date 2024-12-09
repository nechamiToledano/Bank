using Bank.Core.Entities;
using Bank.Core.InterfaceRepository;
using Bank.Core.InterfaceService;
using Bank.Data.Repositories;
using Bank.Service;

namespace Bank.Api
{
	public static class eExteshin
	{
		public static void ServieDependencyInjector(this IServiceCollection s)
        {
			
			s.AddScoped<IRepository<Account>, Repository<Account>>();
			s.AddScoped<IAccountService, AccountService>();
            s.AddScoped<IRepository<Customer>, Repository<Customer>>();
            s.AddScoped<ICustomerService, CustomerService>();
            s.AddScoped<IRepository<CreditCard>, Repository<CreditCard>>();
            s.AddScoped<ICreditCardService, CreditCardService>();
            s.AddScoped<IRepository<Loan>, Repository<Loan>>();
            s.AddScoped<ILoanService, LoanService>();
            s.AddScoped<IRepository<Operation>, Repository<Operation>>();

            s.AddScoped<IOperationService, OperationService>();
            
            s.AddDbContext<DataContext>();

		}
	}
}