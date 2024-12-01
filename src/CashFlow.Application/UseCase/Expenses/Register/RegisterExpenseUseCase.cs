using CashFlow.Communication.Requests;


namespace CashFlow.Application.UseCase.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        return new ResponseRegisteredExpenseJson();
    }
}
