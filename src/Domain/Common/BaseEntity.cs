using System.ComponentModel.DataAnnotations.Schema;

namespace HomeApi.Domain.Common;

public abstract class BaseEntity<T> : IEntity
    where T : IStronglyTypedId
{
    public T? Id { get; set; }

    private readonly List<BaseDomainEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
