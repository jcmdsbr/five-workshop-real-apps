using System.ComponentModel.DataAnnotations;
using Five.Bank.Domain.ValueObjects.v1;

namespace Five.Bank.Api.Models.v1;

public class CustomerInputModel
{
    [Required] public string? Name { get; set; }

    [Required] public string? Document { get; set; }

    public DateTime Birthday { get; set; }

    public Address? Address { get; set; }
}