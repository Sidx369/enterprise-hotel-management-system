using HotelManagement.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Contracts.Requests;

/// <summary>
/// Request for updating a hotel.
/// </summary>
public sealed class UpdateHotelRequest : IHotelRequest
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public required AddressModel Address { get; init; }
    public int StarRating { get; init; }
}
