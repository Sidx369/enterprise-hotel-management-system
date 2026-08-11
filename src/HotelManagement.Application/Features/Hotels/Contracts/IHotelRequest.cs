using HotelManagement.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Contracts;

/// <summary>
/// Defines common properties required by hotel requests.
/// </summary>
public interface IHotelRequest
{
    string Name { get; }

    string? Description { get; }

    string? Email { get; }

    string? PhoneNumber { get; }

    AddressModel Address { get; }

    int StarRating { get; }
}
