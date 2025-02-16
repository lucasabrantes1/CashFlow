using CashFlow.Application.UseCases.Users.Register;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
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
        var mapper = MapperBuilder.Build();
        var uniteOfWork = IUniteOfWorkBuilder.Build();
        var writeRepository = IUserWriteOnlyRepositoryBuilder.Build();
        var passwordEncripter = PasswordEncripterBuilder.Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();


        return new RegisterUserUseCase(mapper, passwordEncripter, null, writeRepository, tokenGenerator, uniteOfWork);
    }
}
