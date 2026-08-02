using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Common;

/// <summary>
/// Represents a domain event raised by an aggregate root.
/// </summary>
public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}
