using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);

    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CashFlowDbContext>();
    }
}
