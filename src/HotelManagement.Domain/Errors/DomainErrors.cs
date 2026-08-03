using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Errors;

/// <summary>
/// Centralized domain error messages.
/// </summary>
public static class DomainErrors
{
    public static class Booking
    {
        public const string OnlyPendingCanBeConfirmed =
            "Only pending bookings can be confirmed.";

        public const string CheckedOutCannotBeCancelled =
            "A checked-out booking cannot be cancelled.";

        public const string OnlyConfirmedCanCheckIn =
            "Only confirmed bookings can be checked in.";

        public const string OnlyCheckedInCanCheckOut =
            "Only checked-in bookings can be checked out.";
    }

    public static class Room
    {
        public const string InactiveRoom =
            "The room is inactive.";
    }
}
