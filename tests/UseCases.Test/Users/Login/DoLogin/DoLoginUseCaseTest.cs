﻿using CashFlow.Application.UseCases.Login.DoLogin;
using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace UseCases.Test.Users.Register;
public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {   

        var user = UserBuilder.Build();

        var request = RequestLoginJsonBuilder.Build();
        var useCase = CreateUseCase(user);

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(user.Name);
        result.Token.Should().NotBeNullOrWhiteSpace();
    }

    //[Fact]
    //public async Task Error_User_Not_Found()
    //{
    //    var request = RequestRegisterUserJsonBuilder.Build();
    //    request.Name = string.Empty;

    //    var useCase = CreateUseCase();

    //    var act = async () => await useCase.Execute(request);

    //    var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

    //    result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.NAME_EMPTY));
    //}

    //[Fact]
    //public async Task Error_Password_Not_Match()
    //{
    //    var request = RequestRegisterUserJsonBuilder.Build();

    //    var useCase = CreateUseCase(request.Email);

    //    var act = async () => await useCase.Execute(request);

    //    var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

    //    result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
    //}

    private DoLoginUseCase CreateUseCase(CashFlow.Domain.Entities.User user)
    {
        var passwordEncripter = PasswordEncripterBuilder.Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();


        return new DoLoginUseCase(readRepository, passwordEncripter, tokenGenerator);

    }
}
