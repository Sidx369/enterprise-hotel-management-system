using HotelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Interfaces
{
    public interface IRoomTypeRepository : IRepository<RoomType>
    {
        /// <summary>
        /// Gets a room type by name.
        /// </summary>
        Task<RoomType?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Determines whether a room type with the given name exists.
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);
    }
}
