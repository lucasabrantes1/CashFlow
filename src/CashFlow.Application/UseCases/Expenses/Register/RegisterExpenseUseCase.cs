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
        var titleIsEmpty = string.IsNullOrEmpty(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than zero");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if(result > 0)
        {
            throw new ArgumentException("Expenses cannot be for the future");
        }



        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (paymentTypeIsValid == false) 
        {
            throw new ArgumentException("Payment Type is not valid");
        }



    }
}
