using CashFlow.Communication.Requests;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}
