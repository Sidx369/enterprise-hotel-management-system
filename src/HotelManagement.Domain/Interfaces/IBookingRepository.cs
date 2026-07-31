using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<bool> HasOverlappingBookingAsync(
            Guid roomId,
            DateOnly checkIn,
            DateOnly checkOut,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Booking>> GetActiveBookingsForRoomAsync(
            Guid roomId,
            CancellationToken cancellationToken = default);
    }
}
