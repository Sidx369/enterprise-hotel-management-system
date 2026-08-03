using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Common.Pagination;

/// <summary>
/// Represents a paginated response.
/// </summary>
/// <typeparam name="T">Type of item.</typeparam>
public sealed class PagedResult<T>
{
    public required IReadOnlyCollection<T> Items { get; init; }

    public required int PageNumber { get; init; }

    public required int PageSize { get; init; }

    public required int TotalCount { get; init; }

    public int TotalPages =>
        (int)Math.Ceiling((double)TotalCount / PageSize);

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;
}
