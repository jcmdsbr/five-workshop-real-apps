using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Specifications.v1;
using Five.Bank.Domain.ValueObjects.v1;

namespace Five.Bank.Domain.Entities.v1;

public sealed class Customer(Guid id, string name, string document, DateTime birthday, Address? address) : IEntity<Guid>
{
    public Customer(string name, string document, DateTime birthday, Address? address) : this(Guid.NewGuid(), name,
        document, birthday, address)
    {
    }

    public string Name { get; init; } = name;
    public string Document { get; init; } = document;
    public DateTime Birthday { get; init; } = birthday;
    public Address? Address { get; init; } = address;

    public Guid Id { get; set; } = id;


    public bool Validate()
    {
        var documentSpecification = new DocumentAlgorithmSpecification(Document);
        var birthdaySpecification = new CustomerMajoritySpecification(Birthday);
        return documentSpecification.IsSatisfied() && birthdaySpecification.IsSatisfied();
    }
}