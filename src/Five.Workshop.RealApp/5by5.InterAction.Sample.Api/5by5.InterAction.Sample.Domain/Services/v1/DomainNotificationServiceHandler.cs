using System.Collections.Immutable;
using _5by5.InterAction.Sample.Domain.Contracts.v1;

namespace _5by5.InterAction.Sample.Domain.Services.v1;

public sealed class DomainNotificationServiceHandler : IDomainNotificationService
{
    private readonly List<string> _notifications = [];

    private bool _disposed;
    
    public bool HasNotification => _notifications.Count > 0;

    public void Add(string message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(message);

        _notifications.Add(message);
    }

    public void AddRange(IEnumerable<string> messages)
    {
       _notifications.AddRange(messages);
    }

    public IReadOnlyList<string> Get()
    {
        return _notifications.ToImmutableList();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~DomainNotificationServiceHandler()
    {
        Dispose(false);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            _notifications.Clear();
        }
        
        _disposed = true;
    }
}