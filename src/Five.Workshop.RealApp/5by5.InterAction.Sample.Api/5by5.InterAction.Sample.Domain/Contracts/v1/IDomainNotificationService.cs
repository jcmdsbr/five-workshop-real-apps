namespace _5by5.InterAction.Sample.Domain.Contracts.v1;

public interface IDomainNotificationService : IDisposable
{
    bool HasNotification { get; }
    void Add(string message);
    void AddRange(IEnumerable<string> messages);
    IReadOnlyList<string>? Get();
}