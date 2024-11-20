using Bank.Core.Entities;
using Bank.Data;
using Bank.Data.Repositories;
using Bank.Service;
using Bank.Core.InterfaceRepository;
using Bank.Core.InterfaceService;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Bank.Api
{
    public static class eExteshin
    {
        public static void ServieDependencyInjector(this IServiceCollection s)
        {
            s.AddScoped<IRepository<Account>, AccountRepository>();
            s.AddScoped<IService<Account>, AccountService>();
            s.AddScoped<IRepository<CreditCard>, CreditCardRepository>();
            s.AddScoped<IService<CreditCard>, CreditCardService>();
            s.AddScoped<IRepository<Loan>, LoanRepository>();
            s.AddScoped<IService<Loan>, LoanService>();
            s.AddScoped<IRepository<Customer>, CustomerRepository>();
            s.AddScoped<IService<Customer>, CustomerService>();
            s.AddScoped<IRepository<Operation>, OperationRepository>();
            s.AddScoped<IService<Operation>, OperationService>();
            s.AddSingleton<DataContext>();

        }
    }
}
