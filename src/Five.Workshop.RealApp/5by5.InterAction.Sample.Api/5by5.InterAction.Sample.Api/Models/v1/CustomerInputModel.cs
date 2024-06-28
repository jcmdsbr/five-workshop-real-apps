using _5by5.InterAction.Sample.Domain.ValueObjects.v1;

namespace _5by5.InterAction.Sample.Api.Models.v1;

public record CustomerInputModel
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public Address? Address { get; set; }
}