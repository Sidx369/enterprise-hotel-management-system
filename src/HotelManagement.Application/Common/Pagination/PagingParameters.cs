using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Common.Pagination;

/// <summary>
/// Represents paging parameters.
/// </summary>
public class PagingParameters
{
    private const int MaxPageSize = 100;

    private int _pageNumber = 1;
    private int _pageSize = 10;

    public int PageNumber
    {
        get => _pageNumber;
        init => _pageNumber = value < 1 ? 1 : value;
    }

    public  int PageSize
    {
        get => _pageSize;
        init => _pageSize =
            value switch
            {
                < 1 => 10,
                > MaxPageSize => MaxPageSize,
                _ => value
            };
    }
}
