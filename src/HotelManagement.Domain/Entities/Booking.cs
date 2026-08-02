using HotelManagement.Domain.Common;
using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Exceptions;
using HotelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Entities;

/// <summary>
/// Represents a room reservation.
/// Aggregate Root.
/// </summary>
public sealed class Booking : AuditableEntity
{
    private const int SpecialRequestMaxLength = 1000;

    private Booking()
    {
        // Required by EF Core
    }

    public Booking(
        Guid roomId,
        Guid customerId,
        BookingPeriod bookingPeriod,
        short numberOfGuests,
        Money totalAmount,
        string? specialRequests = null)
    {
        Guard.AgainstEmptyGuid(roomId, nameof(roomId));
        Guard.AgainstEmptyGuid(customerId, nameof(customerId));
        Guard.AgainstNull(bookingPeriod, nameof(bookingPeriod));
        Guard.AgainstNull(totalAmount, nameof(totalAmount));
        Guard.AgainstOutOfRange(
            numberOfGuests,
            (short)1,
            (short)20,
            nameof(numberOfGuests));

        if (!string.IsNullOrWhiteSpace(specialRequests))
        {
            specialRequests = specialRequests.Trim();

            Guard.AgainstMaxLength(
                specialRequests,
                SpecialRequestMaxLength,
                nameof(specialRequests));
        }

        Id = Guid.CreateVersion7();

        RoomId = roomId;
        CustomerId = customerId;
        BookingPeriod = bookingPeriod;
        NumberOfGuests = numberOfGuests;
        TotalAmount = totalAmount;
        SpecialRequests = specialRequests;
        Status = BookingStatus.Pending;
    }

    public Guid RoomId { get; private set; }

    public Guid CustomerId { get; private set; }

    public BookingPeriod BookingPeriod { get; private set; } = null!;

    public short NumberOfGuests { get; private set; }

    public Money TotalAmount { get; private set; } = null!;

    public string? SpecialRequests { get; private set; }

    public BookingStatus Status { get; private set; }

    public void Confirm()
    {
        if (Status != BookingStatus.Pending)
            throw new DomainException(
                "Only pending booknig can be confirmed.");

        Status = BookingStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == BookingStatus.CheckedOut)
        {
            throw new DomainException(
                "A checked-out booking cannot be cancelled.");
        }

        Status = BookingStatus.Cancelled;
    }

    public void CheckIn()
    {
        if (Status != BookingStatus.Confirmed)
        {
            throw new DomainException(
                "Only confirmed bookings can be checked in.");
        }

        Status = BookingStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if (Status != BookingStatus.CheckedIn)
        {
            throw new DomainException(
                "Only checked-in bookings can be checked out.");
        }

        Status = BookingStatus.CheckedOut;
    }

    public void UpdateSpecialRequests(string? specialRequests)
    {
        if (!string.IsNullOrWhiteSpace(specialRequests))
        {
            specialRequests = specialRequests.Trim();

            Guard.AgainstMaxLength(
                specialRequests,
                SpecialRequestMaxLength,
                nameof(specialRequests));
        }

        SpecialRequests = specialRequests;
    }
}
