using CashFlow.Communication.Enum;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{ 

    public ResponseRegisteredExpenseJson Execute(RequestRegisterexpenseJson request)
    {
        
        Validate(request);
        return new ResponseRegisteredExpenseJson();
    }


    private void Validate(RequestRegisterexpenseJson request)
    {

        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);   
    }
}
