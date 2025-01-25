using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enum;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using Shouldly;
using Xunit;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Error_Title_Empty()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        request.Title = string.Empty;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);
    }

    [Fact]
    public void Error_Date_Future()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        request.Date = DateTime.Now.AddDays(1); // Data futura

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE);
    }

    [Fact]
    public void Error_PaymentType_Invalid()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)700; // Tipo inválido

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }

    [Theory]
    [InlineData(0)]   // Valor inválido: zero
    [InlineData(-1)]  // Valor inválido: negativo
    [InlineData(-10)] // Valor inválido: negativo
    public void Error_Amount_Invalid(decimal amount)
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        request.Amount = amount;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
    }
}

