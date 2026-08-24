using HotelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Interfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<Hotel?> GetByIdWithRoomsAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken= default);

        Task<IReadOnlyList<Hotel>> GetPagedAsync(
            string? name,
            string? city,
            bool? isActive,
            string? sortBy,
            bool descending,
            int skip,
            int take,
            CancellationToken cancellationToken = default);

        Task<int> CountAsync(
            string? name,
            string? city,
            bool? isActive,
            CancellationToken cancellationToken = default);
    }
}
