using AutoMapper;
using HotelManagement.Application.Common.Models;
using HotelManagement.Application.Features.Hotels.Contracts.Requests;
using HotelManagement.Application.Features.Hotels.Contracts.Responses;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Mapping;

/// <summary>
/// AutoMapper configuration for the Hotel feature.
/// </summary>
public sealed class HotelMappingProfile : Profile
{
    public HotelMappingProfile()
    {
        CreateMap<AddressModel, Address>()
            .ConstructUsing(source =>
            new Address(
                source.AddressLine1,
                source.AddressLine2,
                source.City,
                source.State,
                source.Country,
                source.PostalCode));

        CreateMap<Address, AddressModel>()
            .ForMember(
            destination => destination.AddressLine1,
            options => options.MapFrom(source => source.Line1));

        CreateMap<CreateHotelRequest, Hotel>()
            .ConstructUsing((source, context) =>
            new Hotel(
                new HotelDetails(
                    source.Name,
                    context.Mapper.Map<Address>(source.Address),
                    source.StarRating,
                    source.Description,
                    source.Email,
                    source.PhoneNumber
                    )));

        CreateMap<Hotel, HotelResponse>()
            .ForMember(
            destination => destination.Name,
            options => options.MapFrom(source => source.Details.Name))
            .ForMember(
                destination => destination.Description,
                options => options.MapFrom(source => source.Details.Description))
            .ForMember(
                destination => destination.Email,
                options => options.MapFrom(source => source.Details.Email))
            .ForMember(
                destination => destination.PhoneNumber,
                options => options.MapFrom(source => source.Details.PhoneNumber))
            .ForMember(
                destination => destination.Address,
                options => options.MapFrom(source => source.Details.Address))
            .ForMember(
                destination => destination.StarRating,
                options => options.MapFrom(source => source.Details.StarRating));
    }
}
