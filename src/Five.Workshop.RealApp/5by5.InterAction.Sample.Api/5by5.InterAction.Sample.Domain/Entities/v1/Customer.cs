using System.Text.RegularExpressions;
using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.ValueObjects.v1;

namespace _5by5.InterAction.Sample.Domain.Entities.v1;

public sealed class Customer(Guid id, string name, string document, DateTime birthday, Address? address) : IEntity<Guid>
{
    public Customer(string name, string document, DateTime birthday, Address? address) : this(Guid.NewGuid(), name, document, birthday, address)
    {
    }

    public string Name { get; init; } = name;
    public string Document { get; init; } = document;
    public DateTime Birthday { get; init; } = birthday;
    public Address? Address { get; init; } = address;

    public Guid Id { get; set; } = id;

}