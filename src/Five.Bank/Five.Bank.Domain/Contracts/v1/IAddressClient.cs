using Five.Bank.Domain.ValueObjects.v1;

namespace Five.Bank.Domain.Contracts.v1;

public interface IAddressClient
{
    Task<Address?> GetByZipCode(string? zipCode);
}