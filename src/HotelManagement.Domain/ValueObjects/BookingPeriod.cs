using HotelManagement.Domain.Common;
using HotelManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.ValueObjects;

/// <summary>
/// Represents the duration of a hotel booking.
/// </summary>
public sealed class BookingPeriod : ValueObject
{
    public BookingPeriod(
        DateOnly checkInDate,
        DateOnly checkOutDate)
    {
        if(checkOutDate <= checkInDate)
        {
            throw new DomainException(
                "Check-out date must be after check-in date.");
        }

        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
    }

    /// <summary>
    /// Gets the check-in date.
    /// </summary>
    public DateOnly CheckInDate { get; }

    /// <summary>
    /// Gets the check-out date.
    /// </summary>
    public DateOnly CheckOutDate { get; }

    /// <summary>
    /// Gets the total number of nights.
    /// </summary>
    public int NumberOfNights =>
        CheckOutDate.DayNumber - CheckInDate.DayNumber;

    /// <summary>
    /// Determines whether this booking overlaps another booking.
    /// </summary>
    public bool Overlaps(BookingPeriod other)
    {
        Guard.AgainstNull(other, nameof(other));

        return CheckInDate < other.CheckOutDate
            && CheckOutDate > other.CheckInDate;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CheckInDate;
        yield return CheckOutDate;
    }
}
