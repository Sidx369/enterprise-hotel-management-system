using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Exceptions
{
    public sealed class BookingException : DomainException
    {
        public BookingException(string message)
            : base(message)
        {
            
        }
    }
}
