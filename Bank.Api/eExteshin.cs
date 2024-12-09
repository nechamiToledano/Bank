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

            s.AddScoped<IAccountService, AccountService>();
            s.AddScoped<ICustomerService, CustomerService>();
            s.AddScoped<ICreditCardService, CreditCardService>();
            s.AddScoped<ILoanService, LoanService>();
            s.AddScoped<IOperationService, OperationService>();

            s.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            s.AddScoped(typeof(IRepositManger<>), typeof(RepositManager<>));
            s.AddDbContext<DataContext>();

		}
	}
}