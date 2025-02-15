﻿using CashFlow.Application.UseCases.Users.Register;
using CommonTestUtilities.Requests;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace UseCases.Test.Users.Register;
public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase();

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
        result.Token.Should().NotBeNullOrWhiteSpace();
    }

    private RegisterUserUseCase CreateUseCase()
    {
        return new RegisterUserUseCase();

    }
}
