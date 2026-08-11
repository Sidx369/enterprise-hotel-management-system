using HotelManagement.Application.Common.Pagination;
using HotelManagement.Application.Features.Hotels.Contracts.Filters;
using HotelManagement.Application.Features.Hotels.Contracts.Requests;
using HotelManagement.Application.Features.Hotels.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Interfaces;

/// <summary>
/// Hotel application service.
/// </summary>
public interface IHotelService
{
    Task<HotelResponse> CreateAsync(
        CreateHotelRequest request,
        CancellationToken cancellationToken = default);

    Task<HotelResponse> UpdateAsync(
        Guid hotelId,
        UpdateHotelRequest request,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default);

    Task<HotelResponse?> GetByIdAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default);

    Task<PagedResult<HotelResponse>> GetPagedAsync(
        HotelFilter filter,
        CancellationToken cancellationToken= default);

    Task ActivateAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default);

    Task DeactivateAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default);
}
