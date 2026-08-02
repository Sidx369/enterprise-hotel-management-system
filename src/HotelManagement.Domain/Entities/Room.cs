using HotelManagement.Domain.Common;
using HotelManagement.Domain.Enums;
using HotelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Entities;

/// <summary>
/// Represents a physical room within a hotel.
/// Aggregate Root.
/// </summary>
public sealed class Room : AuditableEntity
{
    private const int RoomNumberMaxLength = 20;

    public Room()
    {
        //Required for EF Core
    }

    public Room(
        Guid hotelId,
        Guid roomTypeId,
        string roomNumber,
        short maximumOccupancy,
        Money pricePerNight)
    {
        Guard.AgainstEmptyGuid(hotelId, nameof(hotelId));
        Guard.AgainstEmptyGuid(roomTypeId, nameof(roomTypeId));
        Guard.AgainstNull(pricePerNight, nameof(pricePerNight));
        Guard.AgainstNullOrWhiteSpace(roomNumber, nameof(roomNumber));

        roomNumber = roomNumber.Trim();

        Guard.AgainstMaxLength(
            roomNumber,
            RoomNumberMaxLength,
            nameof(roomNumber));

        Guard.AgainstOutOfRange(
            maximumOccupancy,
            (short)1,
            (short)20,
            nameof(maximumOccupancy));

        Id = Guid.NewGuid();
        HotelId = hotelId;
        RoomTypeId = roomTypeId;
        RoomNumber = roomNumber;
        MaximumOccupancy = maximumOccupancy;
        PricePerNight = pricePerNight;

        Status = RoomStatus.Available;
        IsActive = true;
    }

    /// <summary>
    /// Gets the owning hotel identifier.
    /// </summary>
    public Guid HotelId { get; private set; }

    /// <summary>
    /// Gets the room type identifier.
    /// </summary>
    public Guid RoomTypeId { get; private set; }

    /// <summary>
    /// Gets the room number.
    /// </summary>
    public string RoomNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the maximum allowed occupancy.
    /// </summary>
    public short MaximumOccupancy { get; private set; }

    /// <summary>
    /// Gets the nightly room price.
    /// </summary>
    public Money PricePerNight { get; private set; } = null!;

    /// <summary>
    /// Gets the operational room status.
    /// </summary>
    public RoomStatus Status { get; private set; }

    /// <summary>
    /// Gets whether the room is active.
    /// </summary>
    public bool IsActive { get; private set; }

    public void ChangeRoomType(Guid roomTypeId)
    {
        Guard.AgainstEmptyGuid(roomTypeId, nameof(roomTypeId));

        RoomTypeId = roomTypeId;
    }
    
    public void ChangeRoomNumber(string roomNumber)
    {
        Guard.AgainstNullOrWhiteSpace(roomNumber, nameof(roomNumber));

        roomNumber = roomNumber.Trim();

        Guard.AgainstMaxLength(
            roomNumber,
            RoomNumberMaxLength,
            nameof(roomNumber));

        RoomNumber = roomNumber;
    }

    public void ChangeMaximumOccupancy(short maximumOccupancy)
    {
        Guard.AgainstOutOfRange(
            maximumOccupancy,
            (short)1,
            (short)20,
            nameof(maximumOccupancy));

        MaximumOccupancy = maximumOccupancy;
    }

    public void ChangePrice(Money price)
    {
        Guard.AgainstNull(price, nameof(price));
        PricePerNight = price;
    }

    public void MarkAvailable()
    {
        Status = RoomStatus.Available;
    }

    public void MarkOccupied()
    {
        Status = RoomStatus.Occupied;
    }

    public void MarkCleaning()
    {
        Status = RoomStatus.Cleaning;
    }

    public void MarkMaintenance()
    {
        Status = RoomStatus.Maintenance;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}
