using HotelManagement.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Contracts.Responses;

/// <summary>
/// Hotel response.
/// </summary>
public sealed class HotelResponse
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? Email {  get; init; }
    public string? PhoneNumber { get; init; }
    public required AddressModel Address { get; init; }
    public int StarRating { get; init; }
    public bool IsActive { get; init; }
    public byte[] RowVersion { get; init; } = [];
}
