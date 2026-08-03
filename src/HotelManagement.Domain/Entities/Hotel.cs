using HotelManagement.Domain.Common;
using HotelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Entities;

/// <summary>
/// Represents a hotel.
/// Aggregate Root.
/// </summary>
public sealed class Hotel : AuditableEntity
{
    private Hotel()
    {
        // Required by EF Core.
    }

    public Hotel(HotelDetails details)
    {
        Guard.AgainstNull(details, nameof(details));

        Id = Guid.CreateVersion7();
        Details = details;
        IsActive = true;
    }

    public HotelDetails Details { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public void UpdateDetails(HotelDetails details)
    {
        Guard.AgainstNull(details, nameof(details));

        Details = details;
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
