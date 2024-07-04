using _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;

namespace _5by5.InterAction.Sample.UnitTests.Mocks.Commands.v1;
public static class CreateCustomerCommandMock
{
    public static CreateCustomerCommand GetSuccessMock() =>
        new() { Name = "Leonardo", Document = "123.321.123-01", Birthday = new DateTime(1995, 5, 5), Address = new Domain.ValueObjects.v1.Address("123123", "Rua X", "123", string.Empty, "Araraquara", "SP") };

    public static CreateCustomerCommand GetNameFailMock() =>
        new() { Name = string.Empty, Document = "123.321.123-01", Birthday = new DateTime(1995, 5, 5), Address = new Domain.ValueObjects.v1.Address("123123", "Rua X", "123", string.Empty, "Araraquara", "SP") };

    //public static CreateCustomerCommand GetBirthDayInvalidMock() =>
    //    .RuleFor(fake => fake.Birthday)
}