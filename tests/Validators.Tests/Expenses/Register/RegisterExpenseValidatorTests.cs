using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enum;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();


        //Act
        var result = validator.Validate(request);


        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("           ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);


        //Assert
        result.IsValid.ShouldBeFalse();
        //FluentAssertion Syntax
        // result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));

        // shoundly syntax
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);

    }

    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        //request.Title = string.Empty;
        request.Date = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);


        //Assert
        result.IsValid.ShouldBeFalse();
        //FluentAssertion Syntax
        // result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));

        // shoundly syntax
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE);

    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        //request.Title = string.Empty;
        request.PaymentType = (PaymentType)700;

        //Act
        var result = validator.Validate(request);


        //Assert
        result.IsValid.ShouldBeFalse();
        //FluentAssertion Syntax
        // result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));

        // shoundly syntax
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-7)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterexpenseJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);


        //Assert
        result.IsValid.ShouldBeFalse();
        //FluentAssertion Syntax
        // result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));

        // shoundly syntax
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }

}