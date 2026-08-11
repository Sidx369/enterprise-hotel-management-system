using FluentValidation;
using HotelManagement.Application.Common.Models;
using HotelManagement.Application.Features.Hotels.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Validators;

internal static class HotelValidationExtensions
{
    public static void ApplyCommonHotelRules<T>(
        this AbstractValidator<T> validator) where T: IHotelRequest
    {
        validator.RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        validator.RuleFor(x => x.Description)
            .MaximumLength(2000);

        validator.RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(320);

        validator.RuleFor(x => x.PhoneNumber)
            .MaximumLength(20);

        validator.RuleFor(x => x.Address)
            .NotNull();

        validator.RuleFor(x => x.Address.AddressLine1)
            .NotEmpty()
            .MaximumLength(200);

        validator.RuleFor(x => x.Address.AddressLine2)
            .MaximumLength(200);

        validator.RuleFor(x => x.Address.City)
            .NotEmpty()
            .MaximumLength(100);

        validator.RuleFor(x => x.Address.State)
            .NotEmpty()
            .MaximumLength(100);

        validator.RuleFor(x => x.Address.Country)
            .NotEmpty()
            .MaximumLength(100);

        validator.RuleFor(x => x.Address.PostalCode)
            .NotEmpty()
            .MaximumLength(20);

        validator.RuleFor(x => x.StarRating)
            .InclusiveBetween(1, 5);
    }
}
