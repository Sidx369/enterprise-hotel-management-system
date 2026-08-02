using HotelManagement.Domain.Common;
using HotelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace HotelManagement.Domain.Entities;

/// <summary>
/// Represents a hotel customer.
/// Aggregate Root.
/// </summary>
public sealed class Customer : AuditableEntity
{
    private Customer()
    {
        // Required by EF Core
    }

    public Customer(
        PersonName name,
        string email,
        string phoneNumber,
        Address address)
    {
        Guard.AgainstNull(name, nameof(name));
        Guard.AgainstNull(address, nameof(address));
        Guard.AgainstNullOrWhiteSpace(email, nameof(email));
        Guard.AgainstNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));

        email = email.Trim();
        phoneNumber = phoneNumber.Trim();

        Guard.AgainstInvalidEmail(email, nameof(email));

        Id = Guid.CreateVersion7();

        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;

        IsActive = true;
    }

    public PersonName Name { get; private set; } = null!;

    public string Email { get; private set; } = string.Empty;

    public string PhoneNumber { get; private set; } = string.Empty;

    public Address Address { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public void UpdateName(PersonName name)
    {
        Guard.AgainstNull(name, nameof(name));
        Name = name;
    }

    public void UpdateEmail(string email)
    {
        Guard.AgainstNullOrWhiteSpace(email, nameof(email));

        email = email.Trim();

        Guard.AgainstInvalidEmail(email, nameof(email));

        Email = email;
    }

    public void UpdatePhoneNumber(string phoneNumber)
    {
        Guard.AgainstNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));

        PhoneNumber = phoneNumber.Trim();
    }

    public void UpdateAddress(Address address)
    {
        Guard.AgainstNull(address, nameof(address));

        Address = address;
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
