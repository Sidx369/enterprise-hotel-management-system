using HotelManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Entities;

/// <summary>
/// Represents a room classification such as Standard, Deluxe or Suite.
/// Aggregate Root.
/// </summary>
public sealed class RoomType : AuditableEntity
{
    private const int NameMaxLength = 100;
    private const int DescriptionMaxLength = 500;

    private RoomType()
    {
        
    }

    public RoomType(
        string name,
        short maxOccupancy,
        string? description = null)
    {
        Guard.AgainstNullOrWhiteSpace(name, nameof(name));
        Guard.AgainstOutOfRange(maxOccupancy, (short)1, (short)20, nameof(maxOccupancy));

        name = name.Trim();

        Guard.AgainstMaxLength(name, NameMaxLength, nameof(name));

        if (!string.IsNullOrWhiteSpace(description))
        {
            description = description.Trim();
            Guard.AgainstMaxLength(description, DescriptionMaxLength, nameof(description));
        }

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        MaxOccupancy = maxOccupancy;
        IsActive = true;
    }

    /// <summary>
    /// Gets the room type name.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the room type description.
    /// </summary>
    public string? Description { get; private set; }

    /// <summary>
    /// Gets the maximum supported occupancy.
    /// </summary>
    public short MaxOccupancy { get; private set; }

    /// <summary>
    /// Gets whether this room type can be assigned to rooms.
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Renames the room type.
    /// </summary>
    public void Rename(string name)
    {
        Guard.AgainstNullOrWhiteSpace(name, nameof(name));
        name = name.Trim();

        Guard.AgainstMaxLength(name, NameMaxLength, nameof(name));
        Name = name;
    }

    /// <summary>
    /// Updates the room type description.
    /// </summary>
    public void UpdateDescription(string? description)
    {
        if (!string.IsNullOrWhiteSpace(description))
        {
            description = description.Trim();

            Guard.AgainstMaxLength(
                description,
                DescriptionMaxLength,
                nameof(description));
        }

        Description = description;
    }

    /// <summary>
    /// Updates the maximum occupancy.
    /// </summary>
    public void ChangeMaximumOccupancy(short maxOccupancy)
    {
        Guard.AgainstOutOfRange(
            maxOccupancy,
            (short)1,
            (short)20,
            nameof(maxOccupancy));

        MaxOccupancy = maxOccupancy;
    }

    /// <summary>
    /// Marks the room type as active.
    /// </summary>
    public void Activate()
    {
        IsActive = true;
    }

    /// <summary>
    /// Marks the room type as inactive.
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
    }
}
