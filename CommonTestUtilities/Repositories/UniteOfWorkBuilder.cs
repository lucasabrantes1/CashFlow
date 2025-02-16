using CashFlow.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;
public class UniteOfWorkBuilder
{
    public static IUniteOfWork Build()
    {
        var mock = new Mock<IUniteOfWork>();
        
        return mock.Object;

    }
}
