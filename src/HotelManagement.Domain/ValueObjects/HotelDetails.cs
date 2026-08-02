using HotelManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.ValueObjects;

/// <summary>
/// Represents the descriptive information of a hotel.
/// </summary>
public sealed class HotelDetails : ValueObject
{
    private const int NameMaxLength = 200;
    private const int DescriptionMaxLength = 1000;
    private const int EmailMaxLength = 256;
    private const int PhoneNumberMaxLength = 25;

    public string Name { get; }
    public string? Description { get; }
    public string? Email { get; }
    public string? PhoneNumber { get; }
    public Address Address { get; }
    public int StarRating { get; }

    public HotelDetails(
        string name,
        Address address,
        int starRating,
        string? description = null,
        string? email = null,
        string? phoneNumber = null)
    {
        Guard.AgainstNull(address, nameof(address));
        Guard.AgainstNullOrWhiteSpace(name, nameof(name));

        name = name.Trim();

        Guard.AgainstMaxLength(name, NameMaxLength, nameof(name));
        Guard.AgainstOutOfRange(starRating, 1, 5, nameof(starRating));

        if (!string.IsNullOrWhiteSpace(description))
        {
            description = description.Trim();
            Guard.AgainstMaxLength(description, DescriptionMaxLength, nameof(description));
        }

        if (!string.IsNullOrWhiteSpace(@email))
        {
            email = email.Trim();
            
            Guard.AgainstMaxLength(email, EmailMaxLength, nameof(email));
            Guard.AgainstInvalidEmail(email, nameof(email));
        }

        if (!string.IsNullOrWhiteSpace(phoneNumber))
        {
            phoneNumber = phoneNumber.Trim();
            Guard.AgainstMaxLength(phoneNumber, PhoneNumberMaxLength, nameof(phoneNumber));
        }

        Name = name;
        Address = address;
        StarRating = starRating;
        Description = description;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return Description;
        yield return Email;
        yield return PhoneNumber;
        yield return Address;
        yield return StarRating;
    }
}
