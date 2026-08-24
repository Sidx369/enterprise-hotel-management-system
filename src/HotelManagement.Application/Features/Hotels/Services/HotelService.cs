using AutoMapper;
using FluentValidation;
using HotelManagement.Application.Common.Exceptions;
using HotelManagement.Application.Common.Pagination;
using HotelManagement.Application.Features.Hotels.Contracts.Filters;
using HotelManagement.Application.Features.Hotels.Contracts.Requests;
using HotelManagement.Application.Features.Hotels.Contracts.Responses;
using HotelManagement.Application.Features.Hotels.Interfaces;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;
using HotelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Services;

/// <summary>
/// Application service responsible for hotel use cases.
/// </summary>
public sealed class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateHotelRequest> _createValidator;
    private readonly IValidator<UpdateHotelRequest> _updateValidator;

    public HotelService(
        IHotelRepository hotelRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateHotelRequest> createValidator,
        IValidator<UpdateHotelRequest> updateValidator)
    {
        _hotelRepository = hotelRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    /// <inheritdoc />
    public async Task<HotelResponse> CreateAsync(
        CreateHotelRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        await ValidateAsync(
            _createValidator,
            request,
            cancellationToken);

        var hotel = _mapper.Map<Hotel>(request);

        await _hotelRepository.AddAsync(
            hotel,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<HotelResponse>(hotel);
    }

    /// <inheritdoc />
    public async Task<HotelResponse> UpdateAsync(
        Guid hotelId,
        UpdateHotelRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        await ValidateAsync(
            _updateValidator,
            request,
            cancellationToken);

        var hotel = await _hotelRepository.GetByIdAsync(
            hotelId,
            cancellationToken);

        if (hotel is null)
            throw new NotFoundException(nameof(Hotel), hotelId);

        EnsureConcurrency(hotel,
            request.RowVersion);

        var address = _mapper.Map<Address>(request.Address);

        var details = new HotelDetails(
            request.Name,
            address,
            request.StarRating,
            request.Description,
            request.Email,
            request.PhoneNumber);

        hotel.UpdateDetails(details);

        _hotelRepository.Update(hotel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<HotelResponse>(hotel);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default)
    {
        var hotel = await _hotelRepository.GetByIdAsync(
            hotelId,
            cancellationToken);

        if(hotel is null)
        {
            throw new NotFoundException(
                nameof(Hotel),
                hotelId);
        }

        _hotelRepository.Remove(hotel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<HotelResponse?> GetByIdAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default)
    {
        var hotel = await _hotelRepository.GetByIdAsync(
            hotelId,
            cancellationToken);

        return hotel is null ? null : _mapper.Map<HotelResponse>(hotel);
    }

    /// <inheritdoc />
    public async Task<PagedResult<HotelResponse>> GetPagedAsync(
        HotelFilter filter,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(filter);

        var skip = checked(
            (filter.PageNumber - 1) * filter.PageSize);

        var hotels = await _hotelRepository.GetPagedAsync(
            filter.Name,
            filter.City,
            filter.IsActive,
            filter.SortBy,
            filter.Descending,
            skip,
            filter.PageSize,
            cancellationToken);

        var totalCount = await _hotelRepository.CountAsync(
            filter.Name,
            filter.City,
            filter.IsActive,
            cancellationToken);

        var responses = _mapper
            .Map<IReadOnlyCollection<HotelResponse>>(hotels);

        return new PagedResult<HotelResponse>
        {
            Items = responses,
            PageNumber = filter.PageNumber,
            PageSize = filter.PageSize,
            TotalCount = totalCount
        };
    }

    /// <inheritdoc />
    public async Task ActivateAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default)
    {
        var hotel = await GetHotelOrThrowAsync(
            hotelId, 
            cancellationToken);

        hotel.Activate();

        _hotelRepository.Update(hotel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeactivateAsync(
        Guid hotelId,
        CancellationToken cancellationToken = default)
    {
        var hotel = await GetHotelOrThrowAsync(
            hotelId,
            cancellationToken);

        hotel.Deactivate();

        _hotelRepository.Update(hotel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<Hotel> GetHotelOrThrowAsync(
        Guid hotelId,
        CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(
            hotelId,
            cancellationToken);

        if(hotel is null)
        {
            throw new NotFoundException(
                nameof(Hotel),
                hotelId);
        }

        return hotel;
    }

    public static async Task ValidateAsync<TRequest>(
        IValidator<TRequest> validator,
        TRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request,
            cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(
                validationResult.Errors);
        }
    }

    private static void EnsureConcurrency(
        Hotel hotel,
        byte[] requestRowVersion)
    {
        if (!hotel.RowVersion.AsSpan().SequenceEqual(requestRowVersion))
        {
            throw new ConcurrencyException(
                $"Hotel '{hotel.Id}' has been modified since it was last retrieved");
        }
    }
}
