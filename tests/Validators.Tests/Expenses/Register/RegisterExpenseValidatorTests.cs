﻿using CashFlow.Application.UseCases.Expenses.Register;
using CommonTestUtilities.Requests;

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
        Assert.True(result.IsValid);
    }

}