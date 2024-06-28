namespace Five.Bank.Domain.Dtos.v1;

public record Response
{
    public object? Content { get; init; }

    public static long Timestamp => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

    public string? TraceId { get; set; }

    public IReadOnlyList<string>? Notifications { get; set; } = new List<string>();

    public static Response None => new();
}