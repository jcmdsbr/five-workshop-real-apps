using _5by5.InterAction.Sample.Domain.Entities.v1;

namespace _5by5.InterAction.Sample.UnitTests.Mocks.Entities.v1;
public static class CustomerMock
{
    public static Customer GetSuccessMock() =>
        new() { Name = "Leonardo", Document = "123.321.123-01", Birthday = new DateTime(1995, 5, 5), Address = new Domain.ValueObjects.v1.Address("123123", "Rua X", "123", string.Empty, "Araraquara", "SP") };
}