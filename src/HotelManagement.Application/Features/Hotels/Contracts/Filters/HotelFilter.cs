using HotelManagement.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Contracts.Filters;

/// <summary>
/// Hotel filtering.
/// </summary>
public sealed class HotelFilter : PagingParameters
{
    public string? Name { get; init; }
    public string? City { get; init; }
    public bool? IsActive { get; init; }
    public string? SortBy { get; init; }
    public bool Descending { get; init; }
}
