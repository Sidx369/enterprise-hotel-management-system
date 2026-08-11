using FluentValidation;
using HotelManagement.Application.Features.Hotels.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Features.Hotels.Validators;

/// <summary>
/// Validates hotel update requests.
/// </summary>
public sealed class UpdateHotelRequestValidator 
    : AbstractValidator<UpdateHotelRequest>
{
    public UpdateHotelRequestValidator()
    {
        this.ApplyCommonHotelRules();
    }
}
