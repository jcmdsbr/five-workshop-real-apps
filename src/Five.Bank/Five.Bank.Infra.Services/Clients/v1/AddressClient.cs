using System.Text.Json;
using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.ValueObjects.v1;

namespace Five.Bank.Infra.Services.Clients.v1;

public class AddressClient : IAddressClient
{
    private readonly HttpClient _httpClient;

    public AddressClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Address?> GetByZipCode(string? zipCode)
    {
        if (string.IsNullOrEmpty(zipCode)) return null;

        var httpResponse = await _httpClient.GetStringAsync($"{zipCode}/json");
        var addressResponse = JsonSerializer.Deserialize<AddressClientResponse>(httpResponse);

        if (addressResponse is null) return null;

        var address = new Address(
            addressResponse.ZipCode,
            addressResponse.Street,
            addressResponse.Neighborhood,
            addressResponse.City,
            addressResponse.State);

        return address;
    }
}