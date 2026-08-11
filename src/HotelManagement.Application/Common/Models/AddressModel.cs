using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Common.Models;

/// <summary>
/// Represents an address.
/// </summary>
public sealed class AddressModel
{
    public required string AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string Country { get; init; }
    public required string PostalCode { get; init; }
}
