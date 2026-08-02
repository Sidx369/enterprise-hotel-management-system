using HotelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IReadOnlyList<Room>> GetRoomsByHotelAsync(
            Guid hotelId,
            CancellationToken cancellationToken = default);

        Task<bool> RoomNumberExistsAsync(
            Guid hotelId,
            string roomNumber,
            CancellationToken cancellationToken= default);

        Task<IReadOnlyList<Room>> GetAvailableRoomsAsync(
            Guid hotelId,
            CancellationToken cancellationToken = default);
    }
}
