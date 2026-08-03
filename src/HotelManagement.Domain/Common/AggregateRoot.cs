using HotelManagement.Domain.Events;
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
    private List<IDomainEvent>? _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents
        => _domainEvents?.AsReadOnly() ?? Array.Empty<IDomainEvent>().AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        Guard.AgainstNull(domainEvent, nameof(domainEvent));
        _domainEvents ??= [];

        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}