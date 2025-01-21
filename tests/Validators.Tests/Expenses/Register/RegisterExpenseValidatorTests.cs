using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using Xunit;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterexpenseJson
        {
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Description = "description",
            Title = "Apple",
            PaymentType = CashFlow.Communication.Enum.PaymentType.CreditCard
        };


        //Act
        var result = validator.Validate(request);


        //Assert
        Assert.True(result.IsValid);
    }

}