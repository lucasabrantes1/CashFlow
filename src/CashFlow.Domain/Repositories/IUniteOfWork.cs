namespace CashFlow.Domain.Repositories;
public interface IUniteOfWork
{
    Task Commit();
}
