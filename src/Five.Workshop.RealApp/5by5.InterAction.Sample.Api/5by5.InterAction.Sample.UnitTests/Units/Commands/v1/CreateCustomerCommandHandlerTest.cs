using _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Entities.v1;
using _5by5.InterAction.Sample.UnitTests.Mocks.Commands.v1;
using _5by5.InterAction.Sample.UnitTests.Mocks.Entities.v1;
using AutoMapper;
using Moq;
using Xunit;

namespace _5by5.InterAction.Sample.UnitTests.Units.Commands.v1;
public sealed class CreateCustomerCommandHandlerTest
{
    private readonly Mock<ICustomerRepository> _customerRepository = new();
    private readonly Mock<IMapper> _mapper = new();
    private readonly Mock<IDomainNotificationService> _domainNotificationService = new();

    private CreateCustomerCommandHandler EstablishContext()
    {
        return new CreateCustomerCommandHandler(
            _customerRepository.Object,
            _mapper.Object,
            _domainNotificationService.Object);
    }

    [Fact(DisplayName = "Deve retornar sucesso quando inserção concluída com êxito")]
    public async Task ShouldSuccessReturnWhenInputIsValid()
    {
        var handler = EstablishContext();
        var command = CreateCustomerCommandMock.GetSuccessMock();

        _customerRepository.Setup(rep => rep.AddAsync(It.IsAny<Customer>(), CancellationToken.None)).Returns(Task.CompletedTask);
        _mapper.Setup(map => map.Map<CreateCustomerCommand, Customer>(It.IsAny<CreateCustomerCommand>())).Returns(CustomerMock.GetSuccessMock());
        _mapper.Setup(map => map.Map<CreateCustomerCommandResponse>(It.IsAny<Customer>())).Returns(CreateCustomerCommandResponseMock.GetSuccessMock());

        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response?.Id);
    }
}