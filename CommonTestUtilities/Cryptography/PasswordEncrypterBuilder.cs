using CashFlow.Domain.Security.Criptography;
using Moq;

namespace CommonTestUtilities.Cryptography;

public class PasswordEncrypterBuilder
{
    private readonly Mock<IPasswordEncripter> _mock;

    public PasswordEncrypterBuilder()
    {
        _mock = new Mock<IPasswordEncripter>();

        _mock.Setup(passwordEncripter => passwordEncripter.Encrypt(It.IsAny<string>()))
             .Returns("!%dlfjkd5");
    }

    public PasswordEncrypterBuilder Verify(string password)
    {   
        _mock.Setup(PasswordEncripter => PasswordEncripter.Verify(password, It.IsAny<string>())).Returns(true);
        return this;
    }

    public IPasswordEncripter Build() => _mock.Object;
}
