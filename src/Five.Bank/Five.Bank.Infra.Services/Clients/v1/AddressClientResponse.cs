using System.Text.Json.Serialization;

namespace Five.Bank.Infra.Services.Clients.v1;

public class AddressClientResponse
{
    [JsonPropertyName("cep")]
    public string? ZipCode { get; set; }
    
    [JsonPropertyName("logradouro")]
    public string? Street { get; set; }
    
    [JsonPropertyName("bairro")]
    public string? Neighborhood { get; set; }
    
    [JsonPropertyName("localidade")]
    public string? City { get; set; }
    
    [JsonPropertyName("uf")]
    public string? State { get; set; }
}