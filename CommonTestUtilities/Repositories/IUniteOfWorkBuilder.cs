using CashFlow.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;
public class IUniteOfWorkBuilder
{
    public static IUniteOfWork Build()
    {
        var mock = new Mock<IUniteOfWork>();
        
        return mock.Object;

    }
}
