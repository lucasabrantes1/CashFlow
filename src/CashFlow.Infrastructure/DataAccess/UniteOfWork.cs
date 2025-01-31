using CashFlow.Domain.Repositories;

namespace CashFlow.Infrastructure.DataAccess;
internal class UniteOfWork : IUniteOfWork
{
    private readonly CashFlowDbContext _dbContext;
    public UniteOfWork(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
