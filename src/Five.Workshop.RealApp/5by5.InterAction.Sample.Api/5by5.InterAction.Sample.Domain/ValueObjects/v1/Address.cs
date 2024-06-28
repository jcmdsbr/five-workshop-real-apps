namespace _5by5.InterAction.Sample.Domain.ValueObjects.v1;

public record Address(
    string ZipCode,
    string Street,
    string Number,
    string Neighborhood,
    string City,
    string State);