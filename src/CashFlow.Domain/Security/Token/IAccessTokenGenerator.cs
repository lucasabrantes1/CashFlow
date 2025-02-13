using CashFlow.Domain.Entities;

namespace CashFlow.Infrastructure.Security.Token;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
