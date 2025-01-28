using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);

    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 35);
        var serverVersion = new MySqlServerVersion(new Version());

        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));

    }
}
