using HotelManagement.Domain.Entities;
using HotelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Events.Booking;

/// <summary>
/// Raised when a new booking is created.
/// </summary>
public sealed record BookingCreatedDomainEvent(
    Guid BookingId,
    Guid RoomId,
    Guid CustomerId,
    BookingPeriod BookingPeriod,
    Money TotalAmount)
    : IDomainEvent;