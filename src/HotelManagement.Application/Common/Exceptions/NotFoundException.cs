using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Common.Exceptions;

/// <summary>
/// Represents an application-level resource-not-found error.
/// </summary>
public sealed class NotFoundException : Exception
{
    public NotFoundException(string resourceName, object resourceId)
         : base($"{resourceName} with identifier '{resourceId}' was not found.")
    {
        ResourceName = resourceName;
        ResourceId = resourceId;
    }

    public string ResourceName { get; }

    public object ResourceId { get; }
}
