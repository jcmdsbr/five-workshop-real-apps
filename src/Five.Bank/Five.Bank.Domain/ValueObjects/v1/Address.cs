namespace Five.Bank.Domain.ValueObjects.v1;

public record Address(
    string ZipCode,
    string Street,
    string Number,
    string Neighborhood,
    string City,
    string State);