using _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;

namespace _5by5.InterAction.Sample.UnitTests.Mocks.Commands.v1;
public static class CreateCustomerCommandResponseMock
{
    public static CreateCustomerCommandResponse GetSuccessMock() =>
        new() { Id = Guid.NewGuid(), Name = "Leonardo" };
}