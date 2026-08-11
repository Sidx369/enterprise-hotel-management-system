using FluentValidation;
using HotelManagement.Application.Features.Hotels.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Validators;

/// <summary>
/// Validates hotel creation requests.
/// </summary>
public sealed class CreateHotelRequestValidator
    : AbstractValidator<CreateHotelRequest>
{
    public CreateHotelRequestValidator()
    {
        this.ApplyCommonHotelRules();
    }
}
