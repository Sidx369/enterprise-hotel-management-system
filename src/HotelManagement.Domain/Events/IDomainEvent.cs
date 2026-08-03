using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Events;

/// <summary>
/// Represents a domain event raised by an aggregate root.
/// </summary>
public interface IDomainEvent : INotification
{
    //DateTime OccurredOnUtc { get; }
}
