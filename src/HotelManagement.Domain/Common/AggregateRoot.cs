using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HotelManagement.Domain.Common;

/// <summary>
/// Base class for all aggregate roots.
/// Supports domain events.
/// </summary>
public abstract class AggregateRoot : BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents
        => new ReadOnlyCollection<IDomainEvent>(_domainEvents);

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        Guard.AgainstNull(domainEvent, nameof(domainEvent));

        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}