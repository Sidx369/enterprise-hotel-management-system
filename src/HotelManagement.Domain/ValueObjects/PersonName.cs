using HotelManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.ValueObjects;

/// <summary>
/// Represents a person's full name.
/// </summary>
public sealed class PersonName : ValueObject
{
    private const int NameMaxLength = 100;

    public PersonName(
        string firstName,
        string lastName)
    {
        Guard.AgainstNullOrWhiteSpace(firstName, nameof(firstName));
        Guard.AgainstNullOrWhiteSpace(lastName, nameof(lastName));

        firstName = firstName.Trim();
        lastName = lastName.Trim();

        Guard.AgainstMaxLength(firstName, NameMaxLength, nameof(firstName));
        Guard.AgainstMaxLength(lastName, NameMaxLength, nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public string FullName => $"{FirstName} {LastName}";

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}
