using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Application.Common.Exceptions;

/// <summary>
/// Represents an optimistic concurrency conflict.
/// </summary>
public sealed class ConcurrencyException : Exception
{
    public ConcurrencyException(string message)
        : base(message)
    {
        
    }
}
