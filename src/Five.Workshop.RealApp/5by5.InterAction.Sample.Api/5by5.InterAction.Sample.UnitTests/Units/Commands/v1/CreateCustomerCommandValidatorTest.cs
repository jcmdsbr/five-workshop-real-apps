using _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
using _5by5.InterAction.Sample.UnitTests.Mocks.Commands.v1;
using FluentValidation.Results;
using Xunit;

namespace _5by5.InterAction.Sample.UnitTests.Units.Commands.v1;
public sealed class CreateCustomerCommandValidatorTest
{
    private static ValidationResult EstablishContext(CreateCustomerCommand command) =>
        new CreateCustomerCommandValidator().Validate(command);

    [Fact(DisplayName = "Deve retornar válido quando request estiver correto")]
    public void ShoulSuccessWhenRequestIsValid()
    {
        var command = CreateCustomerCommandMock.GetSuccessMock();
        var result = EstablishContext(command);

        Assert.True(result.IsValid);
    }

    [Fact(DisplayName = "Deve retornar inválido quando nome não for preenchido")]
    public void ShoulNameNotificationWhenNameIsInvalid()
    {
        var command = CreateCustomerCommandMock.GetNameFailMock();
        var result = EstablishContext(command);

        Assert.False(result.IsValid); // Aqui da pra melhorar e conferir com a mensagem especifica do nome
    }

    // TODO construir para data de nascimento!!!
}